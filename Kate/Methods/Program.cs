using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        /*
        int a = 57;
        int b = -14;
        int sum = Sum(a, b);
        Console.WriteLine(sum);
        
        string name = "Vovochka";
        SayHello(name);

        string malenkaya = "malenkaya";
        string malchik = "Kotik";
        bool otvlekliRoditeli = false;
        string kakPodrochil = Drochka(malenkaya, malchik, otvlekliRoditeli);
        System.Console.WriteLine("Result drochki: " + kakPodrochil);
        
        int a = 57;
        int b = -14;
        int sum = Sum(a, b);
        Console.WriteLine(sum);

        double c = 8.8;
        double d = 9.1;
        double sum2 = Sum(c, d);
        System.Console.WriteLine(sum2);
 
        
        string name2 = Console.ReadLine();
        LubluJeny(name2);
        */
        double p = 0;
        double d = 0;
        Console.Write("Цена: ");
        try{
            p = Convert.ToInt32(Console.ReadLine());
        }
        catch{
            Console.WriteLine("autism");
        }
        Console.Write("Скидка: ");
        try{
            d = Convert.ToInt32(Console.ReadLine());
        }
        catch{
            Console.WriteLine("autism");
        }
        double f = Topp(p, d);
        Console.WriteLine("Оплата: " + f);
    }
    
    static double Topp(double a, double b)
    {
        double f = a - ((b * 0.01) * a);
        return f;
    }

//я люблю свою жену!!!! - метод
    static void LubluJeny(string name)
    {
        if(name == "Jena")
        {
            System.Console.WriteLine(name + " samaya krasivaya rijaya pisechka");
        }
        else if(name == "muj")
        {
            System.Console.WriteLine(name + " samiy krasivii s bolshim chlenom");  
        }
        else{
            System.Console.WriteLine("idite nahui");
        }
    }
    static string Drochka(string naKogo, string kto, bool otvlekli)
    {
        System.Console.WriteLine(kto + " activno drochit na " + naKogo);
        if(!otvlekli)
        {
            return "malenkiy nakonchal :3";
        }
        else{
            return "Ne nakonchal(((";
        }  
    }

    static int Sum(int a, int b)
    {
        int sum = a + b;
        return sum;
    }

    static double Sum(double a, double b)
    {
        double sum = a + b;
        return sum;
    }

    static void SayHello(string name)
    {
        System.Console.WriteLine("Hello, " + name + "!");
    }
        
}
