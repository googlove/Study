using System;

namespace task60g
{
    class Task60G
    {
        static double GetDouble()
        {
           
            double a=0;
            bool protect = true;

            do
            {
                try
                {
                    a = Convert.ToDouble(Console.ReadLine());
                    protect = true;
                }
                catch
                {
                    protect = false;
                    Console.WriteLine("Неверный ввод координат!");
                }

            } while (!protect);
            
            return a;
        }

        static void Main(string[] args)
        {
           
            double u = 0;
            Console.WriteLine("Задание №3");
            Console.WriteLine("Необходимо узнать, попадает ли точка в заданную область, вычислить значение u");
            Console.WriteLine("Введите координаты точки:");
            double x = GetDouble();
            double y = GetDouble();
            double oblast = Math.Pow(x, 2) + Math.Pow(y, 2);
            bool popal = false;
            if ((x <= 0)&&(y>=0))
            {
                if (oblast <= 1)
                {
                    popal = true;
                }
                
            }
            else if ((x >= 0) && (y >= 0))
            {
                if ((oblast <= 1)&& (oblast >= 0.09))
                {
                    popal = true;
                }
            }

            if (popal)
            {
                
                u = Math.Pow(x, 2) - 1;
                Console.WriteLine("Точка ({0},{1}", x, y + ") попала, u= " + u);
            }
            else
            {
                u = Math.Sqrt(Math.Abs(x - 1));
                Console.WriteLine("Точка ({0},{1}",x,y+") НЕ попала, u= " + u);
            }
            Console.WriteLine("Для завершения программы нажмите любую клавишу...");
            Console.ReadKey();
            
        }
    }
}