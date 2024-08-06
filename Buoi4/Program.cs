using System;
using System.Collections.Generic;

namespace thuatToanThamLam_vidu1
{
    class Program
    {
        
            static void Main(string[] args)
            {
                List<Item> items = new List<Item>
        {
            new Item { Value = 60, Weight = 10 },
            new Item { Value = 100, Weight = 20 },
            new Item { Value = 120, Weight = 30 }
        };

                int capacity = 50;

                double maxValue = GreedyKnapsack(capacity, items);
                Console.WriteLine("Maximum value in Knapsack = " + maxValue);

            }
            public class Item
            {
                public int Value { get; set; }
                public int Weight { get; set; }
                public double Ratio { get { return (double)Value / Weight; } }
            }
            public static double GreedyKnapsack(int capacity, List<Item> items)
            {
                // Sắp xếp lại các mục giảm dần
                items.Sort((x, y) => y.Ratio.CompareTo(x.Ratio));
                // Khởi tạo lưu trữ tổng giá trị và biến currentWeight để theo dõi tổng trọng lượng 
                double totalValue = 0;
                int currentWeight = 0;
            // Duyệt các mục trong List

                foreach (var item in items)
                {
                //Nếu trọng lượng hiện tại cộng với trọng lượng của mục hiện tại không vượt quá dung lượng tối đa,
                //thì thêm mục này vào ba lô và cập nhật currentWeight và totalValue.
                if (currentWeight + item.Weight <= capacity)
                    {
                        currentWeight += item.Weight;
                        totalValue += item.Value;
                    }
                //Nếu không, tính toán phần trọng lượng còn lại trong ba lô và thêm tương ứng giá trị vào totalValue, sau đó dừng vòng lặp.
                else
                {
                        int remainingWeight = capacity - currentWeight;
                        totalValue += item.Value * ((double)remainingWeight / item.Weight);
                        break;
                    }
                }

                return totalValue;
            }



        }
    }

