using System;
using System.Runtime.InteropServices;

class Program
{
    public static int Tribonacci(int n) {
        if(n <= 1) return n;
        if(n == 2) return 1;

        int a = 0; int b = 1; int c = 1;

        for(int i = 3; i <= n; i++)
        {
            int tempC = c;

            c = a + b + c;
            a = b;
            b = tempC;
        }
        return c;
    }

    public static int WateringPlants(int[] plants, int capacity) {
        int steps = 1;
        int index = 0;
        int water = capacity;
        while(index < plants.Length)
        {
            if(water >= plants[index])
            {
                water = water - plants[index];
                plants[index] = 0;
                index++;
            }
            else
            {
                water = capacity;
                steps = steps + (index+1) * 2;
            }
        }
        return steps;
    }

        //int[] tops = { 2, 1, 2, 4, 2, 2 };
        //int[] bott = { 5, 2, 6, 2, 3, 2 };
    public static int MinDominoRotations(int[] tops, int[] bottoms) {
        if(tops.Length != bottoms.Length) return -1;
        int len = tops.Length;

        int minRot = int.MaxValue;

        int t = tops[0];
        int b = bottoms[0];

        int tCountTop = 0;
        int tCountBot = 0;
        int bCountBot = 0;
        int bCountTop = 0;

        bool isT = true;
        bool isB = true;

        for(int i = 0; i < len; i++)
        {
            if(isT && (tops[i] == t || bottoms[i] == t))
            {
                if(tops[i] == t) tCountTop++;
                if(bottoms[i] == t) tCountBot++;
            }
            else isT = false;
            if(isB && (tops[i] == b || bottoms[i] == b))
            {
                if(tops[i] == b) bCountTop++;
                if(bottoms[i] == b) bCountBot++;
            }
            else isB = false;
        }

        if(isT && (tCountTop + tCountBot == len))
        {
            minRot = Math.Min(minRot, Math.Min(tCountTop, tCountBot));
        }
        if(isB && (bCountTop + bCountBot == len))
        {
            minRot = Math.Min(minRot, Math.Min(bCountTop, bCountBot));
        }

        return minRot;

    }

    //746. Min Cost Climbing Stairs
    public static int MinCostClimbingStairs(int[] cost) {
        int len = cost.Length;
        int[] minToTheTop = new int[len];
        minToTheTop[len - 1] = cost[len-1];
        minToTheTop[len - 2] = cost[len-2];
        //{1, 100, 1, 1, 1, 100, 1, 1, 100, 1}
        //{_, ___, _, _, _, ___, _, _, 100, 1}
        for(int i = len-3; i >= 0; i--)
        {
            minToTheTop[i] = cost[i] + Math.Min(minToTheTop[i+1], minToTheTop[i+2]);
        }
        return Math.Min(minToTheTop[0], minToTheTop[1]);
    }

    static void Main()
    {
        int[] tops = { 2, 1, 2, 4, 2, 2 };
        int[] bottoms = { 5, 2, 6, 2, 3, 2 };
        int _123 = MinDominoRotations(tops, bottoms);


        int[] plants = {7,7,7,7,7,7,7};
        System.Console.WriteLine(WateringPlants(plants, 8));

        Console.WriteLine(Tribonacci(4));



        int n = 4;
        bool Alice = true;
        while(n != 1)
        {
            if(n % 2 == 0) // if even
            {
                n /= 2;
                Alice = !Alice;
            }
            else
            {
                n--;
                Alice = !Alice;
            }
        }
        System.Console.WriteLine(!Alice);

        int[] cost = {1,100,1,1,1,100,1,1,100,1};
        int res = MinCostClimbingStairs(cost);
        System.Console.WriteLine();





        /*
        string str = "abdjdhu diejdoejd djoejdo 1269830238";
        Dictionary<char, int> dict = new Dictionary<char, int>();        

        int maxCount = 0;
        char maxChar = ' ';

        foreach(char ch in str)
        {
            if(dict.ContainsKey(ch))
            {
                dict[ch]++;
                if(dict[ch] > maxCount)
                {
                    maxCount = dict[ch];
                    maxChar = ch;
                }
            }
            else{
                dict.Add(ch, 1);
            }
        }

        foreach(KeyValuePair<char, int> pair in dict)
        {
            System.Console.WriteLine(pair.Key + ", " + pair.Value);
        }
        System.Console.WriteLine();
        System.Console.WriteLine("MaxCount = " + maxCount);
        System.Console.WriteLine("MaxChar = " + maxChar);
        System.Console.WriteLine();

        Dictionary<string, int> name_n_age = new Dictionary<string, int>();
        name_n_age.Add("Vovochka lubimii", 18);
        name_n_age.Add("Katenka", 19);

        string name = "Fedor";
        if(name_n_age.ContainsKey(name))
        {
            System.Console.WriteLine("Vovochka's vozrast = " + name_n_age[name]);
        }
        else{
            System.Console.WriteLine("no " + name);
        }
        */
    }
}