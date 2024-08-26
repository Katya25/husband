using System;

class Program
{
    static void Main()
    {
        //                                0      1         2       3         4           5          6
        string[] names = new string[] {"Vova", "Katya", "Fedor", "Sasha", "Natasha", "Veronika", "Nastya"};
        
        names[6] = "Dasha";

        int _i = 20;
        TryToChangeInt(_i);

        System.Console.WriteLine("i =  " + _i);

        int val = 6;
        int[] arr = {7, 6, 5, 3, 2, 6, 8};

        // сколько чисел не равны val - ?
        // вернуть массив в таком же порядке, но удалив все числа == val

        int count = 0;
        for(int i = 0; i < arr.Length; i++)
        {
            if(arr[i] != val)
            {
                count++;
            }
        }
        System.Console.WriteLine("Count = " + count);

        int index = 0;
        int[] arr2 = new int[count];  //{0, 0, 0, 0, 0}
        for(int i = 0; i < arr.Length; i++)
        {
            if(arr[i] != val)
            {
                arr2[index] = arr[i];
                index++;
            }
        }

        System.Console.Write("Array2: ");
        PrintArray(arr2);



        //RandomArray(arr);
        //PrintArray(arr);

        //  1 2 3 4 5      int[] arr = new int[] {1, 2, 3, 4, 5};
        

        SayHelloTo(names);
    }

    public static void TryToChangeInt(int i)   
    {
        i = 10;
    }

    public static void RandomArray(int[] arr)
    {
        Random rand = new Random();
        for(int i = 0; i < arr.Length; i++)
        {
            arr[i] = rand.Next(1, 11);
        }
    }

    public static void PrintArray(int[] arr)
    {
        foreach(int i in arr)
        {
            System.Console.Write(i + " ");
        }
        System.Console.WriteLine();
    }

    public static void SayHelloTo(string[] names)  //первых 5
    {
        System.Console.Write("Hello ");
        for(int i = 0; i < 5; i++)
        {
            System.Console.Write(names[i] + ", ");
        }
        System.Console.WriteLine();
    }
}
