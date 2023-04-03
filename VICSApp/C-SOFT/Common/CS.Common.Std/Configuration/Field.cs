using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace CS.Common.Std.Configuration
{
    public enum FieldType
    {
        Data,
        Open,
        Close,
        System
    }

    [DataContract]
    public class Field
    {
        [DataMember(Name = "tag")]
        public string Tag { get; set; }
        [DataMember(Name = "qualifier")]
        public string Qualifier { get; set; }
        [DataMember(Name = "parts")]
        public IList<Part> Parts { get; set; }
        [DataMember(Name = "optional")]
        public bool IsOptional { get; set; }
        [DataMember(Name = "part_start")]
        public string PartStart { get; set; }
        [DataMember(Name = "part_end")]
        public string PartEnd { get; set; }
        [DataMember(Name = "start")] 
        public string Start { get; set; }
        [DataMember(Name = "end")]
        [DefaultValue(ConstantFieldProvider.NewLine)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string End { get; set; }
        [DefaultValue(":")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        [DataMember(Name = "tag_start")]
        public string TagStart { get; set; }
        [DefaultValue(":")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        [DataMember(Name = "tag_end")]
        public string TagEnd { get; set; }
        [DefaultValue(":")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        [DataMember(Name = "qualifier_start")]
        public string QualifierStart { get; set; }
        [DataMember(Name = "qualifier_end")]
        [DefaultValue("/")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string QualifierEnd { get; set; }
        [DefaultValue(FieldType.Data)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        [DataMember(Name = "type")]
        public FieldType Type { get; set; }

        public bool IsOpenField => Type == FieldType.Open;
        public bool IsEndField => Type == FieldType.Close;

        public static string BuildTag(Field field, bool includeDefault = true, bool includeFieldEndAsSubfix = false)
        {
            if (field == null)
                return string.Empty;

            var builder = new StringBuilder();

            if (includeFieldEndAsSubfix)
                builder.Append(field.End);
            if (!string.IsNullOrEmpty(field.Tag))
                builder.AppendFormat("{0}{1}{2}{3}", field.Start, field.TagStart, field.Tag, field.TagEnd);
            if (!string.IsNullOrEmpty(field.Qualifier))
                builder.AppendFormat("{0}{1}{2}", field.QualifierStart, field.Qualifier, field.QualifierEnd);
            if (field.Parts != null && field.Parts.Count == 1 && includeDefault)
            {
                var part = field.Parts[0];
                if (string.IsNullOrEmpty(part.Name) && !string.IsNullOrEmpty(part.Default))
                    builder.AppendFormat("{0}{1}", part.Default, part.End);
            }

            return builder.ToString();
        }
    }
}
