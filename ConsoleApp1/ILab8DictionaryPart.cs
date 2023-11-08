namespace ConsoleApp1;

public interface ILab8DictionaryPart
{
    /// <summary>
    /// Returns dictionary with stats of teams in current moment
    /// </summary>
    public Dictionary<string, TeamResult> Stats { get; }

    /// <summary>
    /// Add to the stats results of game. Method automatically chose the winner and update Stats dictionary.
    /// </summary>
    public void AddGame(string firstTeamName, int firstTeamGoals, string secondTeamName,
        int secondTeamGoals);
}