using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

class Deal{
    public string action;
    public int size;
    public int price;
    
    public Deal(string action, int size, int price) {
        this.action = action;
        this.size = size;
        this.price = price;
    }
}

class Company{
    public string name;
    public List<Deal> deals;
    
    public Company(string str){
        string[] strs = str.Split();
        this.name = strs[0];
        this.deals = new List<Deal>();
        
        addDeals(strs.Skip(1).ToArray());
    }
    
    private void addDeals(string[] dealsArr) {
        for (int i = 0; i < dealsArr.Length - 2; i+=3) {
            string action = dealsArr[i];
            int size = Convert.ToInt32(dealsArr[i+1]);
            int price = Convert.ToInt32(dealsArr[i+2]);
            Deal deal = new Deal(action, size, price);
            this.deals.Add(deal);
        }
    }
}

class Program
{
    public static (int profit, int longExposure, int shortExposure) Trade(List<string> records)
    {
        int profit = 0;
        int longExposure = 0;
        int shortExposure = 0;

        List<Deal> sellOrders = new List<Deal>();
        List<Deal> buyOrders = new List<Deal>();

        List<Deal> deals = new List<Deal>();
        foreach (string line in records) {
            Company comp = new Company(line);
            string name = comp.name;
            List<Deal> dealsComp = comp.deals;
            foreach (Deal deal in dealsComp) {
                deals.Add(deal);
            }
        }

        
        foreach (Deal deal in deals) {
            if (deal.action == "BUY" || deal.action == "BID") {
                profit += tryToBuy(sellOrders, deal);
                if (deal.size > 0) {
                    buyOrders.Add(deal); 
                }
            } else if (deal.action == "SELL" || deal.action == "OFFER") {
                profit += tryToSell(buyOrders, deal);
                if (deal.size > 0) {
                    sellOrders.Add(deal);
                }
            } 
        }
        
        
        longExposure = CalculateLongExposure(buyOrders);
        shortExposure = CalculateShortExposure(sellOrders);
        // profit, long exposure, short exposure
        return (profit, longExposure, shortExposure);
    }
   public static int tryToBuy(List<Deal> sellOrders, Deal buyDeal) {
    int profit = 0;
    sellOrders.Sort((deal1, deal2) => deal1.price.CompareTo(deal2.price));

    for (int i = 0; i < sellOrders.Count && buyDeal.size > 0; ) {
        Deal sellDeal = sellOrders[i];
        
        // Проверяем, если цена покупки больше или равна цене продажи
        if (buyDeal.price >= sellDeal.price) {
            int size = Math.Min(buyDeal.size, sellDeal.size);
            profit += (buyDeal.price - sellDeal.price) * size; // Прибавляем прибыль, если сделка успешна
            if (sellDeal.action == "SELL" && buyDeal.action == "BUY") {
                profit -= (buyDeal.price - sellDeal.price) * size;
            }

            // Уменьшаем размер ордеров
            buyDeal.size -= size;
            sellDeal.size -= size;

            // Удаляем проданные ордера, если их размер стал равным нулю
            if (sellDeal.size == 0) {
                sellOrders.RemoveAt(i);
            } else {
                i++;
            }
        } else {
            break; // Завершаем цикл, если больше нет подходящих предложений
        }
    }

    return profit;
}

    public static int tryToSell(List<Deal> buyOrders, Deal sellDeal) {
        int profit = 0;
        buyOrders.Sort((deal1, deal2) => deal2.price.CompareTo(deal1.price));
    
        for (int i = 0; i < buyOrders.Count && sellDeal.size > 0; ) {
            Deal buyDeal = buyOrders[i];
            
            // Проверяем, если цена продажи меньше или равна цене покупки
            if (sellDeal.price <= buyDeal.price) {

                int tradeSize = Math.Min(sellDeal.size, buyDeal.size);
                profit += (buyDeal.price - sellDeal.price) * tradeSize; // Прибавляем прибыль, если сделка успешна
                if (sellDeal.action == "SELL" && buyDeal.action == "BUY") {
                    profit -= (buyDeal.price - sellDeal.price) * tradeSize;
                }
                // Уменьшаем размер ордеров
                sellDeal.size -= tradeSize;
                buyDeal.size -= tradeSize;
    
                // Удаляем купленные ордера, если их размер стал равным нулю
                if (buyDeal.size == 0) {
                    buyOrders.RemoveAt(i);
                } else {
                    i++;
                }
            } else {
                break; // Завершаем цикл, если больше нет подходящих заявок на покупку
            }
        }
    
        return profit;
    }



    public static int CalculateShortExposure(List<Deal> sellOrders) {
        int exposure = 0;
        foreach (Deal deal in sellOrders) {
            if (deal.action == "SELL") {
                exposure += deal.price * deal.size;
            }
        }
        return exposure;
    }
    
    public static int CalculateLongExposure(List<Deal> buyOrders) {
        int exposure = 0;
        foreach (Deal deal in buyOrders) {
            if (deal.action == "BUY") {
                exposure += deal.price * deal.size;
            }
        }
        return exposure;
    }

    static void Main()
    {
        List<string> records = new List<string>
        {
            "MAVEN BID 5 20 OFFER 5 25",
            "MEDPHARMA BID 3 120 OFFER 7 150",
            "NEWFIRM BID 10 140 BID 7 150 OFFER 14 180",
            "TINYCORP BID 25 3 OFFER 25 6",
            "FASTAIR BID 21 65 OFFER 35 85",
            "FLYCARS BID 50 80 OFFER 100 90",
            "BIGBANK BID 200 13 OFFER 100 19",
            "REDCHIP BID 55 25 OFFER 80 30",
            "FASTAIR BUY 50 100",
            "CHEMCO SELL 100 67",
            "MAVEN BUY 5 30",
            "REDCHIP SELL 5 30",
            "NEWFIRM BUY 2 200",
            "MEDPHARMA BUY 2 150",
            "BIGBANK SELL 50 11",
            "FLYCARS BUY 200 100",
            "CHEMCO BID 1000 77 OFFER 500 88"
        };

        (int profit, int longExposure, int shortExposure) = Trade(records);

        Console.WriteLine($"Profit: {profit}");
        Console.WriteLine($"Long Exposure: {longExposure}");
        Console.WriteLine($"Short Exposure: {shortExposure}");
    }
}