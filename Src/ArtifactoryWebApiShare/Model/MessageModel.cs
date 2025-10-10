namespace ArtifactoryWebApi.Model;

internal class MessageModel
{
    [JsonPropertyName("level")]
    public string? Level { get; set; }

    [JsonPropertyName("message")]
    public string? Message { get; set; }
}
