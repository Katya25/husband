/*
Input :
2 3 4
List of all operators including "(" and ")".
Target = 20

Output = ( 2 + 3 ) * 4
Return list of all such expressions which evaluate to target.

I prososed to do it via Backtracking but he said try if you can do it via trees.
Finally, wrote code using backtracking but it wasn't completely done.

Let me know your solution using trees/backtracking.
*/
using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;

using System;
using System.Collections.Generic;

class Program
{
  public static List<string> GenerateExpressions(int[] nums, int target)
  {
    List<string> result = new List<string>();
    Backtrack(nums, target, 0, nums.Length - 1, result);
    return result;
  }

  // Backtracking метод с учетом скобок
  private static void Backtrack(
      int[] nums,
      int target,
      int start,
      int end,
      List<string> result)
  {
    // Базовый случай: если диапазон состоит из одного числа
    if (start == end)
    {
      if (nums[start] == target)
      {
        result.Add(nums[start].ToString());
      }
      return;
    }

    // Пробуем все возможные разбиения диапазона
    for (int i = start; i < end; i++)
    {
      // Получаем левую и правую части
      List<string> leftPart = Evaluate(nums, start, i, target);
      List<string> rightPart = Evaluate(nums, i + 1, end, target);

      // Пробуем все комбинации операций между левой и правой частями
      foreach (var left in leftPart)
      {
        foreach (var right in rightPart)
        {
          foreach (var op in new[] { "+", "-", "*", "/" })
          {
            string expr = "(" + left + op + right + ")";
            if (EvaluateExpression(expr) == target)
            {
              result.Add(expr);
            }
          }
        }
      }
    }
  }

  // Метод для вычисления значений диапазона
  private static List<string> Evaluate(int[] nums, int start, int end, int target)
  {
    List<string> result = new List<string>();
    Backtrack(nums, target, start, end, result);
    return result;
  }

  // Метод для вычисления значения выражения
  private static int EvaluateExpression(string expr)
  {
    try
    {
      DataTable table = new DataTable();
      return Convert.ToInt32(table.Compute(expr, null));
    }
    catch
    {
      return int.MaxValue; // Если выражение невалидное
    }
  }

  static void Main(string[] args)
  {
    int[] nums = { 2, 3, 4 };
    int target = 20;

    List<string> expressions = GenerateExpressions(nums, target);

    Console.WriteLine("Expressions that evaluate to " + target + ":");
    foreach (string expr in expressions)
    {
      Console.WriteLine(expr);
    }
  }
}
