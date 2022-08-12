using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
namespace _154
{
    class Task154
    {
        static void Main(string[] args)
        {
            Console.Write("введите координату школы по оси x:");
            string buf1 = Console.ReadLine();
            double a = double.Parse(buf1);
            Console.Write("Введите координату школы по оси y:");
            string buf2 = Console.ReadLine();
            double b = double.Parse(buf2);
 
            uint n = 0;
            string buf;
            buf = Console.ReadLine();
            n = uint.Parse(buf); /*получить беззнаковое целое*/
            
            int[] x = new int[n];
            int[] y = new int[n];
            double dlina = 0;
            double sum = 0;
 
            for (int i = 0; i < n; i++)
 
            {
                Console.Write("Введите координату дома по оси х:");
                buf = Console.ReadLine();
                x[i] = int.Parse(buf);  //значение x
                Console.Write("Введите координату дома по оси y:");
                buf = Console.ReadLine();
                y[i] = int.Parse(buf); //значение y
                dlina = Math.Sqrt((a - x[i]) * (a - x[i]) + (b - y[i]) * (b - y[i]));
                Console.WriteLine("Расстояние от школы до дома", dlina);
                Console.WriteLine(+ dlina);
                sum = sum + dlina;
            }
 
 
            Console.WriteLine("Усреднённое арифмитическое расстояние от дома до школы", sum / n);
            Console.WriteLine( + sum / n);
        }
    }
}