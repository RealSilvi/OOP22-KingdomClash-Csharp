using SilviSinani.KingdomClash;

namespace SilviSinaniTest.KingdomClash;

/**
 * Tests PathIconsConfiguration in SilviSinani project
 */
public class PathIconsConfigurationTest
{
    [Test, Description("Tests if the textures exists and has image type.")]
    public void TexturesExistTest()
    {
        var pathIcons = new LoadConfiguration().Configuration.PathIconsConfiguration;

        Assert.IsTrue(File.Exists(pathIcons.Check) && HasImageExtension(pathIcons.Check));
        Assert.IsTrue(File.Exists(pathIcons.Life) && HasImageExtension(pathIcons.Life));
        Assert.IsTrue(File.Exists(pathIcons.Death) && HasImageExtension(pathIcons.Death));
        Assert.IsTrue(File.Exists(pathIcons.Exit) && HasImageExtension(pathIcons.Exit));
        Assert.IsTrue(File.Exists(pathIcons.X) && HasImageExtension(pathIcons.X));
        Assert.IsTrue(File.Exists(pathIcons.Indicator) && HasImageExtension(pathIcons.Indicator));
        Assert.IsTrue(File.Exists(pathIcons.Info) && HasImageExtension(pathIcons.Info));
        Assert.IsTrue(File.Exists(pathIcons.Pass) && HasImageExtension(pathIcons.Pass));
        Assert.IsTrue(File.Exists(pathIcons.Spin) && HasImageExtension(pathIcons.Spin));
        Assert.IsTrue(
            File.Exists(pathIcons.BackgroundFillPattern) && HasImageExtension(pathIcons.BackgroundFillPattern));

        foreach (var troop in Enum.GetNames<TroopType>())
        {
            Assert.IsTrue(File.Exists(pathIcons.GetTroop(Enum.Parse<TroopType>(troop)))
                          && HasImageExtension(pathIcons.GetTroop(Enum.Parse<TroopType>(troop))));
        }
    }

    private static bool HasImageExtension(string fileName)
    {
        var extension = fileName.EndsWith(".png")
                        || fileName.EndsWith(".jpg")
                        || fileName.EndsWith(".gif")
                        || fileName.EndsWith(".svg")
                        || fileName.EndsWith(".jpeg");

        if (!extension)
        {
            throw new AssertionException("Failed asserting that " + fileName + " has image type");
        }

        return extension;
    }
}