using System;
using System.Collections.Generic;

/*
x(t) = x0 + vx * t
y(t) = y0 + vy * t

Где t — время, а vx, vy, vz — компоненты скорости.

Два объекта столкнутся, если расстояние между их позициями становится меньше заданного epsilon:

sqrt((x1(t) - x2(t))^2 + (y1(t) - y2(t))^2) < epsilon
*/
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
  IList<Plane> planes;
  private const int timeLimit = 300; // 5 minutes in seconds
  private const double epsilon = 0.1; // Small distance to determine collision

  public PlaneCrash()
  {
    planes = new List<Plane>();
  }

  public void AddPlane(Plane plane)
  {
    planes.Add(plane);
  }

  public List<Tuple<Plane, Plane>> CalculateCrashes()
  {
    List<Tuple<Plane, Plane>> potentialCrashes = new List<Tuple<Plane, Plane>>();

    for (int i = 0; i < planes.Count; i++)
    {
      for (int j = i + 1; j < planes.Count; j++)
      {
        Plane plane1 = planes[i];
        Plane plane2 = planes[j];

        // Проверяем возможность столкновения для пары plane1 и plane2
        if (CheckCollision(plane1, plane2))
        {
          potentialCrashes.Add(new Tuple<Plane, Plane>(plane1, plane2));
        }
      }
    }

    return potentialCrashes;
  }

  // Метод для проверки столкновения двух объектов
  private bool CheckCollision(Plane plane1, Plane plane2)
  {
    // Проходим по времени от 0 до timeLimit и проверяем координаты
    for (int t = 0; t <= timeLimit; t++)
    {
      int x1 = plane1.x + plane1.xv * t;
      int y1 = plane1.y + plane1.yv * t;
      int x2 = plane2.x + plane2.xv * t;
      int y2 = plane2.y + plane2.yv * t;

      // Вычисляем квадрат расстояния между самолетами
      double distanceSquared = Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2);

      // Если расстояние меньше epsilon, то это считается столкновением
      if (distanceSquared < epsilon * epsilon)
      {
        return true;
      }
    }

    return false;
  }

}