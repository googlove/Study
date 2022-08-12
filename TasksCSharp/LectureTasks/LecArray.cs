using  System;
namespace LecArray
{ 
    class Program
  {
     static void Print(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++, Console.WriteLine())
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i,j] + ",");
                }
            }
        }
        
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размерность массива:");
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            
            int[,] arr1 = new int[n, m];

            Console.WriteLine("Введите число:");
            int x = int.Parse(Console.ReadLine());
            
            int[,] sum = new int[n, m];
            
            Random rand = new Random();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    arr1[i, j] = rand.Next(25);
                    
                }
            }
            
            Print(arr1);
            Console.WriteLine(" ");
          
            
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    sum[i, j] = arr1[i, j] + x;
                }
            }
            
            Console.WriteLine("Сумма массива и числа:");
            Print(sum);
            Console.WriteLine(" ");
            
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    sum[i, j] = arr1[i, j] - x;
                }
            }
            
            Console.WriteLine("Разница массива и числа:");
            Print(sum);
            Console.WriteLine(" ");
            
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    sum[i, j] = arr1[i, j] * x;
                }
            }
            
            Console.WriteLine("Произведение массива и числа:");
            Print(sum);
            Console.WriteLine(" ");

            Console.ReadKey(true);
        }
    }
}