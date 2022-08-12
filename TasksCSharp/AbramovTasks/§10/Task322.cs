using System;

namespace _322
{
    class Task322
    {
        public static void Main(string[] args)
        {
            int s;
            int max = 0;
            int maxValue = 0;
            for (int i = 1; i < 100; i++)
            {
                s = 0;
                Console.WriteLine("Для числа " + i.ToString() + "делители : ");
                for (int j = 1; j < 100; j++)
                {
                    if (i % j == 0)
                    {
                        s++;
                    }
                }

                Console.WriteLine("сумма делителей = " + s.ToString());
                if (s > max)
                {
                    max = s;
                    maxValue = i;
                }



            }

            Console.WriteLine("макс сумма делителей у числа " + maxValue + ", сумма дел = " + max);
            Console.ReadKey();
        }
    }
}