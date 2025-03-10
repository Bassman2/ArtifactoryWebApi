﻿namespace ArtifactoryWebApiUnitTest;

public abstract class ArtifactoryBaseUnitTest
{
    protected static readonly CultureInfo culture = new CultureInfo("en-US");
    
    protected const string storeKey = "artifactory-trial";
    protected const string testRepoKey = "local-generic-test";
    protected const PackageType testRepoType = PackageType.Generic;
    protected const string appName = "UnitTest";


    protected static readonly string testHost = KeyStore.Key(storeKey)!.Host!;
    protected static readonly string testUserKey = KeyStore.Key(storeKey)!.Login!;
    protected static readonly string testUserDisplayName = KeyStore.Key(storeKey)!.User!;
    protected static readonly string testUserEmail = KeyStore.Key(storeKey)!.Email!;

    protected static readonly Uri baseUri = new(testHost);
    protected static readonly Uri apiUri = new(baseUri, "rest/api/2/");

    protected static readonly string repoKeyDynamic = "local-generic-test-dynamic";
    protected static readonly string repoKeyFix = "local-generic-test-fix";


}
