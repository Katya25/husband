using System;
using System.Collections.Generic;

public class Plane
{
  public int x { get; set; }
  public int y { get; set; }
  public int xv { get; set; }
  public int yv { get; set; }

  public Plane(int x, int y, int xv, int yv)
  {
    this.x = x;
    this.y = y;
    this.xv = xv;
    this.yv = yv;
  }
}

public class PlaneCrash
{
  private IList<Plane> planes;
  private const int timeLimit = 300; // 5 minutes in seconds
  private const double epsilon = 0.1; // Small distance to determine collision
  private const int gridSize = 10; // Размер ячейки сетки (можно подбирать в зависимости от задачи)

  // Сетка для хранения объектов
  private Dictionary<(int, int), List<Plane>> grid;

  public PlaneCrash()
  {
    planes = new List<Plane>();
    grid = new Dictionary<(int, int), List<Plane>>();
  }

  public void AddPlane(Plane plane)
  {
    planes.Add(plane);
    // Помещаем объект в сетку
    var gridCell = GetGridCell(plane);
    if (!grid.ContainsKey(gridCell))
    {
      grid[gridCell] = new List<Plane>();
    }
    grid[gridCell].Add(plane);
  }

  public List<Tuple<Plane, Plane>> CalculateCrashes()
  {
    var potentialCrashes = new List<Tuple<Plane, Plane>>();

    foreach (var plane in planes)
    {
      var gridCell = GetGridCell(plane);
      // Проверяем все соседние ячейки
      foreach (var neighborCell in GetNeighborCells(gridCell))
      {
        if (grid.ContainsKey(neighborCell))
        {
          foreach (var neighborPlane in grid[neighborCell])
          {
            // Проверяем столкновение между plane и соседними объектами
            if (CheckCollision(plane, neighborPlane))
            {
              potentialCrashes.Add(new Tuple<Plane, Plane>(plane, neighborPlane));
            }
          }
        }
      }
    }

    return potentialCrashes;
  }

  // Метод для получения ячейки сетки для объекта
  private (int, int) GetGridCell(Plane plane)
  {
    int gridX = plane.x / gridSize;
    int gridY = plane.y / gridSize;
    return (gridX, gridY);
  }

  // Метод для получения соседних ячеек
  private IEnumerable<(int, int)> GetNeighborCells((int, int) cell)
  {
    var neighbors = new List<(int, int)>
        {
            (cell.Item1, cell.Item2), // текущая ячейка
            (cell.Item1 - 1, cell.Item2), // слева
            (cell.Item1 + 1, cell.Item2), // справа
            (cell.Item1, cell.Item2 - 1), // сверху
            (cell.Item1, cell.Item2 + 1), // снизу
            (cell.Item1 - 1, cell.Item2 - 1), // верхний левый угол
            (cell.Item1 + 1, cell.Item2 - 1), // верхний правый угол
            (cell.Item1 - 1, cell.Item2 + 1), // нижний левый угол
            (cell.Item1 + 1, cell.Item2 + 1)  // нижний правый угол
        };

    return neighbors;
  }

  // Метод для проверки столкновения двух объектов
  private bool CheckCollision(Plane plane1, Plane plane2)
  {
    for (int t = 0; t <= timeLimit; t++)
    {
      var x1 = plane1.x + plane1.xv * t;
      var y1 = plane1.y + plane1.yv * t;
      var x2 = plane2.x + plane2.xv * t;
      var y2 = plane2.y + plane2.yv * t;

      var distanceSquared = (x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1);

      if (distanceSquared < epsilon * epsilon)
      {
        return true;
      }
    }

    return false;
  }
}
