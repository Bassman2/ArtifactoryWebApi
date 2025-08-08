namespace ArtifactoryWebApi.Service.Model;

internal class VersionMode
{
    [JsonPropertyName("md5")]
    public string? Md5 { get; set; }
}
