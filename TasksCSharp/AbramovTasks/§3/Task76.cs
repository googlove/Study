using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
namespace ConsoleApplication1
{
    class Task76
    {
        static void Main(string[] args)
        {
            
            Point kl = new Point(4, 4);// проверяем типа можно
            Point mn = new Point(1, 7);// (с нуля нумерация как у массивов)
 
            bool yesNo = Math.Abs(mn.x - kl.x) == Math.Abs(mn.y - kl.y);
 
            Console.WriteLine("{0} на {1} = {2}", kl, mn, yesNo);
 
 
            mn = new Point(0, 6); //проверяем типа за 2 хода - должны получить список точек после первого хода, с которых можно достичь цели
 
            yesNo = Math.Abs(mn.x - kl.x) == Math.Abs(mn.y - kl.y);
 
            if (yesNo) Console.WriteLine("{0} на {1} = {2}", kl, mn, yesNo);
            
            else {
 
                Console.WriteLine("{0} на {1} = {2}", kl, mn, yesNo);
 
                List<Point> firstMovePoints = new List<Point>();//добавим точки с который можно скакануть 
 
                int x = kl.x;
                int y = kl.y;
                //вверх вправо
                while (x < 7 && y < 7) { x++; y++; if (Math.Abs(mn.x - x) == Math.Abs(mn.y - y)) firstMovePoints.Add(new Point(x, y));}
                //Console.WriteLine("{0} - {1}", x, y);
                
                x = kl.x;
                y = kl.y;
                //вверх влево
                while (x > 0 && y < 7) { x--; y++; if (Math.Abs(mn.x - x) == Math.Abs(mn.y - y)) firstMovePoints.Add(new Point(x, y)); }
                //Console.WriteLine("{0} - {1}", x, y);
                
                x = kl.x;
                y = kl.y;
                //вниз вправо
                while (x < 7 && y > 0) { x++; y--; if (Math.Abs(mn.x - x) == Math.Abs(mn.y - y)) firstMovePoints.Add(new Point(x, y)); }
               // Console.WriteLine("{0} - {1}", x, y);
 
                x = kl.x;
                y = kl.y;
                //вниз влево
                while (x > 0 && y > 0) { x--; y--; if (Math.Abs(mn.x - x) == Math.Abs(mn.y - y)) firstMovePoints.Add(new Point(x, y)); }
               // Console.WriteLine("{0} - {1}", x, y);
 
 
                Console.WriteLine("Точки для первого хода: {0}", string.Join(" ", firstMovePoints));
 
            }
            
           
            Console.ReadKey();
        } 
    
    
    }
 
    
    
    class Point {
        public int x;
        public int y;
    
        public Point(int _x, int _y){
        x = _x;
        y = _y;
        }
        public override string ToString()
        {
            return string.Format("[{0}:{1}]",x,y);
        }
    }
 
}