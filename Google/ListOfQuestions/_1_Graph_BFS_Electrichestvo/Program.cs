using System;
using System.Collections.Generic;

public class Node
{
  public int i, j, power;

  public Node(int i, int j, int power)
  {
    this.i = i;
    this.j = j;
    this.power = power;
  }
}

class Program
{
  public static void PropagatePower(int[][] grid)
  {
    int rows = grid.Length;
    int cols = grid[0].Length;
    Queue<Node> queue = new Queue<Node>();

    // Добавляем все узлы "Torch" в очередь
    for (int i = 0; i < rows; i++)
    {
      for (int j = 0; j < cols; j++)
      {
        if (grid[i][j] == 16)
        {
          queue.Enqueue(new Node(i, j, 16));
        }
      }
    }

    // BFS для распространения мощности
    while (queue.Count > 0)
    {
      Node current = queue.Dequeue();
      int currentPower = current.power;

      // Если мощность <= 1, дальше не распространяем
      if (currentPower <= 1) continue;

      // Вручную проверяем все 4 направления
      // Вверх
      if (current.i - 1 >= 0)
      {
        if (grid[current.i - 1][current.j] < currentPower - 1)
        {
          grid[current.i - 1][current.j] = currentPower - 1;
          queue.Enqueue(new Node(current.i - 1, current.j, currentPower - 1));
        }
      }
      // Вниз
      if (current.i + 1 < rows)
      {
        if (grid[current.i + 1][current.j] < currentPower - 1)
        {
          grid[current.i + 1][current.j] = currentPower - 1;
          queue.Enqueue(new Node(current.i + 1, current.j, currentPower - 1));
        }
      }
      // Влево
      if (current.j - 1 >= 0)
      {
        if (grid[current.i][current.j - 1] < currentPower - 1)
        {
          grid[current.i][current.j - 1] = currentPower - 1;
          queue.Enqueue(new Node(current.i, current.j - 1, currentPower - 1));
        }
      }
      // Вправо
      if (current.j + 1 < cols)
      {
        if (grid[current.i][current.j + 1] < currentPower - 1)
        {
          grid[current.i][current.j + 1] = currentPower - 1;
          queue.Enqueue(new Node(current.i, current.j + 1, currentPower - 1));
        }
      }
    }
  }

  public static void PrintGrid(int[][] grid)
  {
    foreach (int[] row in grid)
    {
      foreach (int value in row)
      {
        Console.Write(value + "\t");
      }
      Console.WriteLine();
    }
  }

  static void Main(string[] args)
  {
    int[][] grid = {
            new int[] { 16, 0, 16 },
            new int[] { 0, 0, 0 },
            new int[] { 16, 0, 16 }
        };

    Console.WriteLine("Before propagation:");
    PrintGrid(grid);

    PropagatePower(grid);

    Console.WriteLine("\nAfter propagation:");
    PrintGrid(grid);
  }
}
