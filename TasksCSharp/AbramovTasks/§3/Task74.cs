using System;

namespace Year
{
    internal class Task74
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.Write(n);

            if (n % 10 > 4 || n % 10 == 0 || n / 10 % 10 == 1)
                Console.WriteLine("лет");
            else if (n % 10 == 1)
                Console.WriteLine("год");
            else
                Console.WriteLine("года");

            Console.ReadKey();
        }
    }
}