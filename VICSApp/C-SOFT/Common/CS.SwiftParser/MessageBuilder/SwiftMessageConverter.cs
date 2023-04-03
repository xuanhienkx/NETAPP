using CS.Common;
using CS.Common.Interfaces;
using CS.Common.Std;
using CS.Common.Std.Configuration;
using CS.Common.Std.Extensions;
using CS.SwiftParser.Configuration;
using CS.SwiftParser.Exceptions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS.SwiftParser.MessageBuilder
{
    public abstract class SwiftMessageConverter
    {
        private readonly IFieldConfigurator fieldConfigurator;
        private readonly SwiftSetting swiftSetting;
        private readonly IValueConverter valueConverter;
        protected readonly ILogger<SwiftMessageConverter> Logger;

        protected SwiftMessageConverter(IValueConverter valueConverter,
        IFieldConfigurator fieldConfigurator,
        SwiftSetting swiftSetting,
        ILogger<SwiftMessageConverter> logger)
        {
            this.fieldConfigurator = fieldConfigurator ?? throw new ArgumentNullException(nameof(fieldConfigurator));
            this.swiftSetting = swiftSetting ?? throw new ArgumentNullException(nameof(swiftSetting));
            this.valueConverter = valueConverter ?? throw new ArgumentNullException(nameof(valueConverter));
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        protected abstract MessageType MessageType { get; }

        #region Paser

        protected SwiftBag ParseToBag(IList<KeyValuePair<string, string>> blocks)
        {
            var messageConfig = swiftSetting.Messages.FirstOrDefault(m => m.Type == MessageType && m.RequestType == RequestType.Response);
            if (messageConfig == null)
                throw new MessageConfigurationNotFoundException(MessageType, RequestType.Response);


            var result = new SwiftBag(MessageType);
            var index = 0;
            result = ParseToBagExt(result, blocks, messageConfig.Blocks, ref index);
            if (MessageType == MessageType.ACKNAK)
            {
                messageConfig = swiftSetting.Messages.FirstOrDefault(m => m.Type == MessageType.MT && m.RequestType == RequestType.Request);
                var mtBag = new SwiftBag(MessageType.MT);
                var msBlocks = messageConfig?.Blocks.Where(x => new[] { "1", "2" }.Contains(x.Identifier)).ToList(); 
                mtBag = ParseToBagExt(mtBag, blocks, msBlocks, ref index);
                var startTag = mtBag.MessageId == "598" ? ":20:" : ":20C::SEME//";
                var blockValue = blocks[4].Value;
                var blockDataValue = blockValue.Replace("\n", ConstantFieldProvider.NewLine).Replace("\r", string.Empty);

                var value = blockDataValue.Between(startTag, ConstantFieldProvider.NewLine, 0, out index);// blockValue.SubStringWithTrimStart(startTag, 16);
                result[BusinessIdProviderConstant.TransactionReferenceNumber] = valueConverter.Parse(value, CSValueType.Integer, "D16");
                result[BusinessIdProviderConstant.SessionInteger] = mtBag[BusinessIdProviderConstant.SessionInteger];
                result[BusinessIdProviderConstant.InputSequenceInteger] = mtBag[BusinessIdProviderConstant.InputSequenceInteger];
                result[BusinessIdProviderConstant.MessageId] = mtBag.MessageId;
            }
            return result;
        }

        private SwiftBag ParseToBagExt(SwiftBag result, IList<KeyValuePair<string, string>> blocks, IList<Block> configBlocks, ref int index)
        {
            foreach (var block in configBlocks)
            {
                if (block.Ignorable)
                {
                    index++;
                    continue;
                }

                if (!blocks[index].Key.Equals(block.Identifier))
                    throw new InvalidSwiftMessageException(blocks[index].Value);

                var blockValue = blocks[index++].Value;
                if (!string.IsNullOrEmpty(block.Start))
                    blockValue = blockValue.TrimStartAll(block.Start);
                if (!string.IsNullOrEmpty(block.End))
                    blockValue = blockValue.TrimEndAll(block.End);
                blockValue = blockValue.Replace("\n", ConstantFieldProvider.NewLine).Replace("\r", string.Empty);

                var fields = GetFieldConfiguration(blockValue, block, result);
                if (fields == null || !fields.Any())
                    continue;

                var fieldReader = new ItemReader<Field>(fields);
                ParseBlockValues(fieldReader, blockValue, result);
            }
            return result;
        }
        private string ValidateAndGetFieldsOptional(ItemReader<Field> reader, string data, Func<ItemReader<Field>, Field> getField, Func<Field, bool> predict = null)
        {
            var field = getField(reader);
            if (field == null)
                return string.Empty;

            //var groupOptional = field.IsOpenField && field.IsOptional;

            var result = Field.BuildTag(field, includeFieldEndAsSubfix: true);
            while ((predict == null || predict(field)) && data.IndexOf(result, StringComparison.OrdinalIgnoreCase) == -1)
            {
                Logger.LogDebug("Passby field: {0}", result);

                reader.MoveNext();
                field = getField(reader);
                if (field == null)
                    return string.Empty;

                //if (field.IsOpenField)
                //    groupOptional = field.IsOptional;

                //if (groupOptional || field.IsOptional)
                //    continue;

                result = Field.BuildTag(field, includeFieldEndAsSubfix: true);
            }
            return result;
        }

        private void ParseBlockValues(ItemReader<Field> fieldReader, string blockData, SwiftBag bagResult)
        {
            Logger.LogDebug("Block data: {0}", blockData);

            while (fieldReader.MoveNext())
            {
                if (fieldReader.Current.IsEndField || fieldReader.Current.Type == FieldType.System)
                    continue;

                var start = Field.BuildTag(fieldReader.Current);
                string end;
                int index;
                if (fieldReader.Current.IsOpenField)
                {
                    end = start.Replace(":16R:", ":16S:");
                    Logger.LogDebug("Start: {0} - End: {1}", start, end);

                    if (fieldReader.Current.IsOptional &&
                        blockData.IndexOf(start, StringComparison.OrdinalIgnoreCase) == -1)
                    {
                        while (fieldReader.MoveNext())
                        {
                            if (fieldReader.Current.IsEndField && end.Equals(Field.BuildTag(fieldReader.Current), StringComparison.OrdinalIgnoreCase))
                                break;
                            Logger.LogDebug("Passby field: {0} in group field: {1}", fieldReader.Current.Tag, start);
                        }
                        continue;
                    }

                    var groupFields = new List<Field>();
                    while (fieldReader.MoveNext())
                    {
                        if (fieldReader.Current.IsEndField && end.Equals(Field.BuildTag(fieldReader.Current), StringComparison.OrdinalIgnoreCase))
                            break;
                        groupFields.Add(fieldReader.Current);
                    }

                    var groupData = blockData.Between(start, end, 0, out index);
                    ParseBlockValues(new ItemReader<Field>(groupFields), groupData, bagResult);
                    blockData = blockData.Substring(index + end.Length);

                    Logger.LogDebug("Block data: {0}", blockData);
                    continue;
                }

                var currentField = fieldReader.Current;
                end = ValidateAndGetFieldsOptional(fieldReader, blockData, reader => reader.Next, field => !field.IsOpenField && !field.IsEndField);
                if (blockData.IndexOf(start, StringComparison.OrdinalIgnoreCase) == -1)
                    continue;

                var fieldValue = blockData.Between(start, end, 0, out index);
                if (index == -1)
                {
                    if (fieldReader.Next == null || fieldReader.Next.IsOptional)
                        continue;

                    Logger.LogDebug("Error---------------");
                    Logger.LogDebug("Start: " + start);
                    Logger.LogDebug("End: " + end);

                    Logger.LogDebug(JsonConvert.SerializeObject(currentField));
                    throw new InvalidSwiftMessageException(blockData);
                }

                Logger.LogDebug("Field start: {0}, end: {1}, value: {2}", start, end, fieldValue);

                var fieldResult = ParseFieldValues(fieldValue, currentField);
                if (fieldResult != null)
                    bagResult.AddRange(fieldResult);
            }
        }

        private CsBag ParseFieldValues(string fieldData, Field field)
        {
            if (field.Parts == null)
                return null;

            var bagResult = new CsBag();
            fieldData = fieldData.TrimEndAll(field.End);

            Logger.LogDebug("Start tag: {0} -- Data: {1}, field end: {2}", field.Tag, fieldData, field.End);

            var index = 0;
            foreach (var part in field.Parts)
            {
                if (string.IsNullOrEmpty(part.Name))
                    continue;

                var start = $"{field.PartStart}{part.Start}";

                var value = fieldData.SubStringWithTrimStart(start, index, part.Length);

                if (string.IsNullOrEmpty(value) && part.IsOptional)
                    continue;

                if (part.Type.Equals(CSValueType.String))
                    value = value.Replace(ConstantFieldProvider.NewLine, Environment.NewLine);

                Logger.LogDebug("Value: [{0}] - start: {1}, index: {2}, length: {3}, name: {4}", value, start, index, part.Length, part.Name);

                bagResult[part.Name] = valueConverter.Parse(value, part.Type, part.Format);

                index += start.Length + part.Length + $"{part.End}{field.PartEnd}".Length;

                if (index >= fieldData.Length)
                    break;
            }

            return bagResult;
        }

        #endregion

        #region Builder

        protected bool CanBuildMessage(SwiftBag messageBag)
        {
            return messageBag?.MessageType == MessageType;
        }

        protected string BuildMessage(SwiftBag swiftBag)
        {
            if (swiftBag == null)
                throw new ArgumentNullException(nameof(swiftBag));

            var messageConfig = swiftSetting.Messages.FirstOrDefault(m => m.Type == MessageType && m.RequestType == RequestType.Request);
            if (messageConfig == null)
                throw new MessageConfigurationNotFoundException(MessageType, RequestType.Request);

            var builder = new StringBuilder();

            foreach (var block in messageConfig.Blocks)
            {
                if (block.Ignorable && !string.IsNullOrEmpty(block.Default))
                {
                    builder.Append($"{swiftSetting.BlockStart}{block.Identifier}{swiftSetting.BlockDelimiter}{block.Default}{block.End}{swiftSetting.BlockEnd}");
                    continue;
                }

                builder.Append($"{swiftSetting.BlockStart}{block.Identifier}{swiftSetting.BlockDelimiter}{block.Start}");

                AppendFieldValue(swiftBag, block, builder);

                builder.Append($"{block.End}{swiftSetting.BlockEnd}");
            }

            return builder.Replace(ConstantFieldProvider.NewLine, Environment.NewLine).ToString();
        }

        private void AppendFieldValue(SwiftBag bag, Block block, StringBuilder builder)
        {
            var fields = GetFieldConfiguration(bag, block);

            if (fields == null || !fields.Any())
                return;

            var fieldReader = new ItemReader<Field>(fields);

            if (fieldReader.MoveNext())
            {
                AppendAndBuildFieldValue(fieldReader, bag, builder, string.Empty, string.Empty);
            }
        }

        private string AppendAndBuildFieldValue(ItemReader<Field> fieldReader, SwiftBag bag, StringBuilder builder, string startField, string endField, bool isOptional = false)
        {
            var field = fieldReader.Current;
            var start = Field.BuildTag(field);
            Logger.LogDebug("Group field: [{0}] - current field: [{1}]", startField, start);

            if (field.IsOpenField && fieldReader.MoveNext())
            {
                var groupValue = AppendAndBuildFieldValue(fieldReader, bag, new StringBuilder(), start, field.End, field.IsOptional);

                Logger.LogDebug("Append group value: [{0}]", groupValue);
                builder.Append(groupValue);
            }
            else if (field.IsEndField)
            {
                if (builder.Length != 0)
                    return $"{startField}{endField}{builder}{start}{field.End}";

                if (!isOptional)
                    throw new InvalidSwiftMessageException($"Group fields: [{startField}] is requried but it contains no-content");

                return string.Empty;
            }
            else
            {
                var fieldValue = BuildPartValues(bag, field, isOptional);

                if (!string.IsNullOrEmpty(fieldValue))
                    builder.AppendFormat("{0}{1}{2}", start, fieldValue, field.End);
                else if (!field.IsOptional && !isOptional)
                    throw new InvalidSwiftMessageException($"Field: [{start}] is requried while it has no-content");
            }

            return fieldReader.MoveNext()
                ? AppendAndBuildFieldValue(fieldReader, bag, builder, startField, endField, isOptional)
                : builder.ToString();
        }

        private string BuildPartValues(CsBag fieldBag, Field field, bool isOptional = false)
        {
            var builder = new StringBuilder();
            foreach (var part in field.Parts)
            {
                if (!string.IsNullOrEmpty(part.Default) && string.IsNullOrEmpty(part.Name))
                {
                    builder.Append($"{field.PartStart}{part.Start}{part.Default}{part.End}{field.PartEnd}");
                    continue;
                }

                object partValue;
                if (!fieldBag.Keys.Contains(part.Name))
                {
                    if (part.IsOptional || isOptional || field.IsOptional)
                        continue;

                    if (string.IsNullOrEmpty(part.Default))
                        throw new RequiredDataException(part.Name);

                    partValue = part.Default;
                }
                else
                {
                    partValue = fieldBag[part.Name];
                    if (part.IsOptional && partValue == null)
                        continue;
                }

                Logger.LogDebug($"{part.Name}: {partValue}");

                var value = valueConverter.ToString(partValue, part.Type, part.Format);

                if (part.Line > 1 && value.Length > part.Length)
                {
                    var valueLine = value.Length / part.Length;
                    if (valueLine > part.Line)
                        throw new InvalidSwiftMessageException($"{part.Name} contains big data [{value}] that has [{valueLine}] lines while it limits to [{part.Line}] lines.");

                    value = value.ReplaceWithString(" ", Environment.NewLine, part.Length);
                }
                builder.Append($"{field.PartStart}{part.Start}{value}{part.End}{field.PartEnd}");
            }

            return builder.ToString();
        }

        #endregion

        #region Helper

        private IList<Field> GetFieldConfiguration(string blockData, Block block, SwiftBag bag)
        {
            if (block.Fields != null && block.Fields.Any())
                return block.Fields;

            var keyBuilder = new StringBuilder();

            var messageKey = swiftSetting.ResponseMessageKeys.FirstOrDefault(x => x.MessageId == bag.MessageId);
            if (messageKey != null && messageKey.FieldKeys != null && messageKey.FieldKeys.Any())
            {
                foreach (var field in messageKey.FieldKeys)
                {
                    keyBuilder.Append("_");
                    var startField = Field.BuildTag(field, includeDefault: false);
                    var index = 0;
                    foreach (var part in field.Parts)
                    {
                        var start = $"{startField}{field.PartStart}{part.Start}";
                        Logger.LogDebug("Start field: [{0}], start: [{1}], block data: [{2}]", startField, start, blockData);

                        string value;
                        if (part.Length == 0)
                        {
                            value = blockData.Between(start, part.End, index, out int oIndex);
                            index += oIndex;
                        }
                        else
                        {
                            value = blockData.SubStringWithTrimStart(start, index, part.Length);
                            index += part.Length;
                        }
                        index += start.Length + $"{part.End}{field.PartEnd}".Length;
                        value = value.Trim();

                        if (part.IsOptional && string.IsNullOrEmpty(value))
                            continue;
                        if (string.IsNullOrEmpty(value))
                            value = part.Default;

                        keyBuilder.Append(value);

                        if (field.KeyType == KeyType.One)
                            break;

                        if (field.KeyType == KeyType.Ref)
                        {
                            var businessId = fieldConfigurator.BussinessIdByRef(value);
                            return BuildFields(businessId, bag);
                        }
                    }
                }
            }

            var keyValue = keyBuilder.ToString().Trim('_', ' ');
            Logger.LogInformation($"Response key value: [{keyValue}], MessageId: [{bag.MessageId}]");

            var businessUnit = swiftSetting.BusinessUnits.Single(
                                            x => x.Messages.Any(m => m.RequestType == RequestType.Response
                                            && m.Id == bag.MessageId
                                            && m.KeyValue.Equals(keyValue, StringComparison.OrdinalIgnoreCase)));
            return BuildFields(businessUnit.Id, bag);
        }

        private IList<Field> BuildFields(string businessId, SwiftBag bag)
        {
            bag[BusinessIdProviderConstant.BusinessId] = businessId;
            var configId = $"{businessId}/{bag.MessageType}{bag.MessageId}_Response";

            Logger.LogInformation($"File structure: [{configId}]");
            return fieldConfigurator[configId];
        }

        private IList<Field> GetFieldConfiguration(SwiftBag bag, Block block)
        {
            if (block.Fields != null && block.Fields.Any())
                return block.Fields;

            var id = $"{bag[BusinessIdProviderConstant.BusinessId]}/{bag.MessageType}{bag.MessageId}_Request";

            Logger.LogInformation($"File structure: [{id}]");
            return fieldConfigurator[id];
        }

        #endregion

    }
}
