﻿namespace ArtifactoryWebApi.Service.Model;

internal class ChecksumsModel
{
    [JsonPropertyName("md5")]
    public string? Md5 { get; set; }

    [JsonPropertyName("sha1")]
    public string? Sha1 { get; set; }

    [JsonPropertyName("sha256")]
    public string? Sha256 { get; set; }
}
