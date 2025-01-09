namespace ArtifactoryWebApiUnitTest;

[TestClass]
public class ArtifactoryCopyUnitTest : ArtifactoryBaseUnitTest
{
    [TestMethod]
    public async Task TestMethodCopyMoveDeleteFileAsync()
    {
        using var artifactory = new Artifactory(storeKey, appName);

        await artifactory.CopyAsync(repoKeyDynamic, "/fix-folder/img-v001.jpg", "local-generic-test-dynamic", "/copy-folder/img-v001.jpg");

        bool existsCopy = await artifactory.ExistsAsync(repoKeyDynamic, "/copy-folder/img-v001.jpg");
        Assert.IsTrue(existsCopy);

        await artifactory.MoveAsync(repoKeyDynamic, "/copy-folder/img-v001.jpg", "local-generic-test-dynamic", "/move-folder/img-v001.jpg");

        bool existsMoveOld = await artifactory.ExistsAsync(repoKeyDynamic, "/copy-folder/img-v001.jpg");
        bool existsMoveNew = await artifactory.ExistsAsync(repoKeyDynamic, "/move-folder/img-v001.jpg");
        Assert.IsFalse(existsMoveOld);
        Assert.IsTrue(existsMoveNew);

        await artifactory.DeleteAsync(repoKeyDynamic, "/move-folder/img-v001.jpg");

        bool existsDel = await artifactory.ExistsAsync(repoKeyDynamic, "/move-folder/img-v001.jpg");
        Assert.IsFalse(existsDel);
    }

}
