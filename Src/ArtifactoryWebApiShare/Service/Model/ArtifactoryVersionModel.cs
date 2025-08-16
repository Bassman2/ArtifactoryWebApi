namespace ArtifactoryWebApi.Service.Model;

internal class ArtifactoryVersionModel
{
    [JsonPropertyName("version")]
    public string? Version { get; set; }

    [JsonPropertyName("revision")]
    public string? Revision { get; set; }
}
