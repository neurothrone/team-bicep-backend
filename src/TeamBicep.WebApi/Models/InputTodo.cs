using System.ComponentModel;
using System.Text.Json.Serialization;

namespace TeamBicep.WebApi.Models;

public class InputTodo
{
    [JsonPropertyName("name")]
    [DefaultValue("Find the Holy Grail")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("completed")]
    [DefaultValue(false)]
    public bool Completed { get; set; } = false;
}