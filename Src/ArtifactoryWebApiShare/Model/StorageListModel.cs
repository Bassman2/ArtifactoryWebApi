namespace ArtifactoryWebApi.Model;

[DebuggerDisplay("{Uri}, Num: {Files.Count}")]
internal class StorageListModel
{
    [JsonPropertyName("uri")]
    public Uri? Uri { get; set; }

    [JsonPropertyName("created")]
    public DateTime? Created { get; set; }

    [JsonPropertyName("files")]
    public List<FileModel>? Files { get; set; }


}
