namespace ArtifactoryWebApiUnitTest;

[TestClass]
public class ArtifactoryFileUnitTest : ArtifactoryBaseUnitTest
{
    [TestMethod]
    public async Task TestMethodGetFileInfoAsync()
    {
        using var artifactory = new Artifactory(storeKey, appName);
        var fileInfo = await artifactory.GetFileInfoAsync("local-generic-test-fix", "/mixed/img-v001.jpg");

        Assert.IsNotNull(fileInfo);
        Assert.IsNotNull(fileInfo, nameof(fileInfo));
        Assert.AreEqual("local-generic-test-fix", fileInfo.Repo, nameof(fileInfo.Repo));
        Assert.AreEqual("/mixed/img-v001.jpg", fileInfo.Path, nameof(fileInfo.Path));
        Assert.IsNotNull(fileInfo.Created, nameof(fileInfo.Created));
        Assert.AreEqual("12/19/2024 6:37:55 PM", fileInfo.Created.Value.ToString(culture), nameof(fileInfo.Created));
        Assert.AreEqual(testUserEmail, fileInfo.CreatedBy, nameof(fileInfo.CreatedBy)); 
        Assert.IsNotNull(fileInfo.LastModified, nameof(fileInfo.LastModified));
        Assert.AreEqual("12/19/2024 6:37:55 PM", fileInfo.LastModified.Value.ToString(culture), nameof(fileInfo.LastModified));
        Assert.AreEqual(testUserEmail, fileInfo.ModifiedBy, nameof(fileInfo.ModifiedBy));
        Assert.IsNotNull(fileInfo.LastUpdated, nameof(fileInfo.LastUpdated));
        Assert.AreEqual("12/19/2024 6:37:55 PM", fileInfo.LastUpdated.Value.ToString(culture), nameof(fileInfo.LastUpdated));
        Assert.AreEqual(new Uri(new Uri(testHost), "/artifactory/local-generic-test-fix//mixed/img-v001.jpg"), fileInfo.DownloadUri, nameof(fileInfo.DownloadUri));
        Assert.AreEqual("application/octet-stream", fileInfo.MimeType, nameof(fileInfo.MimeType));
        Assert.AreEqual("6456140", fileInfo.Size, nameof(fileInfo.Size));
        Assert.IsNotNull(fileInfo.Checksums, nameof(fileInfo.Checksums));
        Assert.AreEqual("ae900ff79b43aa9c9c0e8413da3fcfe0df4e9215", fileInfo.Checksums.Sha1, nameof(fileInfo.Checksums.Sha1));
        Assert.AreEqual("240bdae75168c353780407dc9a4cd9eb", fileInfo.Checksums.Md5, nameof(fileInfo.Checksums.Md5));
        Assert.AreEqual("8f922c97c8e0bbd7477ed24d04da9cd94d11d34e11f69538d6af5c266ec65f62", fileInfo.Checksums.Sha256, nameof(fileInfo.Checksums.Sha256));
        Assert.IsNotNull(fileInfo.OriginalChecksums, nameof(fileInfo.OriginalChecksums));
        Assert.AreEqual("ae900ff79b43aa9c9c0e8413da3fcfe0df4e9215", fileInfo.OriginalChecksums.Sha1, nameof(fileInfo.OriginalChecksums.Sha1));
        Assert.AreEqual("240bdae75168c353780407dc9a4cd9eb", fileInfo.OriginalChecksums.Md5, nameof(fileInfo.OriginalChecksums.Md5));
        Assert.AreEqual("8f922c97c8e0bbd7477ed24d04da9cd94d11d34e11f69538d6af5c266ec65f62", fileInfo.OriginalChecksums.Sha256, nameof(fileInfo.OriginalChecksums.Sha256));
        Assert.IsNull(fileInfo.Children, nameof(fileInfo.Children));
        Assert.AreEqual(new Uri(new Uri(testHost), "/artifactory/api/storage/local-generic-test-fix/mixed/img-v001.jpg"), fileInfo.Uri, nameof(fileInfo.Uri));
    }

    [TestMethod]
    public async Task TestMethodGetFileListRootAsync()
    {
        // /artifactory/api/storage/local-generic-test-fix?list&deep=1&depth=10&listFolders=1&mdTimestamps=1&includeRootPath=1
        using var artifactory = new Artifactory(storeKey, appName);
        var list = await artifactory.GetFileListAsync("local-generic-test-fix", "/", true, 10, true, true, true);

        Assert.IsNotNull(list);
        Assert.AreEqual(new Uri(new Uri(testHost), "artifactory/api/storage/local-generic-test-fix"), list.Uri, nameof(list.Uri));
        Assert.IsNotNull(list.Created, nameof(list.Created));

        Assert.IsNotNull(list.Files);
        CollectionAssert.AreEqual(new FileAssert[] {
            new() { Uri = "/", Size = -1, LastModified = new DateTime(2024, 12, 19), Folder = true, Sha1 = null, Sha2 = null, MdTimestamps = null },
            new() { Uri = "/group", Size = -1, LastModified = new DateTime(2024, 12, 19), Folder = true, Sha1 = null, Sha2 = null, MdTimestamps = null },
            new() { Uri = "/group/sun", Size = -1, LastModified = new DateTime(2024, 12, 19), Folder = true, Sha1 = null, Sha2 = null, MdTimestamps = null },
            new() { Uri = "/group/sun/img-v001.jpg", Size = 6456140, LastModified = new DateTime(2024, 12, 19), Folder = false, Sha1 = "ae900ff79b43aa9c9c0e8413da3fcfe0df4e9215", Sha2 = "8f922c97c8e0bbd7477ed24d04da9cd94d11d34e11f69538d6af5c266ec65f62", MdTimestamps = null },
            new() { Uri = "/group/sun/img-v002.jpg", Size = 6456140, LastModified = new DateTime(2024, 12, 19), Folder = false, Sha1 = "ae900ff79b43aa9c9c0e8413da3fcfe0df4e9215", Sha2 = "8f922c97c8e0bbd7477ed24d04da9cd94d11d34e11f69538d6af5c266ec65f62", MdTimestamps = null },
            new() { Uri = "/group/sun/img-v003.jpg", Size = 6456140, LastModified = new DateTime(2024, 12, 19), Folder = false, Sha1 = "ae900ff79b43aa9c9c0e8413da3fcfe0df4e9215", Sha2 = "8f922c97c8e0bbd7477ed24d04da9cd94d11d34e11f69538d6af5c266ec65f62", MdTimestamps = null },
            new() { Uri = "/images", Size = -1, LastModified = new DateTime(2024, 12, 19), Folder = true, Sha1 = null, Sha2 = null, MdTimestamps = null },
            new() { Uri = "/images/sun-v001", Size = -1, LastModified = new DateTime(2024, 12, 19), Folder = true, Sha1 = null, Sha2 = null, MdTimestamps = null },
            new() { Uri = "/images/sun-v001/img-v001.jpg", Size = 6456140, LastModified = new DateTime(2024, 12, 19), Folder = false, Sha1 = "ae900ff79b43aa9c9c0e8413da3fcfe0df4e9215", Sha2 = "8f922c97c8e0bbd7477ed24d04da9cd94d11d34e11f69538d6af5c266ec65f62", MdTimestamps = null },
            new() { Uri = "/images/sun-v002", Size = -1, LastModified = new DateTime(2024, 12, 19), Folder = true, Sha1 = null, Sha2 = null, MdTimestamps = null },
            new() { Uri = "/images/sun-v002/img-v002.jpg", Size = 6456140, LastModified = new DateTime(2024, 12, 19), Folder = false, Sha1 = "ae900ff79b43aa9c9c0e8413da3fcfe0df4e9215", Sha2 = "8f922c97c8e0bbd7477ed24d04da9cd94d11d34e11f69538d6af5c266ec65f62", MdTimestamps = null },
            new() { Uri = "/images/sun-v003", Size = -1, LastModified = new DateTime(2024, 12, 19), Folder = true, Sha1 = null, Sha2 = null, MdTimestamps = null },
            new() { Uri = "/images/sun-v003/img-v003.jpg", Size = 6456140, LastModified = new DateTime(2024, 12, 19), Folder = false, Sha1 = "ae900ff79b43aa9c9c0e8413da3fcfe0df4e9215", Sha2 = "8f922c97c8e0bbd7477ed24d04da9cd94d11d34e11f69538d6af5c266ec65f62", MdTimestamps = null },
            new() { Uri = "/mixed", Size = -1, LastModified = new DateTime(2024, 12, 19), Folder = true, Sha1 = null, Sha2 = null, MdTimestamps = null },
            new() { Uri = "/mixed/img-v001", Size = -1, LastModified = new DateTime(2024, 12, 19), Folder = true, Sha1 = null, Sha2 = null, MdTimestamps = null },
            new() { Uri = "/mixed/img-v001/img-v001.jpg", Size = 6456140, LastModified = new DateTime(2024, 12, 19), Folder = false, Sha1 = "ae900ff79b43aa9c9c0e8413da3fcfe0df4e9215", Sha2 = "8f922c97c8e0bbd7477ed24d04da9cd94d11d34e11f69538d6af5c266ec65f62", MdTimestamps = null },
            new() { Uri = "/mixed/img-v002", Size = -1, LastModified = new DateTime(2024, 12, 19), Folder = true, Sha1 = null, Sha2 = null, MdTimestamps = null },
            new() { Uri = "/mixed/img-v002/img-v002.jpg", Size = 6456140, LastModified = new DateTime(2024, 12, 19), Folder = false, Sha1 = "ae900ff79b43aa9c9c0e8413da3fcfe0df4e9215", Sha2 = "8f922c97c8e0bbd7477ed24d04da9cd94d11d34e11f69538d6af5c266ec65f62", MdTimestamps = null },
            new() { Uri = "/mixed/img-v001.jpg", Size = 6456140, LastModified = new DateTime(2024, 12, 19), Folder = false, Sha1 = "ae900ff79b43aa9c9c0e8413da3fcfe0df4e9215", Sha2 = "8f922c97c8e0bbd7477ed24d04da9cd94d11d34e11f69538d6af5c266ec65f62", MdTimestamps = null },
            new() { Uri = "/mixed/img-v002.jpg", Size = 6456140, LastModified = new DateTime(2024, 12, 19), Folder = false, Sha1 = "ae900ff79b43aa9c9c0e8413da3fcfe0df4e9215", Sha2 = "8f922c97c8e0bbd7477ed24d04da9cd94d11d34e11f69538d6af5c266ec65f62", MdTimestamps = null },
            new() { Uri = "/img-v001.jpg", Size = 6456140, LastModified = new DateTime(2024, 12, 19), Folder = false, Sha1 = "ae900ff79b43aa9c9c0e8413da3fcfe0df4e9215", Sha2 = "8f922c97c8e0bbd7477ed24d04da9cd94d11d34e11f69538d6af5c266ec65f62", MdTimestamps = null },
            new() { Uri = "/img-v002.jpg", Size = 6456140, LastModified = new DateTime(2024, 12, 19), Folder = false, Sha1 = "ae900ff79b43aa9c9c0e8413da3fcfe0df4e9215", Sha2 = "8f922c97c8e0bbd7477ed24d04da9cd94d11d34e11f69538d6af5c266ec65f62", MdTimestamps = null },
            new() { Uri = "/img-v003.jpg", Size = 6456140, LastModified = new DateTime(2024, 12, 19), Folder = false, Sha1 = "ae900ff79b43aa9c9c0e8413da3fcfe0df4e9215", Sha2 = "8f922c97c8e0bbd7477ed24d04da9cd94d11d34e11f69538d6af5c266ec65f62", MdTimestamps = null },
        }, list.Files.ToList(), nameof(list.Files));
    }

    [TestMethod]
    public async Task TestMethodGetFileListMixedAsync()
    {
        using var artifactory = new Artifactory(storeKey, appName);
        var list = await artifactory.GetFileListAsync("local-generic-test-fix", "mixed", true, 10, true, true, true);

        Assert.IsNotNull(list);
        Assert.AreEqual(new Uri(new Uri(testHost), "artifactory/api/storage/local-generic-test-fix/mixed"), list.Uri, nameof(list.Uri));
        Assert.IsNotNull(list.Created, nameof(list.Created));
        Assert.IsNotNull(list.Files);
        CollectionAssert.AreEqual(new FileAssert[] {
            new() { Uri = "/", Size = -1, LastModified = new DateTime(2024, 12, 19), Folder = true, Sha1 = null, Sha2 = null, MdTimestamps = null },
            new() { Uri = "/img-v001", Size = -1, LastModified = new DateTime(2024, 12, 19), Folder = true, Sha1 = null, Sha2 = null, MdTimestamps = null },
            new() { Uri = "/img-v001/img-v001.jpg", Size = 6456140, LastModified = new DateTime(2024, 12, 19), Folder = false, Sha1 = "ae900ff79b43aa9c9c0e8413da3fcfe0df4e9215", Sha2 = "8f922c97c8e0bbd7477ed24d04da9cd94d11d34e11f69538d6af5c266ec65f62", MdTimestamps = null },
            new() { Uri = "/img-v002", Size = -1, LastModified = new DateTime(2024, 12, 19), Folder = true, Sha1 = null, Sha2 = null, MdTimestamps = null },
            new() { Uri = "/img-v002/img-v002.jpg", Size = 6456140, LastModified = new DateTime(2024, 12, 19), Folder = false, Sha1 = "ae900ff79b43aa9c9c0e8413da3fcfe0df4e9215", Sha2 = "8f922c97c8e0bbd7477ed24d04da9cd94d11d34e11f69538d6af5c266ec65f62", MdTimestamps = null },
            new() { Uri = "/img-v001.jpg", Size = 6456140, LastModified = new DateTime(2024, 12, 19), Folder = false, Sha1 = "ae900ff79b43aa9c9c0e8413da3fcfe0df4e9215", Sha2 = "8f922c97c8e0bbd7477ed24d04da9cd94d11d34e11f69538d6af5c266ec65f62", MdTimestamps = null },
            new() { Uri = "/img-v002.jpg", Size = 6456140, LastModified = new DateTime(2024, 12, 19), Folder = false, Sha1 = "ae900ff79b43aa9c9c0e8413da3fcfe0df4e9215", Sha2 = "8f922c97c8e0bbd7477ed24d04da9cd94d11d34e11f69538d6af5c266ec65f62", MdTimestamps = null },
        }, list.Files.ToList(), nameof(list.Files));
    }

    [TestMethod]
    public async Task TestMethodGetFileStatisticsAsync()
    {
        using var artifactory = new Artifactory(storeKey, appName);
        var stats = await artifactory.GetFileStatisticsAsync("local-generic-test-fix", "mixed/img-v001.jpg");

        Assert.IsNotNull(stats);
        Assert.AreEqual(new Uri(new Uri(testHost), "artifactory/local-generic-test-fix/mixed/img-v001.jpg"), stats.Uri, nameof(stats.Uri));
        Assert.AreEqual(7, stats.DownloadCount, nameof(stats.DownloadCount));
        Assert.AreEqual(1734999147884, stats.LastDownloaded, nameof(stats.LastDownloaded));
        Assert.AreEqual(testUserEmail, stats.LastDownloadedBy, nameof(stats.LastDownloadedBy));
        Assert.AreEqual(0, stats.RemoteDownloadCount, nameof(stats.RemoteDownloadCount));
        Assert.AreEqual(0, stats.RemoteLastDownloaded, nameof(stats.RemoteLastDownloaded));
    }

    [TestMethod]
    public async Task TestMethodExistFileAsync()
    {
        using var artifactory = new Artifactory(storeKey, appName);
        var exists = await artifactory.ExistsAsync("local-generic-test-fix", "mixed/img-v001.jpg");
        var notExists = await artifactory.ExistsAsync("local-generic-test-fix", "mixed/img-v001_xxx.jpg");

        Assert.IsTrue(exists);
        Assert.IsFalse(notExists);
    }

}
