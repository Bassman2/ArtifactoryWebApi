# GetFileStreamAsync(String, String, CancellationToken) Method


Retrieves a file stream from the Artifactory system.



## Definition
**Namespace:** <a href="75b20af6-7197-02a5-e38f-f7b15eac4732">ArtifactoryWebApi</a>  
**Assembly:** ArtifactoryWebApi (in ArtifactoryWebApi.dll) Version: 0.1.0.0+14ac693bb5d14ba350f0d89917a9d924a973c73a

**C#**
``` C#
public Task<Stream> GetFileStreamAsync(
	string repo,
	string path,
	CancellationToken cancellationToken = default
)
```
**VB**
``` VB
Public Function GetFileStreamAsync ( 
	repo As String,
	path As String,
	Optional cancellationToken As CancellationToken = Nothing
) As Task(Of Stream)
```
**C++**
``` C++
public:
Task<Stream^>^ GetFileStreamAsync(
	String^ repo, 
	String^ path, 
	CancellationToken cancellationToken = CancellationToken()
)
```
**F#**
``` F#
member GetFileStreamAsync : 
        repo : string * 
        path : string * 
        ?cancellationToken : CancellationToken 
(* Defaults:
        let _cancellationToken = defaultArg cancellationToken new CancellationToken()
*)
-> Task<Stream> 
```



#### Parameters
<dl><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a></dt><dd>The repository where the file is located.</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a></dt><dd>The path of the file within the repository.</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken" target="_blank" rel="noopener noreferrer">CancellationToken</a>  (Optional)</dt><dd>A token to cancel the operation.</dd></dl>

#### Return Value
<a href="https://learn.microsoft.com/dotnet/api/system.threading.tasks.task-1" target="_blank" rel="noopener noreferrer">Task</a>(<a href="https://learn.microsoft.com/dotnet/api/system.io.stream" target="_blank" rel="noopener noreferrer">Stream</a>)  
A task that represents the asynchronous operation. The task result contains the file stream.

## See Also


#### Reference
<a href="214800f8-17f4-d8c7-736d-e57a039a6686">Artifactory Class</a>  
<a href="5e008d70-c9a0-d4d8-7b98-e997625fe002">GetFileStreamAsync Overload</a>  
<a href="75b20af6-7197-02a5-e38f-f7b15eac4732">ArtifactoryWebApi Namespace</a>  
