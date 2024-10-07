using System;

class Program
{
    static void Main()
    {
        int[] arr = new int[10];

        List<int> list = new List<int>();
        Random r = new Random();
        for(int i = 0; i < 10; i++)
        {
            list.Add(r.Next(1, 11));
        }

        PrintList(list);

        //list.Insert(1, 7);
        //PrintList(list);

        list.RemoveAll(IsEven);
        int len = list.Count;
        PrintList(list);

        // 1 7 8 3 7 9 0 7
        int input = 7;
        bool contains = list.Contains(input);
        if(contains)
        {
            System.Console.WriteLine("Index = " + list.IndexOf(input));
        }
        System.Console.WriteLine(contains);

    }

    static bool IsEven(int x)
    {
        return x % 2 == 0;
    }

    static void PrintList(List<int> list)
    {
        for(int i = 0; i < list.Count; i++)
        {
            System.Console.Write(list[i] + " ");
        }
        System.Console.WriteLine();
    }
}