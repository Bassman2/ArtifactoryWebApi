# GetVersionStringAsync Method


Retrieves the version information of the Artifactory system.



## Definition
**Namespace:** <a href="75b20af6-7197-02a5-e38f-f7b15eac4732">ArtifactoryWebApi</a>  
**Assembly:** ArtifactoryWebApi (in ArtifactoryWebApi.dll) Version: 0.1.0.0+14ac693bb5d14ba350f0d89917a9d924a973c73a

**C#**
``` C#
public override Task<string?> GetVersionStringAsync(
	CancellationToken cancellationToken = default
)
```
**VB**
``` VB
Public Overrides Function GetVersionStringAsync ( 
	Optional cancellationToken As CancellationToken = Nothing
) As Task(Of String)
```
**C++**
``` C++
public:
virtual Task<String^>^ GetVersionStringAsync(
	CancellationToken cancellationToken = CancellationToken()
) override
```
**F#**
``` F#
abstract GetVersionStringAsync : 
        ?cancellationToken : CancellationToken 
(* Defaults:
        let _cancellationToken = defaultArg cancellationToken new CancellationToken()
*)
-> Task<string> 
override GetVersionStringAsync : 
        ?cancellationToken : CancellationToken 
(* Defaults:
        let _cancellationToken = defaultArg cancellationToken new CancellationToken()
*)
-> Task<string> 
```



#### Parameters
<dl><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken" target="_blank" rel="noopener noreferrer">CancellationToken</a>  (Optional)</dt><dd>A token to cancel the operation.</dd></dl>

#### Return Value
<a href="https://learn.microsoft.com/dotnet/api/system.threading.tasks.task-1" target="_blank" rel="noopener noreferrer">Task</a>(<a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a>)  
A task that represents the asynchronous operation. The task result contains the <a href="856e526c-1728-dd8c-2a47-1f97b75f359f">ArtifactoryVersion</a> information, or null if not available.

## See Also


#### Reference
<a href="214800f8-17f4-d8c7-736d-e57a039a6686">Artifactory Class</a>  
<a href="75b20af6-7197-02a5-e38f-f7b15eac4732">ArtifactoryWebApi Namespace</a>  
