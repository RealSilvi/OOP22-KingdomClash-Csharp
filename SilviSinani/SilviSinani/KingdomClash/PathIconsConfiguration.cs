namespace SilviSinani.KingdomClash;

/// <summary>
///      Configuration of the icon paths.
/// </summary>
public class PathIconsConfiguration
{
    private const string TexturesDirectoryProjectPath = "/SilviSinani/KingdomClash/Textures/";

    private readonly Dictionary<TroopType, string> _troops;


    /// <summary>
    ///     Create a default configuration.
    /// </summary>
    public PathIconsConfiguration()
    {
        var texturesDirectory = GetSolutionPath() + TexturesDirectoryProjectPath;
        var battleDirectory = texturesDirectory + "Battle/";
        var battleTroopsDirectory = battleDirectory + "Troops/";
        var battleLabelDirectory = battleDirectory + "Labels/";
        var battleButtonsDirectory = battleDirectory + "Buttons/";

        BackgroundFillPattern = battleDirectory + "Background.png";
        Pass = battleButtonsDirectory + "Pass.png";
        Spin = battleButtonsDirectory + "Spin.png";
        Info = battleButtonsDirectory + "Info.png";
        Exit = battleButtonsDirectory + "Exit.png";
        Check = battleLabelDirectory + "Check.png";
        X = battleLabelDirectory + "X.png";
        Indicator = battleLabelDirectory + "Indicator.png";
        Life = battleLabelDirectory + "Life.png";
        Death = battleLabelDirectory + "Death.png";

        _troops = new Dictionary<TroopType, string>()
        {
            [TroopType.AXE] = battleTroopsDirectory + "Axe.png",
            [TroopType.SWORD] = battleTroopsDirectory + "Sword.png",
            [TroopType.HAMMER] = battleTroopsDirectory + "Hammer.png",
            [TroopType.MACE] = battleTroopsDirectory + "Mace.png",
            [TroopType.AXE_DEFENCE] = battleTroopsDirectory + "Shield01.png",
            [TroopType.SWORD_DEFENCE] = battleTroopsDirectory + "Shield02.png",
            [TroopType.HAMMER_DEFENCE] = battleTroopsDirectory + "Shield03.png",
            [TroopType.MACE_DEFENCE] = battleTroopsDirectory + "Helmet.png",
        };
    }

    /// <value>
    ///     Property <c>BackgroundFillPattern</c> represents the path
    ///     to the background fill pattern's texture of battle.
    /// </value>
    public string BackgroundFillPattern { get; }

    /// <value>
    ///     Property <c>Pass</c> represents
    ///     the path to the pass button's texture of battle.
    /// </value>
    public string Pass { get; }

    /// <value>
    ///     Property <c>Spin</c> represents
    ///     the path to the spin button's texture of battle.
    /// </value>
    public string Spin { get; }

    /// <value>
    ///     Property <c>Info</c>  represents
    ///     the path to the info button's texture of battle.
    /// </value>
    public string Info { get; }

    /// <value>
    ///     Property <c>Exit</c> represents
    ///     the path to the exit button's texture of battle.
    /// </value>
    public string Exit { get; }

    /// <value>
    ///     Property <c>Check</c> represents
    ///     the path to the check button's texture of battle.
    /// </value>
    public string Check { get; }

    /// <value>
    ///     Property <c>X</c> represents
    ///     the path to the X button's texture of battle.
    /// </value>
    public string X { get; }

    /// <value>
    ///     Property <c>Indicator</c> represents
    ///     the path to the indicator button's texture of battle.
    /// </value>
    public string Indicator { get; }

    /// <value>
    ///     Property <c>Life</c> represents
    ///     the path to the life label's texture of battle.
    /// </value>
    public string Life { get; }

    /// <value>
    ///     Property <c>Death</c> represents
    ///     the path to the death label's texture of battle.
    /// </value>
    public string Death { get; }

    /// <summary>
    ///     Represents the path to the Troop's texture.
    /// </summary>
    /// <param name="troop"> Indicates the required troop's texture. </param>
    /// <returns> The path to texture of the troop required.</returns>
    public string GetTroop(TroopType troop)
    {
        return _troops[troop];
    }

    private static string GetSolutionPath()
    {
        var directory = new DirectoryInfo(Directory.GetCurrentDirectory());

        while (directory != null && !directory.GetFiles("*.sln").Any())
        {
            directory = directory.Parent;
        }

        if (directory == null)
        {
            throw new DirectoryNotFoundException();
        }

        return directory.FullName;
    }
}