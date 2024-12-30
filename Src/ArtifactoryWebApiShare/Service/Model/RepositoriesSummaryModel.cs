namespace ArtifactoryWebApi.Service.Model;

internal class RepositoriesSummaryModel
{
    [JsonPropertyName("repoKey")]
    public string? RepoKey { get; set; }

    [JsonPropertyName("repoType")]
    [JsonConverter(typeof(JsonStringEnumConverter<RepositoryType>))]
    public RepositoryType RepoType { get; set; }

    [JsonPropertyName("foldersCount")]
    public long? FoldersCount { get; set; }

    [JsonPropertyName("filesCount")]
    public long? FilesCount { get; set; }

    [JsonPropertyName("usedSpace")]
    public string? UsedSpace { get; set; }

    [JsonPropertyName("usedSpaceInBytes")]
    public long? UsedSpaceInBytes { get; set; }

    [JsonPropertyName("itemsCount")]
    public long? ItemsCount { get; set; }

    [JsonPropertyName("packageType")]
    public PackageType? PackageType { get; set; }

    [JsonPropertyName("projectKey")]
    public string? ProjectKey { get; set; }

    [JsonPropertyName("percentage")]
    public string? Percentage { get; set; }
}
