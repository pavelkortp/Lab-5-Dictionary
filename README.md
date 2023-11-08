Комплект Collection

Завдання 1. Розв’яжіть задачу з використанням колекції
Dictionary<TKey, TValue>.
Заданий перелік з N ігор футбольних команд з результатами матчів у
вигляді масиву рядків. Формат кожного рядка такий:
Назва_1_команди;Голів_1_команди;Назва_2_команди;Голів_2_команди
Розробити програму, яка повертає зведену таблицю результатів усіх матчів,
якщо відомо, що за перемогу команді нараховується 3 очки, за поразку – 0 очок,
за нічию – 1 очко. Таблиця результатів повинна мати такий вигляд:
Назва_Команди: Усього_ігор Перемог Нічиїх Поразок Всього_очків
При створенні програми реалізувати наступний інтерфейс:

interface ILab8DictionaryPart
{
/// <summary>
/// Returns dictionary with stats of teams in current moment
/// </summary>
public Dictionary<string, TeamResult> Stats { get; }
/// <summary>
/// Add to the stats results of game. Method automatically chose the winner and update Stats
dictionary.
/// </summary>
public void AddGame(string firstTeamName, int firstTeamGoals, string secondTeamName, int secondTeamGoals);

}

class TeamResult
{
public int NumberOfGames { get; set; }
public int Wins { get; set; }
public int Loses { get; set; }
public int Draws { get; set; }
public int SumOfPoints { get; set; }
}

Додаткове завдання (2 бали): Організуйте зчитування вхідних даних з
файлу, а також збереження результатів виконання роботи в інший файл у тій
самій директорії.
