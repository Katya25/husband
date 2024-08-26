using System;
using System.ComponentModel.DataAnnotations.Schema;

class Program
{
    static void Main()
    {
        /*
        //while   do...while   for    foreach
        int i = 0;
        while(i < 7)
        {
            Console.Write(i + " ");
            i++;
        }
        Console.WriteLine();

        int i2 = 0;
        do{
            Console.Write(i2 + " ");
            i2++;
        } while(i2 < 7);
        Console.WriteLine();
        */

        /*
        int n = 10;   // 1 * 2 * 3 * 4 * 5... * 10
        int cur = 1;
        int res = 1;
        do{
            res = res * cur;
            cur++;
            System.Console.Write(res + " ");
        }while(cur <= n);
        System.Console.WriteLine();
        */

        /*
        for(int i = 100; i >= 0; i-=5)
        {
            System.Console.Write(i + " ");
        }
        System.Console.WriteLine();
        */

        /*
        int[] nums = new int[] {1, 2, 3, 4, 5};   // { [1] [2] [3] [4] [5] }
        foreach(int n in nums)
        {
            System.Console.WriteLine(n * n);
        }

        string name = "Vova";
        foreach(char ch in name)
        {
            System.Console.WriteLine(ch);
        }

        System.Console.WriteLine("////////");
        for(int i = 0; i < nums.Length; i++)
        {
            int n = nums[i];
            System.Console.WriteLine(n * n);
        }
        */

        /*
        for(int i = 1; i <= 3; i++)
        {
            for(int j = 1; j <= 3; j++)
            {
                System.Console.Write(i * j + "\t");
            }
            System.Console.WriteLine();
        }
        */

        /*
        1. Определить, является ли число а делителем числа b
        2. Создать программу, которая выводит на экран простые числа в диапазоне от 2 до 1000. - тяжело
        3. Дано целое число N (> 0). Используя операции деления нацело и взятия остатка от деления, 
        найти количество и сумму его цифр.
        4. Найти сумму целых положительных чисел из промежутка от a до b, кратных четырем.
        5. Дано вещественное число — цена 1 кг конфет. Вывести стоимость 1.2, 1.4, …, 2 кг конфет
        6. Даны целые положительные числа A и B (A < B). Вывести все целые числа от A до B включительно; 
        при этом каждое число должно выводиться столько раз, каково его значение (например, число 3 
        выводится 3 раза).
        */

        //найти есть ли какая-то цифра в введенном пользователем числе
        System.Console.Write("Введите число: ");
        int num = int.Parse(Console.ReadLine());  // -12345
        System.Console.Write("Введите цифру: ");
        int digit = int.Parse(Console.ReadLine());  // 6

        //-468734992  2 true   0   false

        bool isDigitFound = false;

        if(num == 0 && digit == 0) isDigitFound = true;
        else if(num == 0) isDigitFound = false;
        else{
            num = Math.Abs(num);     // 12345   1234   123  12   1    0
            while(num > 0)
            {
                int cur = num % 10;
                if(cur == digit)
                {
                    isDigitFound = true;
                    break;
                }
                num /= 10;
            }
        }

        if(isDigitFound) System.Console.WriteLine("Was found");
        else System.Console.WriteLine("Was not");



        for(int i = 2; i < 10; i++)
        {
            int half = i / 2;
            bool isPrime = true;  //1
            for(int j = 2; j <= half; j++)
            {
                if(i % j == 0)
                {
                    isPrime = false;  //0
                    break;
                } 
            }
            if(isPrime) Console.Write(i + ", ");
        }
        System.Console.WriteLine();


    }
}
