using System;
namespace t70
{
    internal class Task70
    {
        public static void Main(string[] args)
        {
            int m = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            int result1 = (m * 5 + 60 - n) % 60;

            if (n + result1 >= 60)
                result1 = (result1 + 5) % 60;

            int result2 = (m * 5 + 75 - n) % 30;

            if (n + result2 >= 60)
                result2 = (result2 + 5) % 30;

            Console.WriteLine("Совпадут через: " +result1 );
            Console.WriteLine("расположатся перпендикулярно друг к другу: " +result2);
            Console.ReadKey();
        }
    }
}