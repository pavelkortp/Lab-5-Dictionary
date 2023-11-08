using System.Text;

namespace ConsoleApp1;
/// <summary>
/// Table with results of games.
/// </summary>
public class GameResultTable : ILab8DictionaryPart
{
    /// <summary>
    /// How many points adds to team score if it win.
    /// </summary>
    private const int WinsPoints = 3;
    
    public Dictionary<string, TeamResult> Stats { get; }

    public GameResultTable()
    {
        Stats = new Dictionary<string, TeamResult>();
    }


    public void AddGame(string firstTeamName, int firstTeamGoals, string secondTeamName, int secondTeamGoals)
    {
        Stats.TryAdd(firstTeamName, new TeamResult());
        Stats.TryAdd(secondTeamName, new TeamResult());

        Stats[firstTeamName].GamesCount++;
        Stats[secondTeamName].GamesCount++;

        if (firstTeamGoals > secondTeamGoals)
        {
            Stats[firstTeamName].Wins++;
            Stats[secondTeamName].Loses++;
            Stats[firstTeamName].SumOfPoints += WinsPoints;
        }
        else if (firstTeamGoals < secondTeamGoals)
        {
            Stats[secondTeamName].Wins++;
            Stats[firstTeamName].Loses++;
            Stats[secondTeamName].SumOfPoints += WinsPoints;
        }
        else
        {
            Stats[firstTeamName].Draws++;
            Stats[secondTeamName].Draws++;
            Stats[firstTeamName].SumOfPoints++;
            Stats[secondTeamName].SumOfPoints++;
        }
    }

    /// <summary>
    ///  Read the file and adds games to the Stats.
    /// </summary>
    /// <param name="path">path to file</param>
    /// <exception cref="Exception">If file not exist in current path</exception>
    public void AddGamesFromFile(string path)
    {
        if (!File.Exists(path))
        {
            throw new Exception("File not exist");
        }

        string[] lines = File.ReadAllLines(path);

        foreach (string line in lines)
        {
            string[] parts = line.Split(';');
            ValidateDataFromFile(parts);

            string firstTeamName = parts[0];
            int firstTeamGoals = int.Parse(parts[1]);
            string secondTeamName = parts[2];
            int secondTeamGoals = int.Parse(parts[3]);

            AddGame(firstTeamName, firstTeamGoals, secondTeamName, secondTeamGoals);
        }
    }

    /// <summary>
    /// Writes Stats to file.
    /// </summary>
    /// <param name="path">path to file</param>
    public void SaveResultsToFile(string path)
    {
        StreamWriter writer = new StreamWriter(path);
        writer.Write(GetResults());
        writer.Close();
    }

    /// <summary>
    /// Returns string version of resultTable.
    /// </summary>
    /// <returns></returns>
    public string GetResults()
    {
        StringBuilder s = new StringBuilder("");
        foreach (var team in Stats.OrderBy(x => x.Key))
        {
            s.Append($"{team.Key} " +
                     $"{team.Value.GamesCount} " +
                     $"{team.Value.Wins} " +
                     $"{team.Value.Draws} " +
                     $"{team.Value.Loses} " +
                     $"{team.Value.SumOfPoints}" + '\n');
        }

        return s.ToString();
    }

    /// <summary>
    /// Validates game entry.
    /// </summary>
    /// <param name="parsedLine">Array with data about game.</param>
    /// <exception cref="Exception">If data are incorrect.</exception>
    private void ValidateDataFromFile(string[] parsedLine)
    {
        if (parsedLine.Length != 4) throw new Exception("Incorrect data input");

        if (parsedLine[0].Length == 0) throw new Exception("Incorrect firstTeamName");
        if (parsedLine[1].Length == 0) throw new Exception("Incorrect firstTeamGoals");
        if (parsedLine[2].Length == 0) throw new Exception("Incorrect secondTeamName");
        if (parsedLine[3].Length == 0) throw new Exception("Incorrect secondTeamGoals");

        if (int.Parse(parsedLine[1]) < 0) throw new Exception("firstTeamGoals can't be negative");
        if (int.Parse(parsedLine[3]) < 0) throw new Exception("secondTeamGoals can't be negative");
    }
}