using System.Runtime.Serialization;

namespace CS.Common.Std.Configuration
{
    public enum KeyType
    {
        All,
        One,
        Ref
    }

    [DataContract]
    public class FieldKey : Field
    {
        [DataMember(Name = "keyType")]
        public KeyType KeyType { get; set; }
    }
}
