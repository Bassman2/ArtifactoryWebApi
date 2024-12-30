using JFrogArtifactory;

namespace ArtifactoryConsole
{
    internal class Program
    {
        static void Main()
        {
            string host = Environment.GetEnvironmentVariable("ARTIFACTORY_HOST") ?? throw new Exception("Environment variable ARTIFACTORY_HOST missing!");
            string apiKey = Environment.GetEnvironmentVariable("ARTIFACTORY_APIKEY") ?? throw new Exception("Environment variable ARTIFACTORY_APIKEY missing!");

            using var artifactory = new Artifactory(new Uri(host), apiKey);

        }
    }
}
