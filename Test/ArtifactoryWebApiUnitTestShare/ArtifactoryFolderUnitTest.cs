namespace ArtifactoryWebApiUnitTest;

[TestClass]
public class ArtifactoryFolderUnitTest : ArtifactoryBaseUnitTest
{
    [TestMethod]
    public async Task TestMethodGetFolderInfoRootAsync()
    {
        using var artifactory = new Artifactory(storeKey, appName);
        var folderInfo = await artifactory.GetFolderInfoAsync("local-generic-test-fix", "/");

        Assert.IsNotNull(folderInfo, nameof(folderInfo));
        Assert.AreEqual("local-generic-test-fix", folderInfo.Repo, nameof(folderInfo.Repo));
        Assert.AreEqual("/", folderInfo.Path, nameof(folderInfo.Path));
        Assert.IsNotNull(folderInfo.Created, nameof(folderInfo.Created));
        Assert.AreEqual("12/19/2024 6:14:04 PM", folderInfo.Created.Value.ToString(culture), nameof(folderInfo.Created));
        Assert.IsNull(folderInfo.CreatedBy, nameof(folderInfo.CreatedBy));
        Assert.IsNotNull(folderInfo.LastModified, nameof(folderInfo.LastModified));
        Assert.AreEqual("12/19/2024 6:14:04 PM", folderInfo.LastModified.Value.ToString(culture), nameof(folderInfo.LastModified));
        Assert.IsNull(folderInfo.ModifiedBy, nameof(folderInfo.ModifiedBy));
        Assert.IsNotNull(folderInfo.LastUpdated, nameof(folderInfo.LastUpdated));
        Assert.AreEqual("12/19/2024 6:14:04 PM", folderInfo.LastUpdated.Value.ToString(culture), nameof(folderInfo.LastUpdated));
        Assert.IsNull(folderInfo.DownloadUri, nameof(folderInfo.DownloadUri));
        Assert.IsNull(folderInfo.MimeType, nameof(folderInfo.MimeType));
        Assert.IsNull(folderInfo.Size, nameof(folderInfo.Size));
        Assert.IsNull(folderInfo.Checksums, nameof(folderInfo.Checksums));
        Assert.IsNull(folderInfo.OriginalChecksums, nameof(folderInfo.OriginalChecksums));
        Assert.IsNotNull(folderInfo.Children, nameof(folderInfo.Children));
        CollectionAssert.AreEqual(new ChildAssert[] {
            new() { Uri = "/group", IsFolder = true },
            new() { Uri = "/images", IsFolder = true },
            new() { Uri = "/mixed", IsFolder = true },
            new() { Uri = "/img-v001.jpg", IsFolder = false },
            new() { Uri = "/img-v002.jpg", IsFolder = false },
            new() { Uri = "/img-v003.jpg", IsFolder = false },
        }, folderInfo.Children.ToList(), nameof(folderInfo.Children));
        Assert.AreEqual(new Uri(new Uri(testHost), "/artifactory/api/storage/local-generic-test-fix"), folderInfo.Uri, nameof(folderInfo.Uri));
    }

    [TestMethod]
    public async Task TestMethodGetFolderInfoAsync()
    {
        using var artifactory = new Artifactory(storeKey, appName);
        var folderInfo = await artifactory.GetFolderInfoAsync("local-generic-test-fix", "/mixed");

        Assert.IsNotNull(folderInfo, nameof(folderInfo));
        Assert.AreEqual("local-generic-test-fix", folderInfo.Repo, nameof(folderInfo.Repo));
        Assert.AreEqual("/mixed", folderInfo.Path, nameof(folderInfo.Path));
        Assert.IsNotNull(folderInfo.Created, nameof(folderInfo.Created));
        Assert.AreEqual("12/19/2024 6:37:55 PM", folderInfo.Created.Value.ToString(culture), nameof(folderInfo.Created));
        Assert.AreEqual(testUserEmail, folderInfo.CreatedBy, nameof(folderInfo.CreatedBy));
        Assert.IsNotNull(folderInfo.LastModified, nameof(folderInfo.LastModified));
        Assert.AreEqual("12/19/2024 6:37:55 PM", folderInfo.LastModified.Value.ToString(culture), nameof(folderInfo.LastModified));
        Assert.AreEqual(testUserEmail, folderInfo.ModifiedBy, nameof(folderInfo.ModifiedBy));
        Assert.IsNotNull(folderInfo.LastUpdated, nameof(folderInfo.LastUpdated));
        Assert.AreEqual("12/19/2024 6:37:55 PM", folderInfo.LastUpdated.Value.ToString(culture), nameof(folderInfo.LastUpdated));
        Assert.IsNull(folderInfo.DownloadUri, nameof(folderInfo.DownloadUri));
        Assert.IsNull(folderInfo.MimeType, nameof(folderInfo.MimeType));
        Assert.IsNull(folderInfo.Size, nameof(folderInfo.Size));
        Assert.IsNull(folderInfo.Checksums, nameof(folderInfo.Checksums));
        Assert.IsNull(folderInfo.OriginalChecksums, nameof(folderInfo.OriginalChecksums));
        Assert.IsNotNull(folderInfo.Children, nameof(folderInfo.Children));
        CollectionAssert.AreEqual(new ChildAssert[] {
            new() { Uri = "/img-v001", IsFolder = true },
            new() { Uri = "/img-v002", IsFolder = true },
            new() { Uri = "/img-v001.jpg", IsFolder = false },
            new() { Uri = "/img-v002.jpg", IsFolder = false },
        }, folderInfo.Children.ToList(), nameof(folderInfo.Children));
        Assert.AreEqual(new Uri(new Uri(testHost), "/artifactory/api/storage/local-generic-test-fix/mixed"), folderInfo.Uri, nameof(folderInfo.Uri));
    }

    [TestMethod]
    public async Task TestMethodGetFolderInfoDeepAsync()
    {
        using var artifactory = new Artifactory(storeKey, appName);
        var folderInfo = await artifactory.GetFolderInfoAsync("local-generic-test-fix", "/group/sun");

        Assert.IsNotNull(folderInfo, nameof(folderInfo));
        Assert.AreEqual("local-generic-test-fix", folderInfo.Repo, nameof(folderInfo.Repo));
        Assert.AreEqual("/group/sun", folderInfo.Path, nameof(folderInfo.Path));
        Assert.IsNotNull(folderInfo.Created, nameof(folderInfo.Created));
        Assert.AreEqual("12/19/2024 6:22:34 PM", folderInfo.Created.Value.ToString(culture), nameof(folderInfo.Created));
        Assert.AreEqual(testUserEmail, folderInfo.CreatedBy, nameof(folderInfo.CreatedBy));
        Assert.IsNotNull(folderInfo.LastModified, nameof(folderInfo.LastModified));
        Assert.AreEqual("12/19/2024 6:22:34 PM", folderInfo.LastModified.Value.ToString(culture), nameof(folderInfo.LastModified));
        Assert.AreEqual(testUserEmail, folderInfo.ModifiedBy, nameof(folderInfo.ModifiedBy));
        Assert.IsNotNull(folderInfo.LastUpdated, nameof(folderInfo.LastUpdated));
        Assert.AreEqual("12/19/2024 6:22:34 PM", folderInfo.LastUpdated.Value.ToString(culture), nameof(folderInfo.LastUpdated));
        Assert.IsNull(folderInfo.DownloadUri, nameof(folderInfo.DownloadUri));
        Assert.IsNull(folderInfo.MimeType, nameof(folderInfo.MimeType));
        Assert.IsNull(folderInfo.Size, nameof(folderInfo.Size));
        Assert.IsNull(folderInfo.Checksums, nameof(folderInfo.Checksums));
        Assert.IsNull(folderInfo.OriginalChecksums, nameof(folderInfo.OriginalChecksums));
        Assert.IsNotNull(folderInfo.Children, nameof(folderInfo.Children));
        CollectionAssert.AreEqual(new ChildAssert[] {
            new() { Uri = "/img-v001.jpg", IsFolder = false },
            new() { Uri = "/img-v002.jpg", IsFolder = false },
            new() { Uri = "/img-v003.jpg", IsFolder = false },
        }, folderInfo.Children.ToList(), nameof(folderInfo.Children));
        Assert.AreEqual(new Uri(new Uri(testHost), "/artifactory/api/storage/local-generic-test-fix/group/sun"), folderInfo.Uri, nameof(folderInfo.Uri));
    }

    [TestMethod]
    public async Task TestMethodExistFileAsync()
    {
        using var artifactory = new Artifactory(storeKey, appName);
        var exists = await artifactory.ExistsAsync("local-generic-test-fix", "mixed");
        var notExists = await artifactory.ExistsAsync("local-generic-test-fix", "mixed-xyz");

        Assert.IsTrue(exists);
        Assert.IsFalse(notExists);
    }
}
