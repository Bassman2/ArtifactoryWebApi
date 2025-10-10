namespace ArtifactoryWebApi.Model;

internal class StorageModel
{
    [JsonPropertyName("repo")]
    public string? Repo { get; set; }

    [JsonPropertyName("path")]
    public string? Path { get; set; }

    [JsonPropertyName("created")]
    public DateTime? Created { get; set; }

    [JsonPropertyName("createdBy")]
    public string? CreatedBy { get; set; }

    [JsonPropertyName("lastModified")]
    public DateTime? LastModified { get; set; }

    [JsonPropertyName("modifiedBy")]
    public string? ModifiedBy { get; set; }

    [JsonPropertyName("lastUpdated")]
    public DateTime? LastUpdated { get; set; }

    #region File

    [JsonPropertyName("downloadUri")]
    public Uri? DownloadUri { get; set; }

    [JsonPropertyName("mimeType")]
    public string? MimeType { get; set; }

    [JsonPropertyName("size")]
    public string? Size { get; set; }

    [JsonPropertyName("checksums")]
    public ChecksumsModel? Checksums { get; set; }

    [JsonPropertyName("originalChecksums")]
    public ChecksumsModel? OriginalChecksums { get; set; }

    #endregion

    #region Folder

    [JsonPropertyName("children")]
    public List<ChildModel>? Children { get; set; }

    #endregion

    [JsonPropertyName("uri")]
    public Uri? Uri { get; set; }
}
