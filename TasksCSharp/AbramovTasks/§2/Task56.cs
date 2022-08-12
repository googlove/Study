using System;

namespace t56
{
     class Task56
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Введите сторону кирпича a");
            double a = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите сторону кирпича b");
            double b = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите сторону кирпича c");
            double c = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите размер отверстия x");
            double x = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите размер отверстия y");
            double y = double.Parse(Console.ReadLine());
            if (a > b) (a, b) = (b, a);
            if (a > c) (a, c) = (c, a);
            if (b > c) (b, c) = (c, b);
            if (x > y) (x, y) = (y, x);
            Console.WriteLine(a < x && b < y);
            Console.ReadKey();
        }
    }
}