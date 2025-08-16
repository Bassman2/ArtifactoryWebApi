namespace ArtifactoryWebApiUnitTest;

[TestClass]
public class ArtifactoryUploadUnitTest : ArtifactoryBaseUnitTest
{
    private const string localPath = @"D:\_Data\Artifactory\UnitTest\Upload\img-v001.jpg";

    [TestMethod]
    public async Task TestMethodUploadFileAsync()
    {
        string path = "/upload-folder/upload-file/img-v001.jpg";

        using var artifactory = new Artifactory(storeKey, appName);
        
        await artifactory.UploadFileAsync(repoKeyDynamic, path, localPath);

        bool exists = await artifactory.ExistsAsync(repoKeyDynamic, path);
        Assert.IsTrue(exists);

        await artifactory.DeleteAsync(repoKeyDynamic, path);

        exists = await artifactory.ExistsAsync(repoKeyDynamic, path);
        Assert.IsFalse(exists);

    }

    [TestMethod]
    public async Task TestMethodUploadFileStreamAsync()
    {
        string path = "/upload-folder/upload-file/img-v002.jpg";

        using var artifactory = new Artifactory(storeKey, appName);

        using var stream = System.IO.File.Open(localPath, FileMode.Open, FileAccess.Read, FileShare.Read);

        await artifactory.UploadFileAsync(repoKeyDynamic, path, stream);

        bool exists = await artifactory.ExistsAsync(repoKeyDynamic, path);
        Assert.IsTrue(exists);

        await artifactory.DeleteAsync(repoKeyDynamic, path);

        exists = await artifactory.ExistsAsync(repoKeyDynamic, path);
        Assert.IsFalse(exists);
    }
}
