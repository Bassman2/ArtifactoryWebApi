namespace ArtifactoryWebApiUnitTest;

[TestClass]
public class ArtifactoryMoveUnitTest : ArtifactoryBaseUnitTest
{
    [TestMethod]
    public async Task TestMethodDownloadUrlFileAsync()
    {
        string localPath = @"D:\_Test\Artifactory\img-v001.jpg";

        using var artifactory = new Artifactory(storeKey);
        Directory.CreateDirectory(Path.GetDirectoryName(localPath)!);
        System.IO.File.Delete(localPath);
        await artifactory.DownloadFileAsync(new Uri("https://trialmjgn5z.jfrog.io/artifactory/local-generic-test-dynamic/fix-folder/img-v001.jpg"), localPath);
        
        bool exists = System.IO.File.Exists(localPath);
        Assert.IsTrue(exists);
        System.IO.File.Delete(localPath);
    }

    [TestMethod]
    public async Task TestMethodDownloadFileAsync()
    {
        string localPath = @"D:\_Test\Artifactory\img-v002.jpg";

        using var artifactory = new Artifactory(storeKey);
        Directory.CreateDirectory(Path.GetDirectoryName(localPath)!);
        System.IO.File.Delete(localPath);
        await artifactory.DownloadFileAsync("local-generic-test-dynamic", "/fix-folder/img-v001.jpg", localPath);

        bool exists = System.IO.File.Exists(localPath);
        Assert.IsTrue(exists);
        System.IO.File.Delete(localPath);
    }

    [TestMethod]
    public async Task TestMethodStreamUrlFileAsync()
    {
        string localPath = @"D:\_Test\Artifactory\img-v003.jpg";

        using var artifactory = new Artifactory(storeKey);
        Directory.CreateDirectory(Path.GetDirectoryName(localPath)!);
        System.IO.File.Delete(localPath);
        using (var file = System.IO.File.Create(localPath))
        {
            var stream = await artifactory.GetFileStreamAsync(new Uri("https://trialmjgn5z.jfrog.io/artifactory/local-generic-test-dynamic/fix-folder/img-v001.jpg"));
            await stream.CopyToAsync(file);
        }
        bool exists = System.IO.File.Exists(localPath);
        Assert.IsTrue(exists);
        System.IO.File.Delete(localPath);
    }

    [TestMethod]
    public async Task TestMethodStreamFileAsync()
    {
        string localPath = @"D:\_Test\Artifactory\img-v004.jpg";

        using var artifactory = new Artifactory(storeKey);
        Directory.CreateDirectory(Path.GetDirectoryName(localPath)!);
        System.IO.File.Delete(localPath);

        using (var file = System.IO.File.Create(localPath))
        {
            var stream = await artifactory.GetFileStreamAsync("local-generic-test-dynamic", "/fix-folder/img-v001.jpg");
            await stream.CopyToAsync(file);
        }
        bool exists = System.IO.File.Exists(localPath);
        Assert.IsTrue(exists);
        System.IO.File.Delete(localPath);
    }

    
}
