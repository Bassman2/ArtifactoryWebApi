namespace ArtifactoryWebApi;

/// <summary>
/// Represents a repository in the Artifactory system, including its metadata and configuration.
/// </summary>
[DebuggerDisplay("{Type} {PackageType} {Key}")]
public class Repository
{
    private readonly ArtifactoryService service;

    /// <summary>
    /// Initializes a new instance of the <see cref="Repository"/> class.
    /// </summary>
    /// <param name="service">The Artifactory service used to interact with the repository.</param>
    /// <param name="model">The model containing the repository's data.</param>
    internal Repository(ArtifactoryService service, RepositoryModel model)
    {
        this.service = service;

        this.Key = model.Key!;
        this.Description = model.Description;
        this.Type = model.Type;
        this.Url = model.Url;
        this.PackageType = model.PackageType;
    }

    /// <summary>
    /// Gets the unique key of the repository.
    /// </summary>
    public string Key { get; }

    /// <summary>
    /// Gets the description of the repository.
    /// </summary>
    public string? Description { get; }

    /// <summary>
    /// Gets the type of the repository (e.g., local, remote, virtual).
    /// </summary>
    public RepositoryType Type { get; }

    /// <summary>
    /// Gets the URL of the repository.
    /// </summary>
    public Uri? Url { get; }

    /// <summary>
    /// Gets the type of packages stored in the repository (e.g., Maven, Docker, NPM).
    /// </summary>
    public PackageType PackageType { get; }

    //public async Task<IEnumerable<Item>?> GetItemsAsync(string path, CancellationToken cancellationToken = default)
    //{
    //    WebServiceException.ThrowIfNullOrNotConnected(service);

    //    var res = await this.service.GetItemsAsync<Item>(this.Key, path, null, cancellationToken);
    //    return res; 
    //}
    
    //public async Task<IEnumerable<Item>?> GetItemsAsync(string path, string searchPattern, CancellationToken cancellationToken = default)
    //{
    //    WebServiceException.ThrowIfNullOrNotConnected(service);

    //    var res = await this.service.GetItemsAsync<Item>(this.Key, path, searchPattern, cancellationToken);
    //    return res;
    //}

    //public async Task<IEnumerable<File>?> GetFilesAsync(string path, CancellationToken cancellationToken = default)
    //{
    //    WebServiceException.ThrowIfNullOrNotConnected(service);
        
    //    var res = await this.service.GetItemsAsync<File>(this.Key, path, null, cancellationToken);
    //    return res;
    //}

    //public async Task<IEnumerable<File>?> GetFilesAsync(string path, string searchPattern, CancellationToken cancellationToken = default)
    //{
    //    WebServiceException.ThrowIfNullOrNotConnected(service);

    //    var res = await this.service.GetItemsAsync<File>(this.Key, path, searchPattern, cancellationToken);
    //    return res;
    //}

    //public async Task<IEnumerable<Folder>?> GetFoldersAsync(string path, CancellationToken cancellationToken = default)
    //{
    //    WebServiceException.ThrowIfNullOrNotConnected(service);

    //    var res = await this.service.GetItemsAsync<Folder>(this.Key, path, null, cancellationToken);
    //    return res;
    //}

    //public async Task<IEnumerable<Folder>?> GetFoldersAsync(string path, string searchPattern, CancellationToken cancellationToken = default)
    //{
    //    WebServiceException.ThrowIfNullOrNotConnected(service);

    //    var res = await this.service.GetItemsAsync<Folder>(this.Key, path, searchPattern, cancellationToken);
    //    return res;
    //}

    //public async Task CopyAsync(string sourcePath, string destinationRepo, string destinationPath, CancellationToken cancellationToken = default)
    //{
    //    WebServiceException.ThrowIfNullOrNotConnected(service);

    //    await this.service!.CopyItemAsync(this.Key, sourcePath, destinationRepo, destinationPath, cancellationToken);
    //}

    //public async Task MoveAsync(string sourcePath, string destinationRepo, string destinationPath, CancellationToken cancellationToken = default)
    //{
    //    WebServiceException.ThrowIfNullOrNotConnected(service);

    //    await this.service!.MoveItemAsync(this.Key, sourcePath, destinationRepo, destinationPath, cancellationToken);
    //}

    //public async Task DeleteAsync(string path, CancellationToken cancellationToken = default)
    //{
    //    WebServiceException.ThrowIfNullOrNotConnected(service);

    //    await this.service!.DeleteItemAsync(this.Key, path, cancellationToken);
    //}

    //public async Task<FileInfo?> GetFileInfoAsync(string path, CancellationToken cancellationToken = default)
    //{
    //    WebServiceException.ThrowIfNullOrNotConnected(service);

    //    var res = await service!.GetFileInfoAsync(this.Key, path, cancellationToken);
    //    return res;
    //}

    //public async Task<FolderInfo?> GetFolderInfoAsync(string path, CancellationToken cancellationToken = default)
    //{
    //    WebServiceException.ThrowIfNullOrNotConnected(service);

    //    var res = await service!.GetFolderInfoAsync(this.Key, path, cancellationToken);
    //    return res;
    //}

    //public async Task DownloadFileAsync(string path, string filePath, CancellationToken cancellationToken = default)
    //{
    //    WebServiceException.ThrowIfNullOrNotConnected(service);

    //    await this.service!.DownloadFileAsync(this.Key, path, filePath, cancellationToken);
    //}

    //public async Task UploadFileAsync(string path, string fileName, string filePath, CancellationToken cancellationToken = default)
    //{
    //    WebServiceException.ThrowIfNullOrNotConnected(service);

    //    await service!.UploadFileAsync(this.Key, path, fileName, filePath, cancellationToken);
    //}
}
