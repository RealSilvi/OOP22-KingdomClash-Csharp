using Newtonsoft.Json;
using SilviSinani.KingdomClash;

namespace SilviSinaniTest.KingdomClash;

public class ConfigurationTest
{
    [Test, Description("Tests that can handle problems if the directory is missing.")]
    public void CanCreateDirectoryTest()
    {
        if (Directory.Exists(LoadConfiguration.GetAppDataDirectory()))
        {
            Directory.Delete(LoadConfiguration.GetAppDataDirectory(), true);
        }

        var loader = new LoadConfiguration();

        Assert.That(Directory.Exists(LoadConfiguration.GetAppDataDirectory()), Is.True);
    }

    [Test, Description("Tests that can handle problems if the file is missing.")]
    public void CanCreateFileTest()
    {
        if (File.Exists(LoadConfiguration.PathToFile))
        {
            File.Delete(LoadConfiguration.PathToFile);
        }

        var loader = new LoadConfiguration();

        Assert.That(File.Exists(LoadConfiguration.PathToFile), Is.True);
    }

    [Test, Description("Tests that can create a default configuration file.")]
    public void CanCreateDefaultConfigurationTest()
    {
        if (File.Exists(LoadConfiguration.PathToFile))
        {
            File.Delete(LoadConfiguration.PathToFile);
        }

        var loader = new LoadConfiguration();

        Assert.That(File.Exists(LoadConfiguration.PathToFile), Is.True);

        Assert.That(
            JsonConvert.SerializeObject(new GameConfiguration()),
            Is.EqualTo(JsonConvert.SerializeObject(loader.Configuration))
        );
    }

    [Test, Description("Tests that can upload correctly a configuration file.")]
    public void CanUploadConfigurationTest()
    {
        var loaderA = new LoadConfiguration();

        var loaderB = new LoadConfiguration();

        Assert.That(
            JsonConvert.SerializeObject(loaderA.Configuration),
            Is.EqualTo(JsonConvert.SerializeObject(loaderB.Configuration))
        );
    }
}