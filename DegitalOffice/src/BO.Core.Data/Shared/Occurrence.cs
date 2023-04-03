using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace BO.Core.DataCommon.Shared
{
    [SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Local", Justification = "MongoDB serialization needs private setters")]
    public class Occurrence
    {
        public Occurrence() : this(DateTime.UtcNow)
        {
        }

        public Occurrence(DateTime occuranceInstantUtc)
        {
            Instant = occuranceInstantUtc;
        }

        [JsonIgnore]
        public DateTime Instant { get; private set; }

        [BsonIgnore]
        public DateTime Value => Instant.ToLocalTime();

        protected bool Equals(Occurrence other)
        {
            return Instant.Equals(other.Instant);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;

            return Equals((Occurrence)obj);
        }

        [SuppressMessage("ReSharper", "NonReadonlyMemberInGetHashCode", Justification = "MongoDB serialization needs private setters")]
        public override int GetHashCode()
        {
            return Instant.GetHashCode();
        }

        public static Occurrence FromLocal(DateTime dateTime)
        {
            return new Occurrence(dateTime.ToUniversalTime());
        }
    }
}
