﻿namespace ArtifactoryWebApi;

public sealed class Artifactory : IDisposable
{
    private ArtifactoryService? service;

    public Artifactory(string storeKey)
    {
        var key = WebServiceClient.Store.KeyStore.Key(storeKey)!;
        string host = key.Host!;
        string token = key.Token!;
        service = new(new Uri(host), token);
    }

    public Artifactory(Uri uri, string apiKey)
    {
        service = new(uri, apiKey);
    }

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

    public async Task<IEnumerable<Project>?> GetProjectsAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetProjectsAsync(cancellationToken);
        return res.CastModel<Project>();
    }

    public async Task<Project?> GetProjectAsync(string projectKey, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetProjectAsync(projectKey, cancellationToken);
        return res.CastModel<Project>();
    }

    public async Task<Project?> CreateProjectAsync(string projectKey, string displayName, string descriptions, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.CreateProjectAsync(projectKey, displayName, descriptions, cancellationToken);
        return res.CastModel<Project>();
    }

    public async Task DeleteProjectAsync(string projectKey, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        await service.DeleteProjectAsync(projectKey, cancellationToken);
    }

    #endregion

    #region Repositories

    public async Task<IEnumerable<Repository>?> GetRepositoriesAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetRepositoriesAsync(cancellationToken);
        return res.CastModel<Repository>(service);
    }

    public async Task<RepositoryInfo?> GetRepositoryAsync(string repoKey, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetRepositoryAsync(repoKey, cancellationToken);
        return res.CastModel<RepositoryInfo>();
    }

    public async Task<Repository?> CreateRepositoryAsync(string repoKey, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.CreateRepositoryAsync(repoKey, cancellationToken);
        return res.CastModel<Repository>(service);
    }

    public async Task DeleteRepositoryAsync(string repoKey, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        await service.DeleteRepositoryAsync(repoKey, cancellationToken);
    }

    public async Task<Repository?> UpdateRepositoryAsync(string repoKey, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.UpdateRepositoryAsync(repoKey, cancellationToken);
        return res.CastModel<Repository>(service);
    }
    public async Task<bool> ExistsRepositoryAsync(string repoKey, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.ExistsRepositoryAsync(repoKey, cancellationToken);
        return res;
    }

    #endregion

    #region Storage

    public async Task<Storage?> GetFolderInfoAsync(string repo, string path, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetFolderInfoAsync(repo, path, cancellationToken);
        return res.CastModel<Storage>();
    }

    public async Task<Storage?> GetFileInfoAsync(string repo, string path, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetFileInfoAsync(repo, path, cancellationToken);
        return res.CastModel<Storage>();
    }

    public async Task<StorageList?> GetFileListAsync(string repo, string path, bool deep, int depth, bool listFolders, bool mdTimestamps, bool includeRootPath, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetFileListAsync(repo, path, deep, depth, listFolders, mdTimestamps, includeRootPath, cancellationToken);
        return res.CastModel<StorageList>();
    }

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

    public async Task CopyAsync(string sourceRepo, string sourcePath, string destinationRepo, string destinationPath, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        await service.CopyItemAsync(sourceRepo, sourcePath, destinationRepo, destinationPath, cancellationToken);
    }

    public async Task MoveAsync(string sourceRepo, string sourcePath, string destinationRepo, string destinationPath, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        await service.MoveItemAsync(sourceRepo, sourcePath, destinationRepo, destinationPath, cancellationToken);
    }

    public async Task DeleteAsync(string repo, string path, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        await service.DeleteItemAsync(repo, path, cancellationToken);
    }

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

    public async Task<StorageInfo?> GetStorageInfoAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetStorageInfoAsync(cancellationToken);
        return res.CastModel<StorageInfo>();
    }

    public async Task RefreshStorageInfoAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        await service.RefreshStorageInfoAsync(cancellationToken);
    }

    #endregion

    #region Download & Upload

    public async Task DownloadFileAsync(string repo, string path, string filePath, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        await service.DownloadFileAsync(repo, path, filePath, cancellationToken);
    }

    public async Task DownloadFileAsync(Uri url, string filePath, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        await service.DownloadFileAsync(url, filePath, cancellationToken);
    }

    public async Task<System.IO.Stream> GetFileStreamAsync(string repo, string path, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        return await service.GetFileStreamAsync(repo, path, cancellationToken);
    }

    public async Task<System.IO.Stream> GetFileStreamAsync(Uri url, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        return await service.GetFileStreamAsync(url, cancellationToken);
    }

    public async Task UploadFileAsync(string repo, string path, string fileName, string filePath, CancellationToken cancellationToken = default)
    { 
        WebServiceException.ThrowIfNullOrNotConnected(service);

        await service.UploadFileAsync(repo, path, fileName, filePath, cancellationToken);
    }
    
    #endregion

   
}
