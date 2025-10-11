---
_layout: landing
---

# ArtifactoryWebApi is a .NET API for the Artifactory web service.
		
## Getting Started
To get started, add the ArtifactoryWebApi package to your project.
The followin example code shows how to read alle hardware information.</para>

    using ArtifactoryWebApi;
    ...
    +using (Artifactory client = new Artifactory(host, token, appName))
    {
        var repositoryList = client.GetRepositoriesAsync();
    }
