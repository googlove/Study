using System;
namespace Task1
{
    public class Task1
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Input a ");
            var a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input b ");
            var b = Convert.ToInt32(Console.ReadLine());
            var sum = a + b;
            Console.WriteLine("Summ: " + sum);
            var diff = a - b;
            Console.WriteLine("Difference: " + diff);
            var mult = a * b;
            Console.WriteLine("Multiplication: " + mult);
        }
    }
}