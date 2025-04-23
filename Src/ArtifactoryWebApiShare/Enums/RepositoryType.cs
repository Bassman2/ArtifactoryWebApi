namespace ArtifactoryWebApi;

/// <summary>
/// Represents the type of a repository in the Artifactory system.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter<RepositoryType>))]
public enum RepositoryType
{
    /// <summary>
    /// Represents a local repository, which stores artifacts locally.
    /// </summary>
    [EnumMember(Value = "LOCAL")]
    LOCAL,

    /// <summary>
    /// Represents a remote repository, which proxies artifacts from a remote source.
    /// </summary>
    [EnumMember(Value = "REMOTE")]
    Remote,

    /// <summary>
    /// Represents a virtual repository, which aggregates multiple repositories into a single logical repository.
    /// </summary>
    [EnumMember(Value = "VIRTUAL")]
    Virtual,

    /// <summary>
    /// Represents a repository type that is not applicable or unspecified.
    /// </summary>
    [EnumMember(Value = "NA")]
    NA
}
