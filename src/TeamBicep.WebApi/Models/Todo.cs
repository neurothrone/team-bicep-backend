using MongoDB.Bson.Serialization.Attributes;

namespace TeamBicep.WebApi.Models;

public class Todo
{
    [BsonElement("Id")]
    public string Id { get; set; } = string.Empty;

    [BsonElement("Name")]
    public string Name { get; set; } = string.Empty;
    [BsonElememt("IsCompleted")]
    public bool IsCompleted { get; set; } = false;

}
