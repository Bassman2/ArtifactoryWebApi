namespace ArtifactoryWebApi.Model;

[DebuggerDisplay("{Type} {PackageType} {Key}")]
internal class RepositoryModel
{
    [JsonPropertyName("key")]
    public string? Key { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("type")]
    public RepositoryType Type { get; set; }

    [JsonPropertyName("url")]
    public Uri? Url { get; set; }

    [JsonPropertyName("packageType")]
    public PackageType PackageType { get; set; }
}
