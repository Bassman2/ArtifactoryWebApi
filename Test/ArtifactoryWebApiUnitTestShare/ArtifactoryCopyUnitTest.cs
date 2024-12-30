namespace ArtifactoryWebApiUnitTest;

[TestClass]
public class ArtifactoryCopyUnitTest : ArtifactoryBaseUnitTest
{
    [TestMethod]
    public async Task TestMethodCopyMoveDeleteFileAsync()
    {
        using var artifactory = new Artifactory(storeKey);

        await artifactory.CopyAsync("local-generic-test-dynamic", "/fix-folder/img-v001.jpg", "local-generic-test-dynamic", "/copy-folder/img-v001.jpg");

        bool existsCopy = await artifactory.ExistsAsync("local-generic-test-dynamic", "/copy-folder/img-v001.jpg");
        Assert.IsTrue(existsCopy);

        await artifactory.MoveAsync("local-generic-test-dynamic", "/copy-folder/img-v001.jpg", "local-generic-test-dynamic", "/move-folder/img-v001.jpg");

        bool existsMoveOld = await artifactory.ExistsAsync("local-generic-test-dynamic", "/copy-folder/img-v001.jpg");
        bool existsMoveNew = await artifactory.ExistsAsync("local-generic-test-dynamic", "/move-folder/img-v001.jpg");
        Assert.IsFalse(existsMoveOld);
        Assert.IsTrue(existsMoveNew);

        await artifactory.DeleteAsync("local-generic-test-dynamic", "/move-folder/img-v001.jpg");

        bool existsDel = await artifactory.ExistsAsync("local-generic-test-dynamic", "/move-folder/img-v001.jpg");
        Assert.IsFalse(existsDel);
    }

}
