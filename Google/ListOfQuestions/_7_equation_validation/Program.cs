using System;
using System.Collections.Generic;

/*  Validate if the equation is syntactically correct.

Valid operators: +, -, a-z, (, )
Test cases:
Valid - a + x = b + (c + a)
Invalid - a + x = (ending with =; doesn't have RHS)
Invalid - a + -x = a + b (- in -x is a unary operator)

*/

class Program
{
  public static bool HasValidChars(string str)
  {
    List<char> symbols = new List<char>() { '(', ')', '-', '+', '*', '/' };

    foreach (char ch in str)
    {
      if (!(char.IsDigit(ch) || symbols.Contains(ch) || char.IsLetter(ch)))
      {
        return false;
      }
    }
    return true;
  }

  public static bool HasValidBrackets(string str)
  {
    Stack<char> brackets = new Stack<char>();

    foreach (char ch in str)
    {
      if (ch == '(') brackets.Push(ch);
      if (ch == ')')
      {
        if (brackets.Count < 1) return false;
        else brackets.Pop();
      }
    }
    return brackets.Count == 0;
  }

  public static bool NiceOperations(string str)
  {
    List<char> symbols = new List<char>() { '-', '+', '*', '/' };
    for (int i = 0; i < str.Length; i++)
    {
      char ch = str[i];
      if (symbols.Contains(ch))
      {
        char before = i > 0 ? str[i - 1] : '('; // Если это первый символ, считаем, что перед ним скобка
        char after = i < str.Length - 1 ? str[i + 1] : '.'; // Если это последний символ, считаем ошибкой

        try
        {
          before = str[i - 1];
          after = str[i + 1];
        }
        catch
        {
          return false; //out of index
        }
        if ((char.IsDigit(before) || char.IsLetter(before) || before == '(') &&
        (char.IsDigit(after) || char.IsLetter(after)) || after == ')')
        {
          continue;
        }
        else
        {
          return false;
        }
      }
    }
    return true;
  }
  public static bool IsEquationValid(string equation)
  {
    equation = equation.Replace(" ", "");
    string[] leftAndRight = equation.Split('=');
    if (leftAndRight.Length != 2) return false;

    string lhs = leftAndRight[0];
    string rhs = leftAndRight[1];
    if (string.IsNullOrWhiteSpace(lhs) || string.IsNullOrWhiteSpace(rhs))
    {
      return false;
    }

    if (HasValidChars(lhs) == false || HasValidChars(rhs) == false) return false;
    if (HasValidBrackets(lhs) == false || HasValidBrackets(rhs) == false) return false;
    if (NiceOperations(lhs) == false || NiceOperations(rhs) == false) return false;
    return true;

  }
  static void Main(string[] args)
  {
    string str = "(-1 +2)= ";
    bool valid = IsEquationValid(str);
    Console.WriteLine(valid);
  }
}