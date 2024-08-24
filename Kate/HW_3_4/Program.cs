using System;

/*1. Напишите программу и три метода в ней, которые переводят гривны в $, €, российские рубли.
2. Написать методы для перевод секунд в дни, часы, минуты.
3. Дана сторона квадрата. Найти его периметр. Метод должен быть универсальным 
(на вход может как целое число, так и вещественное, так и строка)
4. Дан радиус окружности. Найти ее диаметр. Метод должен быть универсальным 
(на вход может как целое число, так и вещественное, так и строка)
*/


/* 1. Дано целое число. Если оно является положительным, то прибавить к нему 1; 
если отрицательным, то вычесть из него 2; если нулевым, то заменить его на 10. Вывести полученное число.​

2. Даны три целых числа. Найти количество положительных чисел в исходном наборе​
678   5   -4   res = 2

3. Даны три целых числа. Найти количество положительных и количество отрицательных чисел в исходном наборе. ​

4. Даны две переменные целого типа: A и B. Если их значения не равны, то присвоить каждой переменной 
сумму этих значений, а если равны, то присвоить переменным нулевые значения. Вывести новые значения 
переменных A и B. ​

5. Напишите программу, проверяющую число на четность.​

6. Единицы длины пронумерованы следующим образом: 1 — дециметр,  2 — километр, 3 — метр, 4 — миллиметр, 
5 — сантиметр. Дан номер единицы длины (целое число в диапазоне 1–5) и длина отрезка в этих единицах 
(вещественное число). Найти длину отрезка в метрах. ​

7. Робот может перемещаться в четырех направлениях («С» — север,  «З» — запад, «Ю» — юг, «В» — восток) 
и принимать три цифровые команды: 0 — продолжать движение, 1 — поворот налево, –1 — поворот направо. 
Дан символ C — исходное направление робота и целое число N — посланная ему команда. Вывести 
направление робота после выполнения полученной команды.​

8. Дано целое число в диапазоне 20–69, определяющее возраст (в годах). Вывести строку-описание указанного 
возраста, обеспечив правильное согласование числа со словом «год», например: 20 — «двадцать лет», 
32 — «тридцать два года», 41 — «сорок один год»
*/
class Program
{
    static void Main()
    {
        /*
        Console.Write("Money: ");
        double money = Convert.ToDouble(Console.ReadLine());
        System.Console.WriteLine("Dollars: " + Dollars(money));

        double us = Money(money, '$');
        System.Console.WriteLine(us);
        double e = Money(money, '€');
        System.Console.WriteLine(e);
        double rus = Money(money, 'r');
        System.Console.WriteLine(rus);

        int a = 10;
        Console.WriteLine(Ass(a));  
        double b = 10.5;
        Console.WriteLine(Ass(b));
        string c = "15";
        Console.WriteLine(Ass(c));
        */
        
        /*
        int a = -100;
        int b = -5;
        int c = -18;
        int res = Ochko(a, b, c);
        System.Console.WriteLine(res);
        */

        int age = 18;
        int _1 = age / 10;
        int _2 = age % 10;
        if(age >= 20 && age <= 69)
        {
            string final = Des(_1) + " " + Chis(_2) + " " + God(_2);
            Console.WriteLine(final);  
        }                                                  

    }

    static string Des(int a)
    {
        switch(a)
        {
            case 2:
            return "dvacat'";
            case 3:
            return "tricat";
            case 4:
            return "sorak";
            case 5:
            return "pisat'";
            case 6:
            return "shisyat";
        }
        return "";
    }
    static string Chis(int a)
    {
        switch(a)
        {
            
            case 1:
            return "odin";
            case 2:
            return "dva'";
            case 3:
            return "tri";
            case 4:
            return "cheturi";
            case 5:
            return "pyat'";
            case 6:
            return "shest";
            case 7:
            return "sem";
            case 8: 
            return "vosem";
            case 9:
            return "devyat";
        }
        return "";
    }
    static string God(int a)
    {
      if(a == 0 | a >= 5)
      {
        return "let";
      }
      else if(a == 1)
      {
        return "god";
      }
      else{
        return "goda";
      }
    }







    static int Ochko(int a, int b, int c)
    {   
        if(a > 0 && b > 0 && c > 0) return 3;
        else if((a > 0 & b > 0 & c <= 0) | (a > 0 & b <= 0 & c > 0) | (a <= 0 & b > 0 & c > 0)) return 2;
        else if(a <= 0 & b <= 0 & c <= 0) return 0;
        else return 1;
    }


    static int Ass(int a)
    {
        return a * 4;
    }        
    static double Ass(double a)
    {
        return a * 4;
    }   
    static double Ass(string a)
    {
        double popa = Convert.ToDouble(a);
        return popa * 4;
    }                                                                                             

    static double Dollars(double a)
    {
        double cur = 0.5; //курс в данную секунду 
        return a * cur;
    } 

    static double Money(double a, char ch)
    {
        double cur = 0;
        double res = 0;
        switch(ch)
        {
            case '$':
                cur = 0.5;
                res = a * cur;
                break;
            case '€':
                cur = 0.4;
                res = a * cur;
                break;
            case 'r':
                cur = 2;
                res = a * cur;
                break;
            default:
                res = a;
                break;
        }

        return res;

    }

}






