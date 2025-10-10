namespace ArtifactoryWebApi.Model;

internal class MessagesRoot
{
    [JsonPropertyName("messages")]
    public List<MessageModel>? Messages { get; set; }
}
