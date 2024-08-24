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

        for(int i = 1; i <= 3; i++)
        {
            for(int j = 1; j <= 3; j++)
            {
                System.Console.Write(i * j + "\t");
            }
            System.Console.WriteLine();
        }

    }
}
