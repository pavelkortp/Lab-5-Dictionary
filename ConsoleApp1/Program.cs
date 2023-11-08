using ConsoleApp1;

var resultTable = new GameResultTable();

resultTable.AddGamesFromFile("games.txt");

Console.WriteLine(resultTable.GetResults());

resultTable.SaveResultsToFile("results.txt");