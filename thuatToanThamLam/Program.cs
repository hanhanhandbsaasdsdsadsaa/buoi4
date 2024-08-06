using System;
using System.Collections.Generic;
using System.Linq;

namespace thuatToanThamLam_vidu2
{
    class Item
    {
        public int Value { get; set; }
        public int Weight { get; set; }
        public double Density => (double)Value / Weight;
    }

    class Program
    {
        static double Knapsack(List<Item> items, int maxWeight, int maxCount)
        {
            items = items.OrderByDescending(x => x.Density).ToList();
            double totalValue = 0;
            int totalWeight = 0;
            int[] counts = new int[items.Count];

            for (int i = 0; i < items.Count; i++)
            {
                if (totalWeight + items[i].Weight <= maxWeight && counts[i] < maxCount)
                {
                    counts[i]++;
                    totalWeight += items[i].Weight;
                    totalValue += items[i].Value;
                }
                else
                {
                    int remainingWeight = maxWeight - totalWeight;
                    totalValue += items[i].Value * ((double)remainingWeight / items[i].Weight);
                    break;
                }
            }

            return totalValue;
        }

        static void Main(string[] args)
        {
            var items = new List<Item>
        {
            new Item { Value = 30, Weight = 15 },
            new Item { Value = 25, Weight = 10 },
            new Item { Value = 2, Weight = 2 },
            new Item { Value = 6, Weight = 4 }
        };

            int maxWeight = 39;
            int maxCount = 2;

            double result = Knapsack(items, maxWeight, maxCount);
            Console.WriteLine("Gia tri toi da: " + result );
        }
    }
}
