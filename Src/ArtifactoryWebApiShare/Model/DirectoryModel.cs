
namespace ArtifactoryWebApi.Model;

[DebuggerDisplay("{Uri}, IsFolder: {Folder}")]
internal class DirectoryModel
{
    [JsonPropertyName("uri")]
    public Uri? Uri { get; set; }

    [JsonPropertyName("repo")]
    public string? Repo { get; set; }

    [JsonPropertyName("path")]
    public string? Path { get; set; }

    [JsonPropertyName("created")]
    public DateTime? Created { get; set; }

    [JsonPropertyName("createdBy")]
    public string? CreatedBy { get; set; }
}


