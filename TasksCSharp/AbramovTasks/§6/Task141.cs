using  System;

namespace T141
{
    class Task141
    {
        public static void Main(string[] args)
        {
            double hk = 5;
            double h = 0.5;
            do
            {
                Console.WriteLine("h={0}; r={1}",h, Math.Sqrt(1/(3.14*h)));
            }
            while ((h += 0.5) <= hk);
        }
    }
}