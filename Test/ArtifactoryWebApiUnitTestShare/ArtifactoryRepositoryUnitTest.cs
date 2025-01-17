﻿namespace ArtifactoryWebApiUnitTest;

[TestClass]
public class ArtifactoryRepositoryUnitTest : ArtifactoryBaseUnitTest
{
    [TestMethod]
    public async Task TestMethodGetRepositoriesAsync()
    {
        using var artifactory = new Artifactory(storeKey, appName);
        var res = await artifactory.GetRepositoriesAsync();

        var repos = res?.ToList();
        Assert.IsNotNull(repos);

        var repo = repos.FirstOrDefault(p => p.Key == testRepoKey);
        Assert.IsNotNull(repo);
        Assert.AreEqual(testRepoKey, repo.Key, nameof(repo.Key));
        Assert.AreEqual("", repo.Description, nameof(repo.Description));
        Assert.AreEqual(RepositoryType.LOCAL, repo.Type, nameof(repo.Type));
        Assert.AreEqual(new Uri(new Uri(testHost), $"/artifactory/{testRepoKey}"), repo.Url, nameof(repo.Url));
        Assert.AreEqual(testRepoType, repo.PackageType, nameof(repo.PackageType));
    }

    [TestMethod]
    public async Task TestMethodGetRepositoryConfigurationAsync()
    {
        using var artifactory = new Artifactory(storeKey, appName);
        var repo = await artifactory.GetRepositoryConfigurationAsync(testRepoKey);

        Assert.IsNotNull(repo);
        Assert.AreEqual(testRepoKey, repo.Key, nameof(repo.Key));
        Assert.AreEqual("", repo.Description, nameof(repo.Description));
        //Assert.AreEqual(RepositoryType.LOCAL, repo.Type, nameof(repo.Type));
        //Assert.AreEqual(new Uri(new Uri(testHost), $"/artifactory/{testRepoKey}"), repo..Url, nameof(repo.Url));
        Assert.AreEqual(testRepoType, repo.PackageType, nameof(repo.PackageType));
    }

    //[TestMethod]
    //public async Task TestMethodGetAllRepositoryConfigurationsAsync()
    //{
    //    using var artifactory = new Artifactory(storeKey);
    //    var repo = await artifactory.GetAllRepositoryConfigurationsAsync();

    //    Assert.IsNotNull(repo);
    //    Assert.AreEqual(testRepoKey, repo.Key, nameof(repo.Key));
    //    Assert.AreEqual("", repo.Description, nameof(repo.Description));
    //    //Assert.AreEqual(RepositoryType.LOCAL, repo.Type, nameof(repo.Type));
    //    //Assert.AreEqual(new Uri(new Uri(testHost), $"/artifactory/{testRepoKey}"), repo..Url, nameof(repo.Url));
    //    Assert.AreEqual(testRepoType, repo.PackageType, nameof(repo.PackageType));
    //}

    //[TestMethod]
    //public async Task TestMethodCreateRepositoryAsync()
    //{
    //    string repoKeyCreate = "local-generic-create";

    //    using var artifactory = new Artifactory(storeKey);

    //    var repo = await artifactory.CreateRepositoryAsync(repoKeyCreate, RepositoryType.LOCAL, PackageType.Generic, "Creation test repository");

    //    Assert.IsNotNull(repo);
    //    Assert.AreEqual(testRepoKey, repo.Key, nameof(repo.Key));
    //    Assert.AreEqual("", repo.Description, nameof(repo.Description));
    //    //Assert.AreEqual(RepositoryType.LOCAL, repo.Type, nameof(repo.Type));
    //    //Assert.AreEqual(new Uri(new Uri(testHost), $"/artifactory/{testRepoKey}"), repo..Url, nameof(repo.Url));
    //    Assert.AreEqual(testRepoType, repo.PackageType, nameof(repo.PackageType));

    //    bool exist = await artifactory.ExistsRepositoryAsync(repoKeyCreate);
    //    Assert.IsTrue(exist);

    //    await artifactory.DeleteRepositoryAsync(repoKeyCreate);

    //    exist = await artifactory.ExistsRepositoryAsync(repoKeyCreate);
    //    Assert.IsFalse(exist);
    //}

    /*
    [TestMethod]
    public async Task TestMethodGetProjectsAsync()
    {
        using var jira = new Jira(storeKey);

        var repo = await jira.GetProjectsAsync();

        var projects = repo?.ToList();
        Assert.IsNotNull(projects);

        var project = projects.FirstOrDefault(p => p.Key == testProjectKey);
        Assert.IsNotNull(project);
        Assert.AreEqual(new Uri(apiUri, "project/25411"), project.Self, nameof(project.Self));
        Assert.AreEqual("25411", project.Id, nameof(project.Id));
        Assert.AreEqual("Navigation Suite", project.Name, nameof(project.Name));
        Assert.AreEqual("NAVSUITE", project.Key, nameof(project.Key));
        Assert.AreEqual(null, project.Description, nameof(project.Description));
        Assert.AreEqual(null, project.Url, nameof(project.Url));
        Assert.AreEqual(null, project.Email, nameof(project.Email));
        Assert.AreEqual(null, project.AssigneeType, nameof(project.AssigneeType));
    }
    */
}
