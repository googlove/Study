using System;

namespace t43
{
     class Task43
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("43. Даны три действительные числа. Возвести в квадрат те из них,значения которых неотрицательны.\n");
            double a, b, c;
            Console.WriteLine("Введите a");
            a = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите b");
            b = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите c");
            c = double.Parse(Console.ReadLine());
            if (a >= 0)
            {
                Console.WriteLine("Равно " + a * a);
            }

            if (b >= 0)
            {
                Console.WriteLine("Равно " + b * b);
            }

            if (c >= 0)
            {
                Console.WriteLine("Равно " + c * c);
            }
        }
    }
}