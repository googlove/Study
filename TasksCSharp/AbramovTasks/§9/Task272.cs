using System;
using System.Linq;

namespace T272
{
     class Task272
    {
        public static void Main(string[] args)
        {
                // ИНИЦИАЛИЗАЦИЯ И ВЫВОД
                int size = 50;
                Random random = new Random();
                int[] a = new int[size];
                for (int i = 0; i < size; i++)
                {
                    a[i] = random.Next(0, 1950); // Настроить разброс самому
                    Console.Write(a[i] + " ");
                }
                Console.WriteLine();
                double avg = a.Average();
                Console.WriteLine("Среднее " + avg.ToString());
                Console.WriteLine("Отклонения от среднего");
                foreach (var item in a.Select(e => Math.Abs(e - avg)))
                {
                    Console.Write(item + " ");
                }
                Console.ReadKey();
            }
        }
    }