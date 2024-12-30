namespace ArtifactoryWebApi;


[JsonConverter(typeof(JsonStringEnumConverter<PackageType>))]
public enum PackageType
{
    NA,

    // bower|cargo|chef|cocoapods|composer|conan|cran|debian|docker|gems|gitlfs|go|gradle|helm|ivy|maven|nuget|opkg|p2|pub|puppet|pypi|rpm|sbt|swift| terraform|vagrant|yum|generic

    Bower,
    BuildInfo,
    Cargo,
    Chef,
    Cocoapods,
    Composer,
    Conan,
    Cran,
    Custom, // ???
    Debian,
    Distribution, // ??
    Docker,
    Gems,    
    Gitlfs, 
    Go,
    Gradle,
    Helm,
    Ivy,
    Maven,
    Npm,        // ??
    NuGet,
    Oci,        // ??
    Opkg,
    P2,
    Pub,       
    Puppet,
    Pypi,
    Sbt,
    Swift,
    Terraform,
    TerraformBackend,
    Vagrant,
    Vcs,        // ??
    Yum,
    
    Generic
}
