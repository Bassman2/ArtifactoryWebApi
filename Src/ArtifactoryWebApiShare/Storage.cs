namespace ArtifactoryWebApi;

public class Storage
{
    internal Storage(StorageModel model)
    {
        this.Repo = model.Repo;
        this.Path = model.Path;
        this.Created = model.Created;
        this.CreatedBy = model.CreatedBy;
        this.LastModified = model.LastModified;
        this.ModifiedBy = model.ModifiedBy;
        this.LastUpdated = model.LastUpdated;
        this.DownloadUri = model.DownloadUri!;
        this.MimeType = model.MimeType;
        this.Size = model.Size;
        this.Checksums = model.Checksums.CastModel<Checksums>();
        this.OriginalChecksums = model.OriginalChecksums.CastModel<Checksums>();
        this.Children = model.Children.CastModel<Child>();
        this.Uri = model.Uri;

        this.Name = model.Path?.Substring(model.Path.LastIndexOf('/') + 1);
    }

    public string? Name { get; }

    public string? Repo { get; }

    public string? Path { get; }

    public DateTime? Created { get; }

    public string? CreatedBy { get; }

    public DateTime? LastModified { get; }

    public string? ModifiedBy { get; }

    public DateTime? LastUpdated { get; }

    #region File

    public Uri DownloadUri { get; }

    public string? MimeType { get; }

    public string? Size { get; }

    public Checksums? Checksums { get; }

    public Checksums? OriginalChecksums { get; }

    #endregion

    #region Folder
    
    public List<Child>? Children { get; }

    #endregion

    public Uri? Uri { get; }
}
