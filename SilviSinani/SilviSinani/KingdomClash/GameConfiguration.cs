namespace SilviSinani.KingdomClash;

/// <summary>
///     Configuration of the game.
/// </summary>
public class GameConfiguration
{
    /// <value>
    ///     The configuration of texts in the Battle panels.
    /// </value>
    public TextBattleConfiguration TextBattleConfiguration { get; }

    /// <value>
    ///     The paths of all the textures.
    /// </value>
    public PathIconsConfiguration PathIconsConfiguration { get; }

/// <summary>
///     Construct a configuration with default values.
/// </summary>
    public GameConfiguration()
    {
        TextBattleConfiguration = new TextBattleConfiguration();
        PathIconsConfiguration = new PathIconsConfiguration();
    }
}