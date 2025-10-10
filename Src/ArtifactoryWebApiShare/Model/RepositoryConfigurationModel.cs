namespace ArtifactoryWebApi.Model;

internal class RepositoryConfigurationModel
{
    [JsonPropertyName("key")]
    public string? Key { get; set; }

    [JsonPropertyName("packageType")]
    public PackageType PackageType { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

    [JsonPropertyName("includesPattern")]
    public string? IncludesPattern { get; set; }

    [JsonPropertyName("excludesPattern")]
    public string? ExcludesPattern { get; set; }

    [JsonPropertyName("repoLayoutRef")]
    public string? RepoLayoutRef { get; set; }

    [JsonPropertyName("signedUrlTtl")]
    public int? SignedUrlTtl { get; set; }

    [JsonPropertyName("enableComposerSupport")]
    public bool EnableComposerSupport { get; set; }

    [JsonPropertyName("enableNuGetSupport")]
    public bool EnableNuGetSupport { get; set; }

    [JsonPropertyName("enableGemsSupport")]
    public bool EnableGemsSupport { get; set; }

    [JsonPropertyName("enableNpmSupport")]
    public bool EnableNpmSupport { get; set; }

    [JsonPropertyName("enableBowerSupport")]
    public bool EnableBowerSupport { get; set; }

    [JsonPropertyName("enableChefSupport")]
    public bool EnableChefSupport { get; set; }

    [JsonPropertyName("enableCocoaPodsSupport")]
    public bool EnableCocoaPodsSupport { get; set; }

    [JsonPropertyName("enableConanSupport")]
    public bool EnableConanSupport { get; set; }

    [JsonPropertyName("enableDebianSupport")]
    public bool EnableDebianSupport { get; set; }

    [JsonPropertyName("debianTrivialLayout")]
    public bool DebianTrivialLayout { get; set; }

    [JsonPropertyName("ddebSupported")]
    public bool DdebSupported { get; set; }

    [JsonPropertyName("enablePypiSupport")]
    public bool EnablePypiSupport { get; set; }

    [JsonPropertyName("enablePuppetSupport")]
    public bool EnablePuppetSupport { get; set; }

    [JsonPropertyName("enableDockerSupport")]
    public bool EnableDockerSupport { get; set; }

    [JsonPropertyName("dockerApiVersion")]
    public string? DockerApiVersion { get; set; }

    [JsonPropertyName("blockPushingSchema1")]
    public bool BlockPushingSchema1 { get; set; }

    [JsonPropertyName("forceNugetAuthentication")]
    public bool ForceNugetAuthentication { get; set; }

    [JsonPropertyName("enableNormalizedVersion")]
    public bool EnableNormalizedVersion { get; set; }

    [JsonPropertyName("forceP2Authentication")]
    public bool ForceP2Authentication { get; set; }

    [JsonPropertyName("forceConanAuthentication")]
    public bool ForceConanAuthentication { get; set; }

    [JsonPropertyName("enableVagrantSupport")]
    public bool EnableVagrantSupport { get; set; }

    [JsonPropertyName("enableGitLfsSupport")]
    public bool EnableGitLfsSupport { get; set; }

    [JsonPropertyName("enableDistRepoSupport")]
    public bool EnableDistRepoSupport { get; set; }

    [JsonPropertyName("dockerProjectId")]
    public string? DockerProjectId { get; set; }

    [JsonPropertyName("priorityResolution")]
    public bool PriorityResolution { get; set; }

    [JsonPropertyName("environments")]
    public List<string>? Environments { get; set; }

    [JsonPropertyName("handleReleases")]
    public bool HandleReleases { get; set; }

    [JsonPropertyName("handleSnapshots")]
    public bool HandleSnapshots { get; set; }

    [JsonPropertyName("maxUniqueSnapshots")]
    public int MaxUniqueSnapshots { get; set; }

    [JsonPropertyName("maxUniqueTags")]
    public int MaxUniqueTags { get; set; }

    [JsonPropertyName("snapshotVersionBehavior")]
    public string? SnapshotVersionBehavior { get; set; }

    [JsonPropertyName("suppressPomConsistencyChecks")]
    public bool SuppressPomConsistencyChecks { get; set; }

    [JsonPropertyName("blackedOut")]
    public bool BlackedOut { get; set; }

    [JsonPropertyName("propertySets")]
    public List<string>? PropertySets { get; set; }

    [JsonPropertyName("archiveBrowsingEnabled")]
    public bool ArchiveBrowsingEnabled { get; set; }

    [JsonPropertyName("calculateYumMetadata")]
    public bool CalculateYumMetadata { get; set; }

    [JsonPropertyName("enableFileListsIndexing")]
    public bool EnableFileListsIndexing { get; set; }

    [JsonPropertyName("YumRootDepth")]
    public int YumRootDepth { get; set; }

    [JsonPropertyName("dockerTagRetention")]
    public int DockerTagRetention { get; set; }

    [JsonPropertyName("enableComposerV1Indexing")]
    public bool EnableComposerV1Indexing { get; set; }

    [JsonPropertyName("terraformType")]
    public string? TerraformType { get; set; }

    [JsonPropertyName("encryptStates")]
    public bool EncryptStates { get; set; }

    [JsonPropertyName("downloadRedirect")]
    public bool DownloadRedirect { get; set; }

    [JsonPropertyName("cdnRedirect")]
    public bool CdnRedirect { get; set; }

    [JsonPropertyName("cargoInternalIndex")]
    public bool CargoInternalIndex { get; set; }

    [JsonPropertyName("xrayDataTtl")]
    public int XrayDataTtl { get; set; }

    [JsonPropertyName("cargoAnonymousAccess")]
    public bool CargoAnonymousAccess { get; set; }

    [JsonPropertyName("xrayIndex")]
    public bool XrayIndex { get; set; }

    [JsonPropertyName("rclass")]
    public string? RClass { get; set; }

    
}
