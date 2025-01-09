namespace ArtifactoryWebApiUnitTest;

[TestClass]
public class ArtifactoryProjectUnitTest : ArtifactoryBaseUnitTest
{
    [TestMethod]
    public async Task TestMethodGetProjectsAsync()
    {
        using var artifactory = new Artifactory(storeKey, appName);
        var res = await artifactory.GetProjectsAsync();

        var projects = res?.ToList();
        Assert.IsNotNull(projects);

        var project = projects.FirstOrDefault(p => p.ProjectKey == "project-a");
        Assert.IsNotNull(project);
        Assert.AreEqual("ProjectA", project.DisplayName, nameof(project.DisplayName));
        Assert.AreEqual("Project A for testing", project.Description, nameof(project.Description));
        Assert.IsNotNull(project.AdminPrivileges);
        Assert.AreEqual(true, project.AdminPrivileges.ManageMembers, nameof(project.AdminPrivileges.ManageMembers));
        Assert.AreEqual(true, project.AdminPrivileges.ManageResources, nameof(project.AdminPrivileges.ManageResources));
        Assert.AreEqual(true, project.AdminPrivileges.IndexResources, nameof(project.AdminPrivileges.IndexResources));
        Assert.AreEqual(1073741824, project.StorageQuotaBytes, nameof(project.StorageQuotaBytes));
        Assert.AreEqual(false, project.SoftLimit, nameof(project.SoftLimit));
        Assert.AreEqual(true, project.StorageQuotaEmailNotification, nameof(project.StorageQuotaEmailNotification));
        Assert.AreEqual("project-a", project.ProjectKey, nameof(project.ProjectKey));
    }

    [TestMethod]
    public async Task TestMethodGetProjectAsync()
    {
        using var artifactory = new Artifactory(storeKey, appName);
        var project = await artifactory.GetProjectAsync("project-a");

        
        Assert.IsNotNull(project);
        Assert.AreEqual("ProjectA", project.DisplayName, nameof(project.DisplayName));
        Assert.AreEqual("Project A for testing", project.Description, nameof(project.Description));
        Assert.IsNotNull(project.AdminPrivileges);
        Assert.AreEqual(true, project.AdminPrivileges.ManageMembers, nameof(project.AdminPrivileges.ManageMembers));
        Assert.AreEqual(true, project.AdminPrivileges.ManageResources, nameof(project.AdminPrivileges.ManageResources));
        Assert.AreEqual(true, project.AdminPrivileges.IndexResources, nameof(project.AdminPrivileges.IndexResources));
        Assert.AreEqual(1073741824, project.StorageQuotaBytes, nameof(project.StorageQuotaBytes));
        Assert.AreEqual(false, project.SoftLimit, nameof(project.SoftLimit));
        Assert.AreEqual(true, project.StorageQuotaEmailNotification, nameof(project.StorageQuotaEmailNotification));
        Assert.AreEqual("project-a", project.ProjectKey, nameof(project.ProjectKey));

    }


    [TestMethod]
    public async Task TestMethodCreateAndDeleteProjectAsync()
    {
        using var artifactory = new Artifactory(storeKey, appName);

        var created = await artifactory.CreateProjectAsync("project-x", "xxxx", "xxxxxxxx");
        Assert.IsNotNull(created);
        Assert.AreEqual("xxxx", created.DisplayName, nameof(created.DisplayName));
        Assert.AreEqual("xxxxxxxx", created.Description, nameof(created.Description));
        Assert.IsNotNull(created.AdminPrivileges);
        Assert.AreEqual(true, created.AdminPrivileges.ManageMembers, nameof(created.AdminPrivileges.ManageMembers));
        Assert.AreEqual(true, created.AdminPrivileges.ManageResources, nameof(created.AdminPrivileges.ManageResources));
        Assert.AreEqual(true, created.AdminPrivileges.IndexResources, nameof(created.AdminPrivileges.IndexResources));
        Assert.AreEqual(1073741824, created.StorageQuotaBytes, nameof(created.StorageQuotaBytes));
        Assert.AreEqual(false, created.SoftLimit, nameof(created.SoftLimit));
        Assert.AreEqual(true, created.StorageQuotaEmailNotification, nameof(created.StorageQuotaEmailNotification));
        Assert.AreEqual("project-x", created.ProjectKey, nameof(created.ProjectKey));

        var project = await artifactory.GetProjectAsync("project-x");
        Assert.IsNotNull(project);
        Assert.AreEqual("xxxx", project.DisplayName, nameof(project.DisplayName));
        Assert.AreEqual("xxxxxxxx", project.Description, nameof(project.Description));
        Assert.IsNotNull(project.AdminPrivileges);
        Assert.AreEqual(true, project.AdminPrivileges.ManageMembers, nameof(project.AdminPrivileges.ManageMembers));
        Assert.AreEqual(true, project.AdminPrivileges.ManageResources, nameof(project.AdminPrivileges.ManageResources));
        Assert.AreEqual(true, project.AdminPrivileges.IndexResources, nameof(project.AdminPrivileges.IndexResources));
        Assert.AreEqual(1073741824, project.StorageQuotaBytes, nameof(project.StorageQuotaBytes));
        Assert.AreEqual(false, project.SoftLimit, nameof(project.SoftLimit));
        Assert.AreEqual(true, project.StorageQuotaEmailNotification, nameof(project.StorageQuotaEmailNotification));
        Assert.AreEqual("project-x", project.ProjectKey, nameof(project.ProjectKey));
        
        await artifactory.DeleteProjectAsync("project-x");

        try
        {
            var deleted = await artifactory.GetProjectAsync("project-x");
            Assert.IsNotNull(null);
        }
        catch 
        {
        }

    }
}
