# Welcome to the ArtifactoryWebApi

ArtifactoryWebApi is a .NET API for the Artifactory web service.


## Getting Started

To get started, add the ArtifactoryWebApi package to your project.

The followin example code shows how to read alle hardware information.



**C#**  
``` C#
using ArtifactoryWebApi;
...
using (Artifactory client = new Artifactory(host, token, appName))
{
    var repositoryList = client.GetRepositoriesAsync();
}
```



## See Also


#### Other Resources
<a href="1b51e55c-2c51-42b2-8800-ee2d7afdaca3">VersionHistory</a>  
