using System;

namespace ArtifactoryWebApi.Service;

// https://jfrog.com/help/r/jfrog-rest-apis/get-folder-info


internal class ArtifactoryService(Uri host, IAuthenticator? authenticator, string appName)
    : JsonService(host, authenticator, appName, SourceGenerationContext.Default)
{
    private const string urlPrefix = "/artifactory";
    private const string apiPrefix = "/artifactory/api";

    // application/json (application/vnd.org.jfrog.artifactory.storage.ItemCreated+json)

    protected override string? AuthenticationTestUrl => "/artifactory/api/repositories"; //"/access/api/v1/system/ping";

    protected override async Task ErrorHandlingAsync(HttpResponseMessage response, string memberName, CancellationToken cancellationToken)
    {
        JsonTypeInfo<ErrorsModel> jsonTypeInfoOut = (JsonTypeInfo<ErrorsModel>)context.GetTypeInfo(typeof(ErrorsModel))!;
        var error = await response.Content.ReadFromJsonAsync<ErrorsModel>(jsonTypeInfoOut, cancellationToken);

        //var error = await ReadFromJsonAsync<ErrorsModel>(response, cancellationToken);
        throw new WebServiceException(error?.ToString(), response.RequestMessage?.RequestUri, response.StatusCode, response.ReasonPhrase, memberName);
    }

/*
    public override async Task<Version> GetVersionAsync(CancellationToken cancellationToken)
    {
        string ver = await GetVersionStringAsync(cancellationToken);
        return new Version(ver);
    }

    public override async Task<string> GetVersionStringAsync(CancellationToken cancellationToken)
    {
        client?.DefaultRequestHeaders.Accept.ParseAdd("application/vnd.org.jfrog.artifactory.system.Version+json");

        var res = await GetFromJsonAsync<ArtifactoryVersionModel>("/artifactory/api/system/version", cancellationToken);
        return $"{res!.Version}.{res.Revision}";
    }
*/
    #region Projects

    public async Task<IEnumerable<ProjectModel>?> GetProjectsAsync(CancellationToken cancellationToken)
    {
        var res = await GetFromJsonAsync<IEnumerable<ProjectModel>>("/access/api/v1/projects", cancellationToken);
        return res;
    }

    public async Task<ProjectModel?> GetProjectAsync(string projectKey, CancellationToken cancellationToken)
    {
        var res = await GetFromJsonAsync<ProjectModel>($"/access/api/v1/projects/{projectKey}", cancellationToken);
        return res;
    }

    public async Task<ProjectModel?> CreateProjectAsync(string projectKey, string displayName, string descriptions, CancellationToken cancellationToken)
    {
        var req = new ProjectModel { ProjectKey = projectKey, DisplayName = displayName, Description = descriptions, AdminPrivileges = new AdminPrivilegesModel { ManageMembers = true, ManageResources = true, IndexResources = true }, 
            StorageQuotaBytes = 1073741824           // "Project Quota cannot be lower than `1073741824` bytes. Input: 0"
        };
        var res = await PostAsJsonAsync<ProjectModel, ProjectModel>("/access/api/v1/projects", req, cancellationToken);
        return res;
    }

    public async Task DeleteProjectAsync(string projectKey, CancellationToken cancellationToken)
    {
        await DeleteAsync($"/access/api/v1/projects/{projectKey}", cancellationToken);
    }

    #endregion

    #region Repositories

    public async Task<IEnumerable<RepositoryModel>?> GetRepositoriesAsync(CancellationToken cancellationToken)
    {
        var res = await GetFromJsonAsync<IEnumerable<RepositoryModel>>("/artifactory/api/repositories", cancellationToken);
        return res;
    }

    public async Task<RepositoryConfigurationModel?> GetRepositoryConfigurationAsync(string repoKey,  CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNullOrWhiteSpace(repoKey, nameof(repoKey));

        var res = await GetFromJsonAsync<RepositoryConfigurationModel>($"/artifactory/api/repositories/{repoKey}", cancellationToken);
        return res;
    }

    public async Task<Dictionary<string, IEnumerable<RepositoryConfigurationModel>>?> GetAllRepositoryConfigurationsAsync(CancellationToken cancellationToken)
    {
        var res = await GetFromJsonAsync<Dictionary<string, IEnumerable<RepositoryConfigurationModel>>>($"/artifactory/api/repositories/configurations", cancellationToken);
        return res;
    }

    public async Task<RepositoryModel?> CreateRepositoryAsync(string repoKey, RepositoryType repositoryType, PackageType packageType, string description, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNullOrWhiteSpace(repoKey, nameof(repoKey));

        //var create = new RepositoryModel() 
        //{ 
        //    Key = repoKey,
        //    Type = repositoryType,
        //    PackageType = packageType,
        //    Description = description,
        //    Url = new Uri(this.Host, $"/artifactory/{repoKey}")
        //};

        var create = new RepositoryConfigurationModel()
        {
            Key = repoKey,
            RClass = repositoryType.ToString().ToLower(),
            PackageType = packageType,
            Description = description,
        };

        var res = await PutAsJsonAsync<RepositoryConfigurationModel, RepositoryConfigurationModel>($"/artifactory/api/repositories/{repoKey}", create, cancellationToken);
        return null;
    }

    public async Task DeleteRepositoryAsync(string repoKey, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNullOrWhiteSpace(repoKey, nameof(repoKey));

        await DeleteAsync($"/artifactory/api/repositories/{repoKey}", cancellationToken);
    }

    public async Task<RepositoryModel?> UpdateRepositoryAsync(string repoKey, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNullOrWhiteSpace(repoKey, nameof(repoKey));

        var update = new RepositoryModel() { Key = repoKey };

        var res = await PostAsJsonAsync<RepositoryModel, RepositoryModel>($"/artifactory/api/repositories/{repoKey}", update, cancellationToken);
        return res;
    }

    public async Task<bool> ExistsRepositoryAsync(string repoKey, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNullOrWhiteSpace(repoKey, nameof(repoKey));

        var res = await GetFromJsonAsync<RepositoryModel>($"/artifactory/repositories/existence?projectKey={repoKey}", cancellationToken);
        return res is not null;
    }

    #endregion

    #region Files & Folders

    // https://jfrog.com/help/r/jfrog-rest-apis/get-folder-info
    

    public async Task<StorageModel?> GetFolderInfoAsync(string repoKey, string path, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNullOrWhiteSpace(repoKey, nameof(repoKey));
        ArgumentNullException.ThrowIfNull(path, nameof(path));

        var res = await GetFromJsonAsync<StorageModel>($"/artifactory/api/storage/{repoKey}/{path}", cancellationToken);
        return res;
    }

    // https://jfrog.com/help/r/jfrog-rest-apis/get-file-info

    public async Task<StorageModel?> GetFileInfoAsync(string repoKey, string path, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNullOrWhiteSpace(repoKey, nameof(repoKey));
        ArgumentNullException.ThrowIfNull(path, nameof(path));

        var res = await GetFromJsonAsync<StorageModel>($"/artifactory/api/storage/{repoKey}/{path}", cancellationToken);
        return res;
    }

    //https://jfrog.com/help/r/jfrog-rest-apis/file-list
    // GET /artifactory/api/storage/{repoKey}/{folder-path}?list[&deep=0/1][&depth=n][&listFolders=0/1][&mdTimestamps=0/1][&includeRootPath=0/1]
    public async Task<StorageListModel?> GetFileListAsync(string repoKey, string path, bool deep, int depth, bool listFolders, bool mdTimestamps, bool includeRootPath, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNullOrWhiteSpace(repoKey, nameof(repoKey));
        ArgumentNullException.ThrowIfNull(path, nameof(path));

        var requestUri = CombineUrl("/artifactory/api/storage", repoKey, path, ("list", ""), ("deep", deep ? 1 : 0), ("depth", depth), ("listFolders", listFolders ? 1 : 0), ("mdTimestamps", mdTimestamps ? 1 : 0), ("includeRootPath", includeRootPath ? 1 : 0));

        var res = await GetFromJsonAsync<StorageListModel>(requestUri, cancellationToken);
        return res;
    }

    public async Task<StorageStatsModel?> GetFileStatisticsAsync(string repoKey, string path, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(repoKey, nameof(repoKey));
        ArgumentNullException.ThrowIfNull(path, nameof(path));

        var res = await GetFromJsonAsync<StorageStatsModel>($"/artifactory/api/storage/{repoKey}/{path}?stats", cancellationToken);
        return res;
    }

    public async Task<DirectoryModel?> CreateDirectoryAsync(string repo, string path, string createdBy, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(repo, nameof(repo));
        ArgumentNullException.ThrowIfNullOrEmpty(path, nameof(path));
        ArgumentNullException.ThrowIfNullOrEmpty(createdBy, nameof(createdBy));

        string url = CombineUrl(urlPrefix, repo, path);
        var create = new DirectoryModel() { Uri = new Uri(Host, url), Repo = repo, Path = path, CreatedBy = createdBy, Created = DateTime.Now };
        var res = await PutAsJsonAsync<DirectoryModel, DirectoryModel>(url, create, cancellationToken);
        return res;
    }


    public async Task CopyItemAsync(string sourceRepo, string sourcePath, string destinationRepo, string destinationPath, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(sourceRepo, nameof(sourceRepo));
        ArgumentNullException.ThrowIfNullOrEmpty(sourcePath, nameof(sourcePath));
        ArgumentNullException.ThrowIfNullOrEmpty(destinationRepo, nameof(destinationRepo));
        ArgumentNullException.ThrowIfNullOrEmpty(destinationPath, nameof(destinationPath));
        
        string url = CombineUrl(apiPrefix, "/copy", sourceRepo, sourcePath, ("to", CombineUrl(destinationRepo, destinationPath)));
        await PostFromJsonAsync<MessagesRoot>(url, cancellationToken);
    }

    public async Task MoveItemAsync(string sourceRepo, string sourcePath, string destinationRepo, string destinationPath, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(sourceRepo, nameof(sourceRepo));
        ArgumentNullException.ThrowIfNullOrEmpty(sourcePath, nameof(sourcePath));
        ArgumentNullException.ThrowIfNullOrEmpty(destinationRepo, nameof(destinationRepo));
        ArgumentNullException.ThrowIfNullOrEmpty(destinationPath, nameof(destinationPath));

        string url = CombineUrl(apiPrefix, "/move", sourceRepo, sourcePath, ("to", CombineUrl(destinationRepo, destinationPath)));
        await PostFromJsonAsync<MessagesRoot>(url, cancellationToken);
    }

    public async Task DeleteItemAsync(string repoKey, string path, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(repoKey, nameof(repoKey));
        ArgumentNullException.ThrowIfNull(path, nameof(path));

        string url = CombineUrl(urlPrefix, repoKey, path);
        await DeleteAsync(url, cancellationToken);
    }

    public async Task<bool> ExistsAsync(string repo, string path, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(repo, nameof(repo));
        ArgumentNullException.ThrowIfNull(path, nameof(path));

        string url = CombineUrl("/artifactory/api/storage", repo, path);
        var res = await FoundAsync(url, cancellationToken);
        return res;
    }

    #endregion

    #region StorageInfo

    public async Task<StorageInfoModel?> GetStorageInfoAsync(CancellationToken cancellationToken)
    {
        var res = await GetFromJsonAsync<StorageInfoModel>("/artifactory/api/storageinfo", cancellationToken);
        return res;
    }

    public async Task RefreshStorageInfoAsync(CancellationToken cancellationToken)
    {
        await PostAsync("/artifactory/api/storageinfo/calculate", cancellationToken);
    }

    #endregion

    #region Download & Upload

    public async Task DownloadFileAsync(string repo, string path, string filePath, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(repo, nameof(repo));
        ArgumentNullException.ThrowIfNull(path, nameof(path));
        ArgumentNullException.ThrowIfNullOrEmpty(filePath, nameof(filePath));

        string url = CombineUrl(urlPrefix, repo, path);
        await DownloadAsync(url, filePath, cancellationToken);
    }

    public async Task DownloadFileAsync(Uri url, string filePath, CancellationToken cancellationToken)
    {
        //ArgumentNullException.ThrowIfNullOrEmpty(url, nameof(url));
        ArgumentNullException.ThrowIfNullOrEmpty(filePath, nameof(filePath));

        await DownloadAsync(url, filePath, cancellationToken);
    }

    public async Task<System.IO.Stream> GetFileStreamAsync(string repo, string path, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(repo, nameof(repo));
        ArgumentNullException.ThrowIfNull(path, nameof(path));

        string url = CombineUrl(urlPrefix, repo, path);
        return await GetFromStreamAsync(url, cancellationToken);
    }

    public async Task<System.IO.Stream> GetFileStreamAsync(Uri url, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(url.ToString(), nameof(url));

        return await GetFromStreamAsync(url.ToString(), cancellationToken);
    }

    public async Task UploadFileAsync(string repo, string path, string filePath, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(repo, nameof(repo));
        ArgumentNullException.ThrowIfNullOrEmpty(path, nameof(path));
        ArgumentNullException.ThrowIfNullOrEmpty(filePath, nameof(filePath));

        //var req = new MultipartFormDataContent();
        using var stream = System.IO.File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);

        await UploadFileAsync(repo, path, stream, cancellationToken);

        //string filename = System.IO.Path.GetFileName(path);
        //req.Add(new StreamContent(stream), "file", filename);
        //string url = CombineUrl(urlPrefix, repo, path);
        //await PutAsync(url, req, cancellationToken);
    }

    public async Task UploadFileAsync(string repo, string path, Stream stream, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(repo, nameof(repo));
        ArgumentNullException.ThrowIfNullOrEmpty(path, nameof(path));

        // do not use MultipartFormDataContent

        //var req = new MultipartFormDataContent();
        //string filename = System.IO.Path.GetFileName(path);
        //req.Add(new StreamContent(stream), "file", filename);

        var req = new StreamContent(stream);
        string url = CombineUrl(urlPrefix, repo, path);
        await PutAsync(url, req, cancellationToken);
    }

    #endregion

    //public async Task<ArtifactoryVersionModel?> GetVersionAsync(CancellationToken cancellationToken)
    //{
    //    client?.DefaultRequestHeaders.Accept.ParseAdd("application/vnd.org.jfrog.artifactory.system.Version+json");
    
    //    var res = await GetFromJsonAsync<ArtifactoryVersionModel>("/artifactory/api/system/version", cancellationToken);
    //    return res;
    //}

    //public async Task<VersionMode?> GetXrayVersionAsync(CancellationToken cancellationToken)
    //{
    //    var res = await GetFromJsonAsync<VersionMode>("/access/api/v1/system/ping", cancellationToken);
    //    return res;
    //}


}

/*
  
Repositories  

GET     /artifactory/api/repositories                                                       : Get Repositories
GET     /artifactory/api/repositories/{repoKey}                                             : Get Repository
PUT     /artifactory/api/repositories/{repoKey}                                             : Create respository
DELETE  /artifactory/api/repositories/{repoKey}                                             : Delete repository
POST    /artifactory/api/repositories/{repoKey}                                             : Update repository

GET     /artifactory/api/storage/{repoKey}/{folder-path}?list[&deep=0/1][&depth=n][&listFolders=0/1][&mdTimestamps=0/1][&includeRootPath=0/1]  : File List


GET     /artifactory/repositories/existence?type=local&type=remote&projectKey=my-proj-1         : Check If Repository Exists



GET     /api/storage/{repoKey}/{folder-path}                                                    : Get folder info
GET     /api/storage/{repoKey}/{filePath}                                                       : Get file info
GET     /api/storage/{repoKey}/{item-path}?stats                                                : File Statistics

PUT     /repo-key/path/to/directory/                                                            : Create Folder
DELETE  /repo-key/path/to/file-or-folder                                                        : Delete Item
POST    /api/copy/{srcRepoKey}/{srcFilePath}?to=/{targetRepoKey}/{targetFilePath}[&dry=1][&suppressLayouts=0/1(default)][&failFast=0/1]     : Copy Item
POST /api/move/{srcRepoKey}/{srcFilePath}?to=/{targetRepoKey}/{targetFilePath}[&dry=1][&suppressLayouts=0/1(default)][&failFast=0/1]        : Move Item




GET     /api/storageinfo                                                                        : Get Storage Summary Info
POST    /api/storageinfo/calculate                                                              : Refresh Storage Summary Info

Item Properties

GET     /api/storage/{repoKey}/{itemPath}?properties[=x[,y]]                                : Get Item Properties
PUT     /api/storage/{repoKey}/{itemPath}?properties=p1=v1[,v2][|p2=v3][[&recursive=0]      : Set Item Properties
PATCH   /api/metadata/{repoKey}/{itemPath}?[&recursiveProperties=0]                         : Update Item Properties
DELETE  /api/storage/{repoKey}{itemPath}?properties=p1[,p2][&recursive=0]                   : Delete Item Properties

upload
curl -u myUser:myP455w0rd! -X PUT "http://localhost:8081/artifactory/my-repository/my/new/artifact/directory/myAppBuild.exe" -T ./myAppBuild.exe And with the JFrog CLI: jfrog rt u ./myAppBuild.exe my-repository/my/new/artifact/directory/
download
curl -u myUser:myP455w0rd! -X GET http://localhost:8081/artifactory/libs-release-local/ch/qos/logback/logback-classic/0.9.9/logback-classic-0.9.9.jar And with JFrog CLI: jfrog rt dl libs-release-local/ch/qos/logback/logback-classic/0.9.9/logback-classic-0.9.9.jar
search
curl -u myUser:myP455w0rd! http://localhost:8081/artifactory/api/search/artifact?name=lib&repos=libs-release-local OR with JFrog CLI: jfrog rt s libs-release-local/lib { "results": [{ "uri": "http://localhost:8081/artifactory/api/storage/libs-release-local/org/acme/lib/ver/lib-ver.pom" },{ "uri": "http://localhost:8081/artifactory/api/storage/libs-release-local/org/acme/lib/ver2/lib-ver2.pom" }] }

*/