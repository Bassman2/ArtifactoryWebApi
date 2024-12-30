namespace ArtifactoryWebApiUnitTest;

[TestClass]
public class ArtifactoryStorageInfoUnitTest : ArtifactoryBaseUnitTest
{
    [TestMethod]
    public async Task TestMethodGetStorageInfoAsync()
    {
        using var artifactory = new Artifactory(storeKey);
        var storageInfo = await artifactory.GetStorageInfoAsync();

        Assert.IsNotNull(storageInfo);
        Assert.IsNotNull(storageInfo.RepositoriesSummaryList);
        var repositoriesSummary = storageInfo.RepositoriesSummaryList.FirstOrDefault(s => s.RepoKey == "local-generic-test");
        Assert.IsNotNull(repositoriesSummary);
        Assert.AreEqual("local-generic-test", repositoriesSummary.RepoKey, nameof(repositoriesSummary.RepoKey));
        Assert.AreEqual(RepositoryType.Local, repositoriesSummary.RepoType, nameof(repositoriesSummary.RepoType));
        Assert.AreEqual(1, repositoriesSummary.FoldersCount, nameof(repositoriesSummary.FoldersCount));
        Assert.AreEqual(2, repositoriesSummary.FilesCount, nameof(repositoriesSummary.FilesCount));
        Assert.AreEqual("6.16 MB", repositoriesSummary.UsedSpace, nameof(repositoriesSummary.UsedSpace));
        Assert.AreEqual(6456337, repositoriesSummary.UsedSpaceInBytes, nameof(repositoriesSummary.UsedSpaceInBytes));
        Assert.AreEqual(3, repositoriesSummary.ItemsCount, nameof(repositoriesSummary.ItemsCount));
        Assert.AreEqual(PackageType.Generic, repositoriesSummary.PackageType, nameof(repositoriesSummary.PackageType));
        Assert.AreEqual("default", repositoriesSummary.ProjectKey, nameof(repositoriesSummary.ProjectKey));
        Assert.IsFalse(string.IsNullOrWhiteSpace(repositoriesSummary.Percentage), nameof(repositoriesSummary.Percentage));



        Assert.IsNotNull(storageInfo.FileStoreSummary);
        Assert.AreEqual("s3-storage-v3-direct", storageInfo.FileStoreSummary.StorageType, nameof(storageInfo.FileStoreSummary.StorageType));
        Assert.AreEqual("Artifactory Cloud", storageInfo.FileStoreSummary.StorageDirectory, nameof(storageInfo.FileStoreSummary.StorageDirectory));

        Assert.IsNotNull(storageInfo.BinariesSummary);
        Assert.IsFalse(string.IsNullOrWhiteSpace(storageInfo.BinariesSummary.BinariesCount), nameof(storageInfo.BinariesSummary.BinariesCount));
        Assert.IsFalse(string.IsNullOrWhiteSpace(storageInfo.BinariesSummary.BinariesSize), nameof(storageInfo.BinariesSummary.BinariesSize));
        Assert.IsFalse(string.IsNullOrWhiteSpace(storageInfo.BinariesSummary.ArtifactsSize), nameof(storageInfo.BinariesSummary.ArtifactsSize));
        Assert.IsFalse(string.IsNullOrWhiteSpace(storageInfo.BinariesSummary.Optimization), nameof(storageInfo.BinariesSummary.Optimization));
        Assert.IsFalse(string.IsNullOrWhiteSpace(storageInfo.BinariesSummary.ItemsCount), nameof(storageInfo.BinariesSummary.ItemsCount));
        Assert.IsFalse(string.IsNullOrWhiteSpace(storageInfo.BinariesSummary.ArtifactsCount), nameof(storageInfo.BinariesSummary.ArtifactsCount));

    }

    [TestMethod]
    public async Task TestMethodRefreshStorageInfoAsync()
    {
        using var artifactory = new Artifactory(storeKey);
        await artifactory.RefreshStorageInfoAsync();
        var storageInfo = await artifactory.GetStorageInfoAsync();

        Assert.IsNotNull(storageInfo);
        Assert.IsNotNull(storageInfo.RepositoriesSummaryList);
        var repositoriesSummary = storageInfo.RepositoriesSummaryList.FirstOrDefault(s => s.RepoKey == "local-generic-test");
        Assert.IsNotNull(repositoriesSummary);
        Assert.AreEqual("local-generic-test", repositoriesSummary.RepoKey, nameof(repositoriesSummary.RepoKey));
        Assert.AreEqual(RepositoryType.Local, repositoriesSummary.RepoType, nameof(repositoriesSummary.RepoType));
        Assert.AreEqual(1, repositoriesSummary.FoldersCount, nameof(repositoriesSummary.FoldersCount));
        Assert.AreEqual(2, repositoriesSummary.FilesCount, nameof(repositoriesSummary.FilesCount));
        Assert.AreEqual("6.16 MB", repositoriesSummary.UsedSpace, nameof(repositoriesSummary.UsedSpace));
        Assert.AreEqual(6456337, repositoriesSummary.UsedSpaceInBytes, nameof(repositoriesSummary.UsedSpaceInBytes));
        Assert.AreEqual(3, repositoriesSummary.ItemsCount, nameof(repositoriesSummary.ItemsCount));
        Assert.AreEqual(PackageType.Generic, repositoriesSummary.PackageType, nameof(repositoriesSummary.PackageType));
        Assert.AreEqual("default", repositoriesSummary.ProjectKey, nameof(repositoriesSummary.ProjectKey));
        Assert.IsFalse(string.IsNullOrWhiteSpace(repositoriesSummary.Percentage), nameof(repositoriesSummary.Percentage));

        Assert.IsNotNull(storageInfo.FileStoreSummary);
        Assert.AreEqual("s3-storage-v3-direct", storageInfo.FileStoreSummary.StorageType, nameof(storageInfo.FileStoreSummary.StorageType));
        Assert.AreEqual("Artifactory Cloud", storageInfo.FileStoreSummary.StorageDirectory, nameof(storageInfo.FileStoreSummary.StorageDirectory));

        Assert.IsNotNull(storageInfo.BinariesSummary);
        Assert.IsFalse(string.IsNullOrWhiteSpace(storageInfo.BinariesSummary.BinariesCount), nameof(storageInfo.BinariesSummary.BinariesCount));
        Assert.IsFalse(string.IsNullOrWhiteSpace(storageInfo.BinariesSummary.BinariesSize), nameof(storageInfo.BinariesSummary.BinariesSize));
        Assert.IsFalse(string.IsNullOrWhiteSpace(storageInfo.BinariesSummary.ArtifactsSize), nameof(storageInfo.BinariesSummary.ArtifactsSize));
        Assert.IsFalse(string.IsNullOrWhiteSpace(storageInfo.BinariesSummary.Optimization), nameof(storageInfo.BinariesSummary.Optimization));
        Assert.IsFalse(string.IsNullOrWhiteSpace(storageInfo.BinariesSummary.ItemsCount), nameof(storageInfo.BinariesSummary.ItemsCount));
        Assert.IsFalse(string.IsNullOrWhiteSpace(storageInfo.BinariesSummary.ArtifactsCount), nameof(storageInfo.BinariesSummary.ArtifactsCount));
    }

}
