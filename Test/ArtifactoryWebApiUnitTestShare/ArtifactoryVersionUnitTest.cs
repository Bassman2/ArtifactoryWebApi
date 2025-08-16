namespace ArtifactoryWebApiUnitTest;

[TestClass]
public class ArtifactoryVersionUnitTest : ArtifactoryBaseUnitTest
{
    [TestMethod]
    public async Task TestMethodGetVersionAsync()
    {
        using var artifactory = new Artifactory(storeKey, appName);

        var version = await artifactory.GetVersionAsync();

        Assert.IsNotNull(version);
        Assert.AreEqual(new Version(7,77,11,77711900), version);
        Assert.AreEqual("7.77.11.77711900", version.ToString()); 
    }

    //[TestMethod]
    //public async Task TestMethodGetXrayVersionAsync()
    //{
    //    using var artifactory = new Artifactory(storeKey, appName);

    //    await artifactory.GetXrayVersionAsync();
    //}

}
