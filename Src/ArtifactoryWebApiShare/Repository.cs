namespace ArtifactoryWebApi;

[DebuggerDisplay("{Type} {PackageType} {Key}")]
public class Repository
{
    private readonly ArtifactoryService service;

    internal Repository(ArtifactoryService service, RepositoryModel model)
    {
        this.service = service;

        this.Key = model.Key!;
        this.Description = model.Description;
        this.Type = model.Type;
        this.Url = model.Url;
        this.PackageType = model.PackageType;
    }

    public string Key { get; }

    public string? Description { get; }

    public RepositoryType Type { get; }

    public Uri? Url { get; }

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
