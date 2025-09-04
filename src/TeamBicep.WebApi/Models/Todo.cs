using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TeamBicep.WebApi.Models;

public class Todo
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = string.Empty;

    [BsonElement("Name")]
    public string Name { get; set; } = string.Empty;
    [BsonElement("IsCompleted")]
    public bool IsCompleted { get; set; } = false;

}
