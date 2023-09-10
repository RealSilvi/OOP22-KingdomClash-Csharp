namespace SilviSinani.KingdomClash;

/// <summary>
///     Configuration of text areas in the battle.
/// </summary>
public class TextBattleConfiguration
{
    /// <summary>
    ///     Set's the default configuration.
    /// </summary>
    public TextBattleConfiguration()
    {
        TutorialNorthTitle = "Enemy Troops.";
        TutorialNorthText = "You can see which troops the enemy can choose.";
        TutorialSouthTitle = "Player Troops.";
        TutorialSouthText = "Every round the unlocked slots will refresh and "
                            + "give you the possibility to choose new troops "
                            + "which will add to the Battle Field.When you click"
                            + " on a troop the slot will be locked until the battle"
                            + "ends. When the battle ends all the slots will"
                            + " unlocked and refresh.";
        TutorialWestTitle = "Power Table.";
        TutorialWestText = "In this table you can see if you troops are enough "
                           + "powerful to win every comparison.";
        TutorialEastTitle = "Main Info.";
        TutorialEastText = "Here you see your life and enemies life. ì"
                           + "When somebody finish his lives the entire battle "
                           + "ends and there's a winner.";
        TutorialCenterTitle = "Battle Field.";
        TutorialCenterText = "Every round the troops you'll choose will be added "
                             + "in the Battle Field.Every 3 rounds or when both the "
                             + "players doesnt have more possibility to chose new "
                             + "troops the battle will start. The combat effectiveness "
                             + "of each troop is compared to the level of the opponent's"
                             + " troops. If two troops of the same level clash, they "
                             + "cancel each other out. However, if one troop has a "
                             + "higher level than the other, it prevails over the other. "
                             + "The outcome of the combat and the relations between one"
                             + " troop and another is displayed in the information panel. ";
        EndWinPanelTitle = "YOU WIN";
        EndWinPanelText = " ";
        EndLosePanelTitle = "YOU LOSE ";
        EndLosePanelText = "";
    }


    /// <value>
    ///     Property <c>TutorialNorthTitle</c> represents
    ///     the title of the north Panel of Tutorial.
    /// </value>
    public string TutorialNorthTitle { get; }

    /// <value>
    ///     Property <c>TutorialNorthText</c> represents
    ///     the text of the north Panel of Tutorial.
    /// </value>
    public string TutorialNorthText { get; }

    /// <value>
    ///     Property <c>TutorialSouthTitle</c> represents
    ///     the title of the south Panel of Tutorial.
    /// </value>
    public string TutorialSouthTitle { get; }

    /// <value>
    ///     Property <c>TutorialSouthText</c> represents
    ///     the text of the south Panel of Tutorial.
    /// </value>
    public string TutorialSouthText { get; }

    /// <value>
    ///     Property <c>TutorialEastTitle</c> represents
    ///     the title of the east Panel of Tutorial.
    /// </value>
    public string TutorialEastTitle { get; }

    /// <value>
    ///     Property <c>TutorialEastText</c> represents
    ///     the text of the east Panel of Tutorial.
    /// </value>
    public string TutorialEastText { get; }

    /// <value>
    ///     Property <c>TutorialWestTitle</c> represents
    ///     the title of the west Panel of Tutorial.
    /// </value>
    public string TutorialWestTitle { get; }

    /// <value>
    ///     Property <c>TutorialWestText</c> represents
    ///     the text of the west Panel of Tutorial.
    /// </value>
    public string TutorialWestText { get; }

    /// <value>
    ///     Property <c>TutorialCenterTitle</c> represents
    ///     the title of the center Panel of Tutorial.
    /// </value>
    public string TutorialCenterTitle { get; }

    /// <value>
    ///     Property <c>TutorialCenterText</c> represents
    ///     the text of the Center Panel of Tutorial.
    /// </value>
    public string TutorialCenterText { get; }

    /// <value>
    ///     Property <c>EndWinPanelTitle</c> represents
    ///     the title of the end win Panel of Tutorial.
    /// </value>
    public string EndWinPanelTitle { get; }

    /// <value>
    ///     Property <c>EndWinPanelText</c> represents
    ///     the title of the end loses Panel of Tutorial.
    /// </value>
    public string EndWinPanelText { get; }

    /// <value>
    ///     Property <c>EndLosePanelTitle</c> represents
    ///     the text of the end win Panel of Tutorial.
    /// </value>
    public string EndLosePanelTitle { get; }

    /// <value>
    ///     Property <c>EndLosePanelText</c> represents
    ///     the text of the end loses Panel of Tutorial.
    /// </value>
    public string EndLosePanelText { get; }
}