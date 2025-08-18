using System;
using System.IO;
using System.Threading;

namespace ArtifactoryWebApi;

/// <summary>
/// Represents a client for interacting with the Artifactory API, providing methods for managing projects, repositories, storage, and more.
/// </summary>
public sealed class Artifactory2 : JsonService
{
    private const string urlPrefix = "/artifactory";
    private const string apiPrefix = "/artifactory/api";

    /// <summary>
    /// Initializes a new instance of the <see cref="Artifactory2"/> class using a store key and application name.
    /// </summary>
    /// <param name="storeKey">The key used to store authentication or configuration data.</param>
    /// <param name="appName">The name of the application using the GitHub API.</param>
    public Artifactory2(string storeKey, string appName) : base(storeKey, appName, SourceGenerationContext.Default)
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="Artifactory2"/> class using a host URI, an optional authenticator, and an application name.
    /// </summary>
    /// <param name="host">The base URI of the GitHub API host.</param>
    /// <param name="authenticator">The authenticator used for API authentication, or <c>null</c> for unauthenticated access.</param>
    /// <param name="appName">The name of the application using the GitHub API.</param>
    public Artifactory2(Uri host, IAuthenticator? authenticator, string appName) : base(host, authenticator, appName, SourceGenerationContext.Default)
    { }

    /// <summary>
    /// Gets the URL used to test authentication with the Artifactory API.
    /// </summary>
    protected override string? AuthenticationTestUrl => "/artifactory/api/repositories"; //"/access/api/v1/system/ping";

    /// <summary>
    /// Handles errors returned from HTTP responses by reading the error content and throwing a <see cref="WebServiceException"/>.
    /// </summary>
    /// <param name="response">The HTTP response message containing the error.</param>
    /// <param name="memberName">The name of the member where the error occurred.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    protected override async Task ErrorHandlingAsync(HttpResponseMessage response, string memberName, CancellationToken cancellationToken)
    {
        JsonTypeInfo<ErrorsModel> jsonTypeInfoOut = (JsonTypeInfo<ErrorsModel>)context.GetTypeInfo(typeof(ErrorsModel))!;
        var error = await response.Content.ReadFromJsonAsync<ErrorsModel>(jsonTypeInfoOut, cancellationToken);
        //var error = await ReadFromJsonAsync<ErrorsModel>(response, cancellationToken);
        throw new WebServiceException(error?.ToString(), response.RequestMessage?.RequestUri, response.StatusCode, response.ReasonPhrase, memberName);

    }

    #region Projects

    /// <summary>
    /// Retrieves a list of all projects in the Artifactory system.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a collection of projects.</returns>
    public async Task<IEnumerable<Project>?> GetProjectsAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = await GetFromJsonAsync<IEnumerable<ProjectModel>>("/access/api/v1/projects", cancellationToken);
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
        WebServiceException.ThrowIfNotConnected(client);

        var res = await GetFromJsonAsync<ProjectModel>($"/access/api/v1/projects/{projectKey}", cancellationToken);
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
        WebServiceException.ThrowIfNotConnected(client);

        var req = new ProjectModel
        {
            ProjectKey = projectKey,
            DisplayName = displayName,
            Description = descriptions,
            AdminPrivileges = new AdminPrivilegesModel { ManageMembers = true, ManageResources = true, IndexResources = true },
            StorageQuotaBytes = 1073741824           // "Project Quota cannot be lower than `1073741824` bytes. Input: 0"
        };
        var res = await PostAsJsonAsync<ProjectModel, ProjectModel>("/access/api/v1/projects", req, cancellationToken);
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
        WebServiceException.ThrowIfNotConnected(client);

        await DeleteAsync($"/access/api/v1/projects/{projectKey}", cancellationToken);
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
        WebServiceException.ThrowIfNotConnected(client);

        var res = await GetFromJsonAsync<IEnumerable<RepositoryModel>>("/artifactory/api/repositories", cancellationToken);
        return res.CastModel<Repository>(this);
    }

    /// <summary>
    /// Retrieves the configuration of a specific repository.
    /// </summary>
    /// <param name="repoKey">The unique key of the repository.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the repository configuration, or null if not found.</returns>
    public async Task<RepositoryConfiguration?> GetRepositoryConfigurationAsync(string repoKey, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = await GetFromJsonAsync<RepositoryConfigurationModel>($"/artifactory/api/repositories/{repoKey}", cancellationToken);
        return res.CastModel<RepositoryConfiguration>();
    }

    //public async Task<Dictionary<string, IEnumerable<RepositoryConfiguration>>?> GetAllRepositoryConfigurationsAsync(CancellationToken cancellationToken = default)
    //{
    //    WebServiceException.ThrowIfNotConnected(client);

    //var res = await GetFromJsonAsync<Dictionary<string, IEnumerable<RepositoryConfigurationModel>>>($"/artifactory/api/repositories/configurations", cancellationToken);

    //    var res = await service.GetAllRepositoryConfigurationsAsync(cancellationToken);

    //    Dictionary<string, IEnumerable<RepositoryConfiguration>>? x = res?.Select(static i => new { i.Key, Value = i.Value.CastModel<RepositoryConfiguration>() }).ToDictionary<string, IEnumerable<RepositoryConfiguration>>(i => i.Key, i => i.Value);

    //    return x;
    //    //.ToDictionary<string, IEnumerable<RepositoryConfiguration>>(i => i.Key, i => i.Value.CastModel<RepositoryConfiguration>());
    //    //return res.CastModel<RepositoryConfiguration>();
    //}

    //public async Task<Repository?> CreateRepositoryAsync(string repoKey, RepositoryType repositoryType, PackageType packageType, string description, CancellationToken cancellationToken = default)
    //{
    //    WebServiceException.ThrowIfNotConnected(client);

    //    var res = await service.CreateRepositoryAsync(repoKey, repositoryType, packageType, description, cancellationToken);
    //    return res.CastModel<Repository>(service);
    //}

    //var create = new RepositoryConfigurationModel()
    //{
    //    Key = repoKey,
    //    RClass = repositoryType.ToString().ToLower(),
    //    PackageType = packageType,
    //    Description = description,
    //};

    //var res = await PutAsJsonAsync<RepositoryConfigurationModel, RepositoryConfigurationModel>($"/artifactory/api/repositories/{repoKey}", create, cancellationToken);


    /// <summary>
    /// Deletes a repository from the Artifactory system.
    /// </summary>
    /// <param name="repoKey">The unique key of the repository to delete.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task DeleteRepositoryAsync(string repoKey, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentNullException.ThrowIfNullOrWhiteSpace(repoKey, nameof(repoKey));

        await DeleteAsync($"/artifactory/api/repositories/{repoKey}", cancellationToken);
    }

    /// <summary>
    /// Updates a repository in the Artifactory system.
    /// </summary>
    /// <param name="repoKey">The unique key of the repository to update.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the updated repository.</returns>
    public async Task<Repository?> UpdateRepositoryAsync(string repoKey, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentNullException.ThrowIfNullOrWhiteSpace(repoKey, nameof(repoKey));

        var update = new RepositoryModel() { Key = repoKey };
        var res = await PostAsJsonAsync<RepositoryModel, RepositoryModel>($"/artifactory/api/repositories/{repoKey}", update, cancellationToken);
        return res.CastModel<Repository>(this);
    }

    /// <summary>
    /// Checks if a repository exists in the Artifactory system.
    /// </summary>
    /// <param name="repoKey">The unique key of the repository.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating whether the repository exists.</returns>
    public async Task<bool> ExistsRepositoryAsync(string repoKey, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentNullException.ThrowIfNullOrWhiteSpace(repoKey, nameof(repoKey));

        var res = await GetFromJsonAsync<RepositoryModel>($"/artifactory/repositories/existence?projectKey={repoKey}", cancellationToken);
        return res is not null;
    }

    #endregion

    #region Storage

    /// <summary>
    /// Retrieves information about a folder in the Artifactory system.
    /// </summary>
    /// <param name="repoKey">The repository where the folder is located.</param>
    /// <param name="path">The path of the folder within the repository.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the folder information.</returns>
    public async Task<Storage?> GetFolderInfoAsync(string repoKey, string path, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentNullException.ThrowIfNullOrWhiteSpace(repoKey, nameof(repoKey));
        ArgumentNullException.ThrowIfNull(path, nameof(path));

        var res = await GetFromJsonAsync<StorageModel>($"/artifactory/api/storage/{repoKey}/{path}", cancellationToken);
        return res.CastModel<Storage>();
    }

    /// <summary>
    /// Retrieves information about a file in the Artifactory system.
    /// </summary>
    /// <param name="repoKey">The repository where the file is located.</param>
    /// <param name="path">The path of the file within the repository.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the file information.</returns>
    public async Task<Storage?> GetFileInfoAsync(string repoKey, string path, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentNullException.ThrowIfNullOrWhiteSpace(repoKey, nameof(repoKey));
        ArgumentNullException.ThrowIfNull(path, nameof(path));

        var res = await GetFromJsonAsync<StorageModel>($"/artifactory/api/storage/{repoKey}/{path}", cancellationToken);
        return res.CastModel<Storage>();
    }

    /// <summary>
    /// Retrieves a list of files in a specific storage location.
    /// </summary>
    /// <param name="repoKey">The repository where the storage location is located.</param>
    /// <param name="path">The path of the storage location within the repository.</param>
    /// <param name="deep">Whether to perform a deep search.</param>
    /// <param name="depth">The depth of the search.</param>
    /// <param name="listFolders">Whether to include folders in the list.</param>
    /// <param name="mdTimestamps">Whether to include metadata timestamps.</param>
    /// <param name="includeRootPath">Whether to include the root path in the list.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the list of files.</returns>
    public async Task<StorageList?> GetFileListAsync(string repoKey, string path, bool deep, int depth, bool listFolders, bool mdTimestamps, bool includeRootPath, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentNullException.ThrowIfNullOrWhiteSpace(repoKey, nameof(repoKey));
        ArgumentNullException.ThrowIfNull(path, nameof(path));

        var requestUri = CombineUrl("/artifactory/api/storage", repoKey, path, ("list", ""), ("deep", deep ? 1 : 0), ("depth", depth), ("listFolders", listFolders ? 1 : 0), ("mdTimestamps", mdTimestamps ? 1 : 0), ("includeRootPath", includeRootPath ? 1 : 0));

        var res = await GetFromJsonAsync<StorageListModel>(requestUri, cancellationToken);
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
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentNullException.ThrowIfNullOrEmpty(repoKey, nameof(repoKey));
        ArgumentNullException.ThrowIfNull(path, nameof(path));

        var res = await GetFromJsonAsync<StorageStatsModel>($"/artifactory/api/storage/{repoKey}/{path}?stats", cancellationToken);
        return res.CastModel<StorageStats>();
    }

    //public async Task<Item?> CreateDirectoryAsync(string repo, string path, string createdBy, CancellationToken cancellationToken = default)
    //{
    //    WebServiceException.ThrowIfNotConnected(client);

    //ArgumentNullException.ThrowIfNullOrEmpty(repo, nameof(repo));
    //    ArgumentNullException.ThrowIfNullOrEmpty(path, nameof(path));
    //    ArgumentNullException.ThrowIfNullOrEmpty(createdBy, nameof(createdBy));

    //    string url = CombineUrl(urlPrefix, repo, path);
    //var create = new DirectoryModel() { Uri = new Uri(Host, url), Repo = repo, Path = path, CreatedBy = createdBy, Created = DateTime.Now };
    //var res = await PutAsJsonAsync<DirectoryModel, DirectoryModel>(url, create, cancellationToken);
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
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentNullException.ThrowIfNullOrEmpty(sourceRepo, nameof(sourceRepo));
        ArgumentNullException.ThrowIfNullOrEmpty(sourcePath, nameof(sourcePath));
        ArgumentNullException.ThrowIfNullOrEmpty(destinationRepo, nameof(destinationRepo));
        ArgumentNullException.ThrowIfNullOrEmpty(destinationPath, nameof(destinationPath));

        string url = CombineUrl(apiPrefix, "/copy", sourceRepo, sourcePath, ("to", CombineUrl(destinationRepo, destinationPath)));
        await PostFromJsonAsync<MessagesRoot>(url, cancellationToken);
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
        ArgumentNullException.ThrowIfNullOrEmpty(sourceRepo, nameof(sourceRepo));
        ArgumentNullException.ThrowIfNullOrEmpty(sourcePath, nameof(sourcePath));
        ArgumentNullException.ThrowIfNullOrEmpty(destinationRepo, nameof(destinationRepo));
        ArgumentNullException.ThrowIfNullOrEmpty(destinationPath, nameof(destinationPath));

        string url = CombineUrl(apiPrefix, "/move", sourceRepo, sourcePath, ("to", CombineUrl(destinationRepo, destinationPath)));
        await PostFromJsonAsync<MessagesRoot>(url, cancellationToken);
    }

    /// <summary>
    /// Deletes an item (file or folder) from a specified repository and path in the Artifactory system.
    /// </summary>
    /// <param name="repoKey">The name of the repository where the item is located.</param>
    /// <param name="path">The path of the item within the repository to be deleted.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task DeleteAsync(string repoKey, string path, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);

        ArgumentNullException.ThrowIfNullOrEmpty(repoKey, nameof(repoKey));
        ArgumentNullException.ThrowIfNull(path, nameof(path));

        string url = CombineUrl(urlPrefix, repoKey, path);
        await DeleteAsync(url, cancellationToken);
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
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentNullException.ThrowIfNullOrEmpty(repo, nameof(repo));
        ArgumentNullException.ThrowIfNull(path, nameof(path));

        string url = CombineUrl("/artifactory/api/storage", repo, path);
        var res = await FoundAsync(url, cancellationToken);
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
        WebServiceException.ThrowIfNotConnected(client);

        var res = await GetFromJsonAsync<StorageInfoModel>("/artifactory/api/storageinfo", cancellationToken);
        return res.CastModel<StorageInfo>();
    }

    /// <summary>
    /// Refreshes the storage information for the Artifactory system.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task RefreshStorageInfoAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);

        await PostAsync("/artifactory/api/storageinfo/calculate", cancellationToken);
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
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentNullException.ThrowIfNullOrEmpty(repo, nameof(repo));
        ArgumentNullException.ThrowIfNull(path, nameof(path));
        ArgumentNullException.ThrowIfNullOrEmpty(filePath, nameof(filePath));

        string url = CombineUrl(urlPrefix, repo, path);
        await DownloadAsync(url, filePath, cancellationToken);
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
        WebServiceException.ThrowIfNotConnected(client);

        ArgumentNullException.ThrowIfNullOrEmpty(filePath, nameof(filePath));

        await DownloadAsync(url, filePath, cancellationToken);
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
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentNullException.ThrowIfNullOrEmpty(repo, nameof(repo));
        ArgumentNullException.ThrowIfNull(path, nameof(path));

        string url = CombineUrl(urlPrefix, repo, path);
        return await GetFromStreamAsync(url, cancellationToken);
    }

    /// <summary>
    /// Retrieves a file stream from a specified URL.
    /// </summary>
    /// <param name="url">The URL of the file to retrieve.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the file stream.</returns>
    public async Task<System.IO.Stream> GetFileStreamAsync(Uri url, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);
        ArgumentNullException.ThrowIfNullOrEmpty(url.ToString(), nameof(url));

        return await GetFromStreamAsync(url.ToString(), cancellationToken);
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
        WebServiceException.ThrowIfNotConnected(client);

        ArgumentNullException.ThrowIfNullOrEmpty(repo, nameof(repo));
        ArgumentNullException.ThrowIfNullOrEmpty(path, nameof(path));
        ArgumentNullException.ThrowIfNullOrEmpty(filePath, nameof(filePath));

        //var req = new MultipartFormDataContent();
        using var stream = System.IO.File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);

        await UploadFileAsync(repo, path, stream, cancellationToken);
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
        WebServiceException.ThrowIfNotConnected(client);

        ArgumentNullException.ThrowIfNullOrEmpty(repo, nameof(repo));
        ArgumentNullException.ThrowIfNullOrEmpty(path, nameof(path));

        // do not use MultipartFormDataContent

        //var req = new MultipartFormDataContent();
        //string filename = System.IO.Path.GetFileName(path);
        //req.Add(new StreamContent(stream), "file", filename);

        var req = new StreamContent(fileStream);
        string url = CombineUrl(urlPrefix, repo, path);
        await PutAsync(url, req, cancellationToken);
    }

    #endregion

    /// <summary>
    /// Retrieves the version information of the Artifactory system.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains the <see cref="ArtifactoryVersion"/> information, or null if not available.
    /// </returns>

    public override async Task<string?> GetVersionStringAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);

        //client?.DefaultRequestHeaders.Accept.ParseAdd("application/vnd.org.jfrog.artifactory.system.Version+json");

        var res = await GetFromJsonAsync<ArtifactoryVersionModel>("/artifactory/api/system/version", cancellationToken);
        return res != null ? $"{res.Version}.{res.Revision}" : null;
    }

    //public async Task<ArtifactoryVersion?> GetVersionAsync(CancellationToken cancellationToken = default)
    //{
    //    WebServiceException.ThrowIfNotConnected(client);

    //    var res = await service.GetVersionAsync(cancellationToken);
    //    return res.CastModel<ArtifactoryVersion>(); 
    //}

    //public async Task GetXrayVersionAsync(CancellationToken cancellationToken = default)
    //{
    //    WebServiceException.ThrowIfNotConnected(client);

    //    await service.GetXrayVersionAsync(cancellationToken);
    //    //return res.CastModel<JFrogVersion>();
    //}

}
