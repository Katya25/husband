using System;
using System.Collections.Generic;

class Program
{
  // Функция для проверки наличия общих тегов
  public static bool HasCommonTags(List<string> question, List<string> volunteer)
  {
    foreach (var tag in question)
    {
      if (volunteer.Contains(tag)) return true;
    }
    return false;
  }

  // Функция для попытки назначения вопроса волонтёру
  public static bool TryAssign(int questionId, HashSet<int> visited, Dictionary<int, List<string>> questionTags,
                               Dictionary<int, List<string>> volunteerTags, Dictionary<int, int> assignments)
  {
    foreach (var volunteerId in volunteerTags.Keys)
    {
      if (visited.Contains(volunteerId)) continue; // Если волонтёр уже был рассмотрен, пропускаем
      if (HasCommonTags(questionTags[questionId], volunteerTags[volunteerId])) // Проверка на общие теги
      {
        visited.Add(volunteerId);
        // Если волонтёр ещё не взял вопрос, или он может взять новый
        if (!assignments.ContainsValue(volunteerId) || TryAssign(assignments.FirstOrDefault(x => x.Value == volunteerId).Key, visited, questionTags, volunteerTags, assignments))
        {
          assignments[questionId] = volunteerId;
          return true;
        }
      }
    }
    return false;
  }
  public static void Graph(Dictionary<int, List<string>> questionTags, Dictionary<int, List<string>> volunteerTags)
  {
    var assignments = new Dictionary<int, int>(); // Вопрос -> Волонтёр
    var visited = new HashSet<int>(); // Для отслеживания посещённых волонтёров в DFS

    // Для каждого вопроса пытаемся найти подходящего волонтёра
    foreach (var question in questionTags.Keys)
    {
      visited.Clear();
      TryAssign(question, visited, questionTags, volunteerTags, assignments);
    }

    // Вывод назначений
    foreach (var assignment in assignments)
    {
      Console.WriteLine($"Question {assignment.Key} assigned to Volunteer {assignment.Value}");
    }

  }
  static void Main(string[] args)
  {
    var questionTags = new Dictionary<int, List<string>>()
        {
            { 1, new List<string> { "MAC", "VSCODE" } },
            { 2, new List<string> { "PY", "AI" } },
            { 3, new List<string> { "JAVA", "OS" } },
            { 4, new List<string> { "PY", "NW" } }
        };

    var volunteerTags = new Dictionary<int, List<string>>()
        {
            { 1, new List<string> { "PY", "NW" } },
            { 2, new List<string> { "AI" } },
            { 3, new List<string> { "JAVA", "NW" } },
            { 4, new List<string> { "JAVA", "NW" } }
        };

    Graph(questionTags, volunteerTags);
  }
}