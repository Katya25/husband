using System;

class Program
{
    static void Main()
    {
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
    }
}