using System;
using System.Collections.Generic;

namespace SortSelect
{ 
    class Program
    {
         static void Print(double[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++, Console.WriteLine())
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(Math.Round(arr[i,j], 2, MidpointRounding.AwayFromZero) + "; ");
                }
            }
        }
        
        static void PrintInt(int[] arr, int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write(arr[i] + "; ");
            }
        }

        public static IList<int> Selection(IList<int> list)
        {
            for (int i = 0; i < list.Count-1; i++)
            {
                int min = i;
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[j] < list[min])
                    {
                        min = j;
                    }
                }
                int dummy = list[i];
                list[i] = list[min];
                list[min] = dummy;
            }

            return list;
        }
        
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размерность массива");
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            Console.WriteLine(" ");
            
            double[,] arr1 = new double[n, m];
            double[,] arr2 = new double[n, m];
            
            int[] sort = new int[n];
            
            double[,] sum = new double[n, m];
            
            Random rand = new Random();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    arr1[i, j] = rand.Next(-2225, 2225) / 100.0;
                    arr2[i, j] = rand.Next(-2225, 2225) / 100.0;
                }
            }

            for (int i = 0; i < n; i++)
            {
                sort[i] = rand.Next(255);
            }
            
            Console.WriteLine("Первый массив");
            Print(arr1);
            Console.WriteLine(" ");
            Console.WriteLine("Второй массив ");
            Print(arr2);
            Console.WriteLine(" ");
            
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    sum[i, j] = arr1[i, j] + arr2[i, j];
                }
            }
            
            Console.WriteLine("Сумма массивов:");
            Print(sum);
            Console.WriteLine(" ");
            
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    sum[i, j] = arr1[i, j] - arr2[i, j];
                }
            }
            
            Console.WriteLine("Разница массивов:");
            Print(sum);
            Console.WriteLine(" ");
            
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    sum[i, j] = arr1[i, j] * arr2[i, j];
                }
            }
            
            Console.WriteLine("Произведение массивов:");
            Print(sum);
            Console.WriteLine(" ");
            
            Console.WriteLine("Массив до сортировки выбором");
            PrintInt(sort, n);
            Console.WriteLine(" ");
            
            Console.WriteLine("Массив после сортировки выбором");
            Selection(sort);
            PrintInt(sort, n);
            Console.WriteLine(" ");
            
            Console.ReadKey(true);
        }
    }
}