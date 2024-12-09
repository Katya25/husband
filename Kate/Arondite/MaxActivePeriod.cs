using System;
using System.Collections.Generic;

class Program
{
  // Метод для поиска максимального периода активности системы
  public static int FindMaxActivePeriod(List<(int time, string status)> events)
  {
    // Сортируем события по времени
    events.Sort((a, b) => a.time.CompareTo(b.time));

    int maxActivePeriod = 0;
    int? currentActiveStart = null; // Время включения системы

    foreach (var (time, status) in events)
    {
      if (status == "включение")
      {
        // Запоминаем время включения
        currentActiveStart = time;
      }
      else if (status == "выключение" && currentActiveStart.HasValue)
      {
        // Если система была включена, вычисляем продолжительность
        int activePeriod = time - currentActiveStart.Value;
        maxActivePeriod = Math.Max(maxActivePeriod, activePeriod);
        currentActiveStart = null; // Обнуляем, так как система выключена
      }
    }

    return maxActivePeriod;
  }

  // Тестовый пример
  static void Main()
  {
    List<(int time, string status)> events = new List<(int time, string status)>
        {
            (1, "включение"),
            (4, "выключение"),
            (5, "включение"),
            (9, "выключение")
        };

    int result = FindMaxActivePeriod(events);
    Console.WriteLine($"Максимальный период активности системы: {result} единиц времени");
  }
}