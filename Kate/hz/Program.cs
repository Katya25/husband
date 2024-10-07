using System;

class Program
{
    static void Main()
    {
        /*string name = Console.ReadLine();
        Console.WriteLine("Hello, " + name);
        int age = Convert.ToInt32(Console.ReadLine());
        System.Console.WriteLine("You are " +  age); */

        for(int i = 1; i <= 10; i++)
        {
            System.Console.Write(i + " ");
        }
        System.Console.WriteLine();

        int j2 = 1;
        while(j2 <= 10)
        {
            System.Console.Write(j2 + " ");
            j2++;
        }
        System.Console.WriteLine();

        int i2 = 1;
        do{
            System.Console.Write(i2 + "\t");
            i2++;
        } while(i2 <= 10);
        System.Console.WriteLine("\n");

        string str = "I love you";
        foreach(char ch in str)
        {
            System.Console.Write(ch + " ");
        }
        System.Console.WriteLine("\n");
        
        for(int i = 1; i <= 10; i++)
        {
            for(int j = 1; j <= 10; j++)
            {
                System.Console.Write(i * j + "\t");
            }
            System.Console.WriteLine();
        }
        System.Console.WriteLine("\n\n");

        for(int i = 10; i >= 1; i--)
        {
            for(int j = 10; j >= 1; j--)
            {
                System.Console.Write(i * j + "\t");
            }
            System.Console.WriteLine();
        }
        System.Console.WriteLine("\n\n\n");

        int[] arr = new int[10];

        int input = 9;

        Random random = new Random();
        for(int i = 0; i < arr.Length; i++)
        {
            arr[i] = random.Next(1, 11);
        }

        PrintArray(arr);

        bool contains = false;

        foreach(int num in arr)
        {
            if(num == input)
            {
                contains = true;
                break;
            }
        }
        System.Console.WriteLine();

        if(contains) 
        {
            System.Console.WriteLine("You won!!!!");
        }
        else{
            System.Console.WriteLine("You are loh");
        }  
    }

    static void PrintArray(int[] arr)
    {
        for(int i = 0; i < arr.Length; i++)
        {
            System.Console.Write(arr[i] + " ");
        }
    }
}