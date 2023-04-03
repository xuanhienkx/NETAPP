using DO.Common.Domain.Interfaces;
using MongoDB.Bson.Serialization.Attributes;

namespace BO.Core.DataCommon.Entities;

public class User : UniqueIdentityEntityBase, IReversionEntity<Guid>
{

    [BsonElement("externalId")]
    public string ExternalId { get; set; }

    [BsonElement("firstName")]
    public string FirstName { get; set; }

    [BsonElement("lastName")]

    public string LastName { get; set; }
    public long BranchId { get; set; }
    public int Version { get; set; }

}


