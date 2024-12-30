namespace ArtifactoryWebApi.Service.Model;

internal class ChildModel
{
    // only file or folder name "/folder" or "/file.txt"
    [JsonPropertyName("uri")]
    public string? Uri { get; set; }

    [JsonPropertyName("folder")]
    public bool IsFolder { get; set; }
}
