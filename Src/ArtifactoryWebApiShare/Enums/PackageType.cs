namespace ArtifactoryWebApi;


/// <summary>
/// Represents the type of a package in the Artifactory system.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter<PackageType>))]
public enum PackageType
{
    /// <summary>
    /// Not applicable or unspecified package type.
    /// </summary>
    NA,

    /// <summary>
    /// Represents a Bower package.
    /// </summary>
    Bower,

    /// <summary>
    /// Represents build information.
    /// </summary>
    BuildInfo,

    /// <summary>
    /// Represents a Cargo package.
    /// </summary>
    Cargo,

    /// <summary>
    /// Represents a Chef package.
    /// </summary>
    Chef,

    /// <summary>
    /// Represents a CocoaPods package.
    /// </summary>
    Cocoapods,

    /// <summary>
    /// Represents a Composer package.
    /// </summary>
    Composer,

    /// <summary>
    /// Represents a Conan package.
    /// </summary>
    Conan,

    /// <summary>
    /// Represents a CRAN package.
    /// </summary>
    Cran,

    /// <summary>
    /// Represents a custom package type.
    /// </summary>
    Custom,

    /// <summary>
    /// Represents a Debian package.
    /// </summary>
    Debian,

    /// <summary>
    /// Represents a distribution package.
    /// </summary>
    Distribution,

    /// <summary>
    /// Represents a Docker package.
    /// </summary>
    Docker,

    /// <summary>
    /// Represents a RubyGems package.
    /// </summary>
    Gems,

    /// <summary>
    /// Represents a Git LFS (Large File Storage) package.
    /// </summary>
    Gitlfs,

    /// <summary>
    /// Represents a Go package.
    /// </summary>
    Go,

    /// <summary>
    /// Represents a Gradle package.
    /// </summary>
    Gradle,

    /// <summary>
    /// Represents a Helm package.
    /// </summary>
    Helm,

    /// <summary>
    /// Represents an Ivy package.
    /// </summary>
    Ivy,

    /// <summary>
    /// Represents a Maven package.
    /// </summary>
    Maven,

    /// <summary>
    /// Represents an NPM (Node Package Manager) package.
    /// </summary>
    Npm,

    /// <summary>
    /// Represents a NuGet package.
    /// </summary>
    NuGet,

    /// <summary>
    /// Represents an OCI (Open Container Initiative) package.
    /// </summary>
    Oci,

    /// <summary>
    /// Represents an Opkg package.
    /// </summary>
    Opkg,

    /// <summary>
    /// Represents a P2 package.
    /// </summary>
    P2,

    /// <summary>
    /// Represents a Pub package.
    /// </summary>
    Pub,

    /// <summary>
    /// Represents a Puppet package.
    /// </summary>
    Puppet,

    /// <summary>
    /// Represents a PyPI (Python Package Index) package.
    /// </summary>
    Pypi,

    /// <summary>
    /// Represents an SBT (Scala Build Tool) package.
    /// </summary>
    Sbt,

    /// <summary>
    /// Represents a Swift package.
    /// </summary>
    Swift,

    /// <summary>
    /// Represents a Terraform package.
    /// </summary>
    Terraform,

    /// <summary>
    /// Represents a Terraform backend package.
    /// </summary>
    TerraformBackend,

    /// <summary>
    /// Represents a Vagrant package.
    /// </summary>
    Vagrant,

    /// <summary>
    /// Represents a VCS (Version Control System) package.
    /// </summary>
    Vcs,

    /// <summary>
    /// Represents a Yum package.
    /// </summary>
    Yum,

    /// <summary>
    /// Represents a generic package type.
    /// </summary>
    Generic
}
