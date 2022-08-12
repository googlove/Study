using System;

namespace _185
{

    class Task185
    {
        static void Main(string[] args)
        {
            Console.Write("Введите n: ");
            int n = int.Parse(Console.ReadLine());
            double sum = 0;

            double current;
            for (int i = 0;
                i < n;
                i++)
            {
                Console.Write("Введите A[" + (i + 1) + "]: ");
                current = double.Parse(Console.ReadLine());
                if (current > 0) sum += current;
            }

            Console.WriteLine("Удвоенная сумма положительных чисел: " + (sum * 2));
            Console.ReadKey();
        }
    }
}