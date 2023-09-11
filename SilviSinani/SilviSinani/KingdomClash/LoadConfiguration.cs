using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;

namespace SilviSinani.KingdomClash;

/// <summary>
///     This class is responsible for loading correctly the configuration of the game.
///     In case that the configuration doesn't exist, it will return a configuration
///     with the default values.
/// </summary>
public class LoadConfiguration
{
    /// <summary>
    ///     Load the Configuration or creates a default one.
    /// </summary>
    public LoadConfiguration()
    {
        try
        {
            var reader = new StreamReader(PathToFile, Encoding.UTF8);
            var jsonInput = reader.ReadToEnd();

            if (jsonInput.Equals(null))
            {
                Console.WriteLine("Configuration upload FAILURE");
                Console.WriteLine("New default configuration Created");
                Configuration = new GameConfiguration();
            }
            else
            {
                var dataInput = JsonSerializer.Deserialize<GameConfiguration>(jsonInput);
                if (dataInput == null)
                {
                    Console.WriteLine("Configuration upload FAILURE");
                    Console.WriteLine("New default configuration Created");
                    Configuration = new GameConfiguration();
                }
                else
                {
                    Configuration = dataInput;
                }
            }
        }
        catch (DirectoryNotFoundException directoryNotFoundException)
        {
            Configuration = new GameConfiguration();

            try
            {
                Directory.CreateDirectory(GetAppDataDirectory());
                var writer = new StreamWriter(PathToFile);
                var options = new JsonSerializerOptions { WriteIndented = true };
                writer.Write(JsonSerializer.Serialize(Configuration, options));
                writer.Close();
                Console.WriteLine("Configuration saving SUCCEEDED");
                Console.WriteLine("Avoiding: " + directoryNotFoundException.GetType());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Configuration saving FAILURE");
                Console.WriteLine(ex);
            }
        }
        catch (FileNotFoundException e)
        {
            Configuration = new GameConfiguration();

            try
            {
                var writer = new StreamWriter(PathToFile);
                var options = new JsonSerializerOptions { WriteIndented = true };
                writer.Write(JsonSerializer.Serialize(Configuration, options));
                writer.Close();
                Console.WriteLine("Configuration saving SUCCEEDED");
                Console.WriteLine("Avoiding: " + e.GetType());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Configuration saving FAILURE");
                Console.WriteLine(ex);
            }
        }
        catch (Exception exception)
        {
            Configuration = new GameConfiguration();
            try
            {
                var writer = new StreamWriter(PathToFile);
                var options = new JsonSerializerOptions { WriteIndented = true };
                writer.Write(JsonSerializer.Serialize(Configuration, options));
                writer.Close();
                Console.WriteLine("Configuration saving SUCCEEDED");
                Console.WriteLine("Avoiding: " + exception.GetType());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Configuration saving FAILURE");
                Console.WriteLine(ex);
            }
        }
    }

    /// <value>
    ///     The configuration of the game.
    /// </value>
    public GameConfiguration Configuration { get; }

    /// <value>
    /// The path to the configuration file.
    /// </value>
    public static readonly string PathToFile = Path.Combine(GetAppDataDirectory(), "configuration.json");


    /// <summary>
    ///     Detects the host's OS and returns a path to appdata folder.
    /// </summary>
    /// <returns> The path to the appdata folder. </returns>
    public static string GetAppDataDirectory()
    {
        string appData;

        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            appData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".local",
                "share");
        }
        else
        {
            appData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Library",
                "Application Support");
        }

        appData = Path.Combine(appData, "KingdomClash");

        return appData;
    }
}