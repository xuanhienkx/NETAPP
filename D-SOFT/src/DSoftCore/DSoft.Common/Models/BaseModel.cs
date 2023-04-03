﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DSoft.Common.Models;

public abstract class BaseModel : ILiteralId
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
}
public interface ILiteralId
{
    string Id { get; }
}
