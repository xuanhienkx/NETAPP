using DO.Common.Domain.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BO.Core.DataCommon.Entities;

public abstract class IdentityEntityBase : IIdentityEntity<long>
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public long Id { get; set; }
}
public abstract class UniqueIdentityEntityBase : IIdentityEntity<Guid>
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public Guid Id { get; set; }
}
