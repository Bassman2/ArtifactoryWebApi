namespace ArtifactoryWebApi;

/// <summary>
/// Represents a client for interacting with the Artifactory API, providing methods for managing projects, repositories, storage, and more.
/// </summary>
public sealed class Artifactory : IDisposable
{
    private ArtifactoryService? service;

    /// <summary>
    /// Initializes a new instance of the <see cref="Artifactory"/> class using a store key and application name.
    /// </summary>
    /// <param name="storeKey">The key to retrieve the host and token from the key store.</param>
    /// <param name="appName">The name of the application.</param>
    public Artifactory(string storeKey, string appName)
        : this(new Uri(KeyStore.Key(storeKey)?.Host!), KeyStore.Key(storeKey)!.Token!, appName)
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="Artifactory"/> class with the specified host, token, and application name.
    /// </summary>
    /// <param name="host">The base URI of the Artifactory server.</param>
    /// <param name="token">The authentication token for accessing the Artifactory API.</param>
    /// <param name="appName">The name of the application.</param>
    public Artifactory(Uri host, string token, string appName)
    {
        service = new(host, 
            new MultiAuthenticator(
                new BearerAuthenticator(token),
                new ApiKeyAuthenticator("X-JFrog-Art-Api", token)), 
            appName);
    }

    /// <summary>
    /// Releases the resources used by the <see cref="Artifactory"/> instance.
    /// </summary>
    public void Dispose()
    {
        if (this.service != null)
        {
            this.service.Dispose();
            this.service = null;
        }
        GC.SuppressFinalize(this);
    }

    #region Projects

    /// <summary>
    /// Retrieves a list of all projects in the Artifactory system.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a collection of projects.</returns>
    public async Task<IEnumerable<Project>?> GetProjectsAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetProjectsAsync(cancellationToken);
        return res.CastModel<Project>();
    }

    /// <summary>
    /// Retrieves a specific project by its key.
    /// </summary>
    /// <param name="projectKey">The unique key of the project.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the project, or null if not found.</returns>
    public async Task<Project?> GetProjectAsync(string projectKey, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetProjectAsync(projectKey, cancellationToken);
        return res.CastModel<Project>();
    }

    /// <summary>
    /// Creates a new project in the Artifactory system.
    /// </summary>
    /// <param name="projectKey">The unique key for the new project.</param>
    /// <param name="displayName">The display name of the project.</param>
    /// <param name="descriptions">The description of the project.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the created project.</returns>
    public async Task<Project?> CreateProjectAsync(string projectKey, string displayName, string descriptions, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.CreateProjectAsync(projectKey, displayName, descriptions, cancellationToken);
        return res.CastModel<Project>();
    }

    /// <summary>
    /// Deletes a project from the Artifactory system.
    /// </summary>
    /// <param name="projectKey">The unique key of the project to delete.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task DeleteProjectAsync(string projectKey, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        await service.DeleteProjectAsync(projectKey, cancellationToken);
    }

    #endregion

    #region Repositories

    /// <summary>
    /// Retrieves a list of all repositories in the Artifactory system.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a collection of repositories.</returns>
    public async Task<IEnumerable<Repository>?> GetRepositoriesAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetRepositoriesAsync(cancellationToken);
        return res.CastModel<Repository>(service);
    }

    /// <summary>
    /// Retrieves the configuration of a specific repository.
    /// </summary>
    /// <param name="repoKey">The unique key of the repository.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the repository configuration, or null if not found.</returns>
    public async Task<RepositoryConfiguration?> GetRepositoryConfigurationAsync(string repoKey, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetRepositoryConfigurationAsync(repoKey, cancellationToken);
        return res.CastModel<RepositoryConfiguration>();
    }

    //public async Task<Dictionary<string, IEnumerable<RepositoryConfiguration>>?> GetAllRepositoryConfigurationsAsync(CancellationToken cancellationToken = default)
    //{
    //    WebServiceException.ThrowIfNullOrNotConnected(service);

    //    var res = await service.GetAllRepositoryConfigurationsAsync(cancellationToken);

    //    Dictionary<string, IEnumerable<RepositoryConfiguration>>? x = res?.Select(static i => new { i.Key, Value = i.Value.CastModel<RepositoryConfiguration>() }).ToDictionary<string, IEnumerable<RepositoryConfiguration>>(i => i.Key, i => i.Value);

    //    return x;
    //    //.ToDictionary<string, IEnumerable<RepositoryConfiguration>>(i => i.Key, i => i.Value.CastModel<RepositoryConfiguration>());
    //    //return res.CastModel<RepositoryConfiguration>();
    //}

    //public async Task<Repository?> CreateRepositoryAsync(string repoKey, RepositoryType repositoryType, PackageType packageType, string description, CancellationToken cancellationToken = default)
    //{
    //    WebServiceException.ThrowIfNullOrNotConnected(service);

    //    var res = await service.CreateRepositoryAsync(repoKey, repositoryType, packageType, description, cancellationToken);
    //    return res.CastModel<Repository>(service);
    //}

    /// <summary>
    /// Deletes a repository from the Artifactory system.
    /// </summary>
    /// <param name="repoKey">The unique key of the repository to delete.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task DeleteRepositoryAsync(string repoKey, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        await service.DeleteRepositoryAsync(repoKey, cancellationToken);
    }

    /// <summary>
    /// Updates a repository in the Artifactory system.
    /// </summary>
    /// <param name="repoKey">The unique key of the repository to update.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the updated repository.</returns>
    public async Task<Repository?> UpdateRepositoryAsync(string repoKey, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.UpdateRepositoryAsync(repoKey, cancellationToken);
        return res.CastModel<Repository>(service);
    }

    /// <summary>
    /// Checks if a repository exists in the Artifactory system.
    /// </summary>
    /// <param name="repoKey">The unique key of the repository.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating whether the repository exists.</returns>
    public async Task<bool> ExistsRepositoryAsync(string repoKey, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.ExistsRepositoryAsync(repoKey, cancellationToken);
        return res;
    }

    #endregion

    #region Storage

    /// <summary>
    /// Retrieves information about a folder in the Artifactory system.
    /// </summary>
    /// <param name="repo">The repository where the folder is located.</param>
    /// <param name="path">The path of the folder within the repository.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the folder information.</returns>
    public async Task<Storage?> GetFolderInfoAsync(string repo, string path, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetFolderInfoAsync(repo, path, cancellationToken);
        return res.CastModel<Storage>();
    }

    /// <summary>
    /// Retrieves information about a file in the Artifactory system.
    /// </summary>
    /// <param name="repo">The repository where the file is located.</param>
    /// <param name="path">The path of the file within the repository.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the file information.</returns>
    public async Task<Storage?> GetFileInfoAsync(string repo, string path, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetFileInfoAsync(repo, path, cancellationToken);
        return res.CastModel<Storage>();
    }

    /// <summary>
    /// Retrieves a list of files in a specific storage location.
    /// </summary>
    /// <param name="repo">The repository where the storage location is located.</param>
    /// <param name="path">The path of the storage location within the repository.</param>
    /// <param name="deep">Whether to perform a deep search.</param>
    /// <param name="depth">The depth of the search.</param>
    /// <param name="listFolders">Whether to include folders in the list.</param>
    /// <param name="mdTimestamps">Whether to include metadata timestamps.</param>
    /// <param name="includeRootPath">Whether to include the root path in the list.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the list of files.</returns>
    public async Task<StorageList?> GetFileListAsync(string repo, string path, bool deep, int depth, bool listFolders, bool mdTimestamps, bool includeRootPath, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetFileListAsync(repo, path, deep, depth, listFolders, mdTimestamps, includeRootPath, cancellationToken);
        return res.CastModel<StorageList>();
    }

    /// <summary>
    /// Retrieves statistics about a file in the Artifactory system.
    /// </summary>
    /// <param name="repoKey">The repository where the file is located.</param>
    /// <param name="path">The path of the file within the repository.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the file statistics.</returns>
    public async Task<StorageStats?> GetFileStatisticsAsync(string repoKey, string path, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetFileStatisticsAsync(repoKey, path, cancellationToken);
        return res.CastModel<StorageStats>();
    }

    //public async Task<Item?> CreateDirectoryAsync(string repo, string path, string createdBy, CancellationToken cancellationToken = default)
    //{
    //    WebServiceException.ThrowIfNullOrNotConnected(service);

    //    var res = await service.CreateDirectoryAsync(repo, path, createdBy, cancellationToken);
    //    return res.CastModel<Item>(); 
    //}


    /// <summary>
    /// Copies an item (file or folder) from a source repository and path to a destination repository and path in the Artifactory system.
    /// </summary>
    /// <param name="sourceRepo">The name of the source repository where the item is currently located.</param>
    /// <param name="sourcePath">The path of the item within the source repository.</param>
    /// <param name="destinationRepo">The name of the destination repository where the item will be copied.</param>
    /// <param name="destinationPath">The path within the destination repository where the item will be copied.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task CopyAsync(string sourceRepo, string sourcePath, string destinationRepo, string destinationPath, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        await service.CopyItemAsync(sourceRepo, sourcePath, destinationRepo, destinationPath, cancellationToken);
    }

    /// <summary>
    /// Moves an item (file or folder) from a source repository and path to a destination repository and path in the Artifactory system.
    /// </summary>
    /// <param name="sourceRepo">The name of the source repository where the item is currently located.</param>
    /// <param name="sourcePath">The path of the item within the source repository.</param>
    /// <param name="destinationRepo">The name of the destination repository where the item will be moved.</param>
    /// <param name="destinationPath">The path within the destination repository where the item will be moved.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task MoveAsync(string sourceRepo, string sourcePath, string destinationRepo, string destinationPath, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        await service.MoveItemAsync(sourceRepo, sourcePath, destinationRepo, destinationPath, cancellationToken);
    }

    /// <summary>
    /// Deletes an item (file or folder) from a specified repository and path in the Artifactory system.
    /// </summary>
    /// <param name="repo">The name of the repository where the item is located.</param>
    /// <param name="path">The path of the item within the repository to be deleted.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task DeleteAsync(string repo, string path, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        await service.DeleteItemAsync(repo, path, cancellationToken);
    }

    /// <summary>
    /// Checks if an item (file or folder) exists in a specified repository and path in the Artifactory system.
    /// </summary>
    /// <param name="repo">The name of the repository where the item is located.</param>
    /// <param name="path">The path of the item within the repository to check for existence.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating whether the item exists.</returns>
    public async Task<bool> ExistsAsync(string repo, string path, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.ExistsAsync(repo, path, cancellationToken);
        return res;
    }

    #endregion

    #region ItemInfo



    #endregion

    #region StorageInfo

    /// <summary>
    /// Retrieves storage information for the Artifactory system, including repository summaries, file store details, and binary statistics.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the storage information.</returns>
    public async Task<StorageInfo?> GetStorageInfoAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetStorageInfoAsync(cancellationToken);
        return res.CastModel<StorageInfo>();
    }

    /// <summary>
    /// Refreshes the storage information for the Artifactory system.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task RefreshStorageInfoAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        await service.RefreshStorageInfoAsync(cancellationToken);
    }

    #endregion

    #region Download & Upload

    /// <summary>
    /// Downloads a file from the Artifactory system to a specified local path.
    /// </summary>
    /// <param name="repo">The repository where the file is located.</param>
    /// <param name="path">The path of the file within the repository.</param>
    /// <param name="filePath">The local file path to save the downloaded file.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task DownloadFileAsync(string repo, string path, string filePath, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        await service.DownloadFileAsync(repo, path, filePath, cancellationToken);
    }

    /// <summary>
    /// Downloads a file from a specified URL to a local path.
    /// </summary>
    /// <param name="url">The URL of the file to download.</param>
    /// <param name="filePath">The local file path to save the downloaded file.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>

    public async Task DownloadFileAsync(Uri url, string filePath, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        await service.DownloadFileAsync(url, filePath, cancellationToken);
    }

    /// <summary>
    /// Retrieves a file stream from the Artifactory system.
    /// </summary>
    /// <param name="repo">The repository where the file is located.</param>
    /// <param name="path">The path of the file within the repository.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the file stream.</returns>
    public async Task<System.IO.Stream> GetFileStreamAsync(string repo, string path, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        return await service.GetFileStreamAsync(repo, path, cancellationToken);
    }

    /// <summary>
    /// Retrieves a file stream from a specified URL.
    /// </summary>
    /// <param name="url">The URL of the file to retrieve.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the file stream.</returns>
    public async Task<System.IO.Stream> GetFileStreamAsync(Uri url, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        return await service.GetFileStreamAsync(url, cancellationToken);
    }

    /// <summary>
    /// Uploads a file to the Artifactory system from a local path.
    /// </summary>
    /// <param name="repo">The repository where the file will be uploaded.</param>
    /// <param name="path">The path within the repository to upload the file.</param>
    /// <param name="filePath">The local file path of the file to upload.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task UploadFileAsync(string repo, string path, string filePath, CancellationToken cancellationToken = default)
    { 
        WebServiceException.ThrowIfNullOrNotConnected(service);

        await service.UploadFileAsync(repo, path, filePath, cancellationToken);
    }

    /// <summary>
    /// Uploads a file to the Artifactory system from a stream.
    /// </summary>
    /// <param name="repo">The repository where the file will be uploaded.</param>
    /// <param name="path">The path within the repository to upload the file.</param>
    /// <param name="fileStream">The stream containing the file data to upload.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task UploadFileAsync(string repo, string path, Stream fileStream, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        await service.UploadFileAsync(repo, path, fileStream, cancellationToken);
    }

    #endregion


}
