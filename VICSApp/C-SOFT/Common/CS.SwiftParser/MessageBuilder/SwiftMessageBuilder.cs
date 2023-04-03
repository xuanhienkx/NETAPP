using CS.Common;
using CS.Common.Enums;
using CS.Common.FileTransfer;
using CS.Common.Interfaces;
using CS.SwiftParser.Configuration;
using CS.SwiftParser.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS.Common.Std;

namespace CS.SwiftParser.MessageBuilder
{
    public class SwiftMessageBuilder : IMessageBuilder
    {
        private readonly IFileService fileService;
        private readonly IEnumerable<IMessageConverter> messageParsers;
        private readonly Interpreter interpreter;

        public SwiftMessageBuilder(IFileService fileService, IEnumerable<IMessageConverter> messageParsers, SwiftSetting config)
        {
            if (config == null) throw new ArgumentNullException(nameof(config));
            this.fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));

            this.messageParsers = messageParsers ?? throw new ArgumentNullException(nameof(messageParsers));
            this.interpreter = new Interpreter(config.BlockStart, config.BlockDelimiter, config.BlockEnd);
        }
        
        public async Task<T> Read<T>(string fileName, Stream fileStream) where T : CsBag
        {
            var blocks = new List<KeyValuePair<string, string>>();
            string rawData;

            using (var reader = new StreamReader(fileStream))
            {
                rawData = reader.ReadToEnd();

                await fileStream.FlushAsync();
                fileStream.Dispose();
            }

            //Todo: fixed tam khi Message ACK/NAK tra ve du dau '}'
            rawData = rawData.Replace("}}}﻿", "}}");
            var file = fileService.GetFileName(fileName);
            if (IsFileAct(file))
            {
                blocks.Add(new KeyValuePair<string, string>(BusinessIdProviderConstant.CsvData, rawData));
                blocks.Add(new KeyValuePair<string, string>(BusinessIdProviderConstant.FileName, file)); 
            }
            else
            {
                blocks = interpreter.Parse(rawData).ToList();
            }

            var parser = messageParsers.FirstOrDefault(p => p.CanParse(blocks));
            if (parser == null)
                throw new InvalidSwiftMessageException("Cannot find the parser that is suitable while reading message");

            return parser.Parse<T>(blocks);
        }

        public void Write(Stream stream, CsBag messageBag)
        {
            var messageType = CSEnum.Parse<MessageType>(messageBag[BusinessIdProviderConstant.MessageType]);
            var swiftBag = new SwiftBag(messageType);
            swiftBag.AddRange(messageBag);

            foreach (var parser in messageParsers)
            {
                parser.CollectLiteralData(swiftBag);
            }

            var messageBuilder = messageParsers.FirstOrDefault(p => p.CanBuild(swiftBag));
            if (messageBuilder == null)
                throw new InvalidSwiftMessageException("Cannot build the message from bag data");

            var writer = new StreamWriter(stream, Encoding.UTF8);
            try
            {
                writer.WriteAsync(messageBuilder.Build(swiftBag));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                writer.Dispose();
            }
        }

        private bool IsFileAct(string fileName)
        {
            return fileName.EndsWith(".par", StringComparison.OrdinalIgnoreCase);
        }

    }
}
