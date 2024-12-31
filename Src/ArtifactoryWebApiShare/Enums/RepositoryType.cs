namespace ArtifactoryWebApi;

[JsonConverter(typeof(JsonStringEnumConverter<RepositoryType>))]
public enum RepositoryType
{
    [EnumMember(Value = "LOCAL")]
    LOCAL,

    [EnumMember(Value = "REMOTE")]
    Remote,

    [EnumMember(Value = "VIRTUAL")]
    Virtual,

    [EnumMember(Value = "NA")]
    NA
}
