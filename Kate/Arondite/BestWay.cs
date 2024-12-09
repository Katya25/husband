using System;
using System.Collections.Generic;
using System.Linq;

public class Road
{
  public string FromCity { get; set; }  // Город-отправитель
  public string ToCity { get; set; }    // Город-назначение
  public int Distance { get; set; }     // Расстояние в километрах
  public int FuelRequired { get; set; } // Требуемое количество топлива (в литрах)
  public double WeatherFactor { get; set; } // Множитель для скорости в зависимости от погоды (например, 0.5 - плохая погода, 1 - хорошая)

  public Road(string fromCity, string toCity, int distance, int fuelRequired, double weatherFactor)
  {
    FromCity = fromCity;
    ToCity = toCity;
    Distance = distance;
    FuelRequired = fuelRequired;
    WeatherFactor = weatherFactor;
  }
}

public class City
{
  public string Name { get; set; } // Название города
  public List<Road> Roads { get; set; } // Дороги, ведущие из города

  public City(string name)
  {
    Name = name;
    Roads = new List<Road>();
  }

  public void AddRoad(Road road)
  {
    Roads.Add(road);
  }
}

public class Map
{
  public Dictionary<string, City> Cities { get; set; } // Словарь городов

  public Map()
  {
    Cities = new Dictionary<string, City>();
  }

  // Метод для добавления города
  public void AddCity(string cityName)
  {
    if (!Cities.ContainsKey(cityName))
    {
      Cities[cityName] = new City(cityName);
    }
  }

  // Метод для добавления дороги
  public void AddRoad(string fromCity, string toCity, int distance, int fuelRequired, double weatherFactor)
  {
    AddCity(fromCity);
    AddCity(toCity);

    Road road = new Road(fromCity, toCity, distance, fuelRequired, weatherFactor);
    Cities[fromCity].AddRoad(road);
    Cities[toCity].AddRoad(new Road(toCity, fromCity, distance, fuelRequired, weatherFactor)); // Обратная дорога
  }

  // Алгоритм Дейкстры для нахождения кратчайшего пути с учётом расстояния, топлива и погодных условий
  public List<string> FindShortestPath(string startCity, string endCity)
  {
    // Словарь для хранения кратчайшего пути и стоимости для каждого города
    Dictionary<string, double> distances = new Dictionary<string, double>();
    Dictionary<string, string> previousCities = new Dictionary<string, string>();
    HashSet<string> visitedCities = new HashSet<string>();
    List<string> unvisitedCities = new List<string>(Cities.Keys);

    // Инициализация расстояний для всех городов
    foreach (var city in Cities.Keys)
    {
      distances[city] = double.MaxValue; // Изначально все города имеют бесконечное расстояние
      previousCities[city] = null; // Неизвестен предыдущий город для всех
    }
    distances[startCity] = 0; // Расстояние до начального города — 0

    while (unvisitedCities.Count > 0)
    {
      // Находим город с минимальным расстоянием
      string currentCity = unvisitedCities.OrderBy(city => distances[city]).First();
      unvisitedCities.Remove(currentCity);
      visitedCities.Add(currentCity);

      // Если мы достигли целевого города, восстанавливаем путь
      if (currentCity == endCity)
      {
        List<string> path = new List<string>();
        while (previousCities[currentCity] != null)
        {
          path.Insert(0, currentCity);
          currentCity = previousCities[currentCity];
        }
        path.Insert(0, startCity);
        return path; // Возвращаем найденный путь
      }

      // Рассчитываем новые расстояния для соседей текущего города
      foreach (var road in Cities[currentCity].Roads)
      {
        if (visitedCities.Contains(road.ToCity)) continue;

        // Расстояние с учётом погодного фактора
        double travelTime = road.Distance / road.WeatherFactor;
        double newDistance = distances[currentCity] + travelTime;

        // Если найден более короткий путь, обновляем информацию
        if (newDistance < distances[road.ToCity])
        {
          distances[road.ToCity] = newDistance;
          previousCities[road.ToCity] = currentCity;
        }
      }
    }

    return null; // Если путь не найден, возвращаем null
  }
}

public class Program
{
  public static void Main()
  {
    // Создание карты
    Map map = new Map();
    map.AddRoad("CityA", "CityB", 100, 10, 1.0); // Расстояние 100 км, топливо 10 литров, погода нормальная
    map.AddRoad("CityB", "CityC", 150, 15, 0.8); // Расстояние 150 км, топливо 15 литров, плохая погода
    map.AddRoad("CityA", "CityD", 50, 5, 1.0);  // Расстояние 50 км, топливо 5 литров, погода нормальная
    map.AddRoad("CityD", "CityC", 200, 20, 0.7); // Расстояние 200 км, топливо 20 литров, плохая погода

    // Находим кратчайший путь
    List<string> shortestPath = map.FindShortestPath("CityA", "CityC");

    // Выводим результат
    if (shortestPath != null)
    {
      Console.WriteLine("Кратчайший путь:");
      foreach (var city in shortestPath)
      {
        Console.Write(city + " ");
      }
    }
    else
    {
      Console.WriteLine("Путь не найден.");
    }
  }
}
