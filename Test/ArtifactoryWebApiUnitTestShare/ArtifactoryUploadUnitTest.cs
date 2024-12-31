namespace ArtifactoryWebApiUnitTest;

[TestClass]
public class ArtifactoryUploadUnitTest : ArtifactoryBaseUnitTest
{
    private const string localPath = @"D:\_Data\Artifactory\UnitTest\Upload\img-v001.jpg";
    private const string path = "/upload-folder/upload-file/img-v001.jpg";

    [TestMethod]
    public async Task TestMethodUploadFileAsync()
    {
        using var artifactory = new Artifactory(storeKey);
        
        await artifactory.UploadFileAsync(repoKeyDynamic, path, localPath);

        bool exists = await artifactory.ExistsAsync(repoKeyDynamic, path);

        Assert.IsTrue(exists);

        await artifactory.DeleteAsync(repoKeyDynamic, path);
        
    }

    [TestMethod]
    public async Task TestMethodUploadFileStreamAsync()
    {
        using var artifactory = new Artifactory(storeKey);

        using var stream = System.IO.File.Open(localPath, FileMode.Open, FileAccess.Read);

        await artifactory.UploadFileAsync(repoKeyDynamic, path, stream);

        bool exists = await artifactory.ExistsAsync(repoKeyDynamic, path);

        Assert.IsTrue(exists);

        await artifactory.DeleteAsync(repoKeyDynamic, path);
    }
}
