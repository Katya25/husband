using System;
using System.Collections.Generic;

class Order 
{
    public string name { get; private set; }
    public double price { get; private set; }

    public Order(string name, double price) 
    {
        this.name = name;
        this.price = price;
    }
}
class Program
{
    static void Main()
    {
        List<Order> orders = new List<Order>();
        orders.Add(new Order("Order1", 100.50));
        orders.Add(new Order("Order2", 250.00));
        orders.Add(new Order("Order3", 75.30));

        Console.WriteLine("Total value of orders: " + CalculateTotal(orders));

        var highValueOrders = GetOrdersAboveThreshold(orders, 100);
        Console.WriteLine("Orders above threshold:");
        foreach (var order in highValueOrders)
        {
            Console.WriteLine(order.name);
        }
    }

    static List<Order> GetOrdersAboveThreshold(double threshold)
    {
        //return orders.Where(order => order.Price > threshold).ToList(); //LINQ
        
        List<Order> ordersList = new List<Order>();
        foreach (var order in orders)
        {
            if (order.price > threshold)
            {
                ordersList.Add(order);
            }
        }
        return ordersList;
    }

   static double CalculateTotal(List<Order> orders)
    {
        if (orders == null || orders.Count == 0)
        {
            Console.WriteLine("Order list is empty.");
            return 0;
        }

        double total = 0;
        foreach (var order in orders)
        {
            total += order.price;
        }
        return total;
    }
}