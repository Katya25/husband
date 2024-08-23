using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
class Program
{
    static void Main()
    {
        /*
        #region Task 1
        //Вывести на экран число π разными способами.
        System.Console.WriteLine(Math.PI);
        System.Console.WriteLine(Math.Round(Math.PI, 2));
        System.Console.WriteLine(Math.Ceiling(Math.PI));
        #endregion

        #region Task 2
        //Написать программу для отображения Ваших данных – ФИО, сколько лет и т.д. 
        Console.Write("Age: ");
        int age = Convert.ToInt32(Console.ReadLine());
        string name = "name";
        Console.WriteLine("Age = " + age + " name = " + name);
        Console.WriteLine("Age = {0}, name = {1}", age, name);
        Console.WriteLine($"Age = {age}, name = {name}");
        #endregion

        #region Task 3
        //Класс System.Environment. Написать программу для вывода на консоль сведений о компьютере.
        Console.WriteLine(Environment.MachineName);
        Console.WriteLine(Environment.UserName);
        System.Console.WriteLine(Environment.CurrentDirectory);
        #endregion

        #region Task 4
        //Как поменять местами значения двух переменных? Можно ли это сделать без ещё одной временной переменной. Стоит ли так делать?
        int a = 5;
        int b = 10;
        int c = a;
        a = b;
        b = c;
        #endregion

        #region Task 5
        //Дано расстояние в сантиметрах. Найти число полных метров в нем.
        int cm = 1388;
        int m = cm / 100;
        Console.WriteLine(m);
        #endregion

        #region Task 6
        //С некоторого момента прошло 234 дня. Сколько полных недель прошло за этот период?
        int a2 = 234;
        int b2 = a2 / 7;
        #endregion
        
        #region Task 7
        //Дан прямоугольник с размерами 543 x 130 мм. Сколько квадратов со 
        //стороной 130 мм можно отрезать от него?
        int _543 = 543;
        int count = _543 / 130;
        #endregion

        #region Task 10
        //Дано трехзначное число. Найти число, полученное при прочтении его цифр справа налево.
        // и прибавить к нему 5
        int chislo = 567;
        int _1 = chislo % 10;
        int _2 = (chislo / 10) % 10;
        int _3 = chislo / 100;
        int res = _1 * 100 + _2 * 10 + _3;
        string resStr = _1.ToString() + _2.ToString() + _3.ToString(); // "18"
        int re2 = Convert.ToInt32(resStr);
        System.Console.WriteLine("int = " + res);
        System.Console.WriteLine("str = " + resStr);
        #endregion
        */

        #region var
        var i = 10;     //int
        var d = 4.67;   //double
        var s = "sex";  //string
        #endregion

        #region methods
        int count = 0;
        while(count < 3)
        {
            Write("a = ");
            int a22 = Convert.ToInt32(Console.ReadLine());
            Write("b = ");
            int b22 = Convert.ToInt32(Console.ReadLine());
            int sum = Sum(a22, b22);
            System.Console.WriteLine("sum = " + sum);
            count++;
        }
        #endregion
    }
    public static int Sum(int a, int b)
    {
        int sum = a + b;
        return sum;
    }

    public static void Write(string str)
    {
        System.Console.Write(str);
    }
}