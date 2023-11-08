using ConsoleApp1;

var resultTable = new GameResultTable();

//Files must be placed at bin/Debug/net7.0/

resultTable.AddGamesFromFile("games.txt");

Console.WriteLine(resultTable.GetResults());

resultTable.SaveResultsToFile("results.txt");