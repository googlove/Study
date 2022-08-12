using System;

namespace task_7upd
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
        
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размерность массива");
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            Console.WriteLine(" ");
            
            double[,] arr1 = new double[n, m];
            double[,] arr2 = new double[n, m];
            
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
            
            Print(arr1);
            Console.WriteLine(" ");
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

            Console.ReadKey(true);
        }
    }
}