using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
namespace _182
{
    class Task182
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите N:");
            string s = Console.ReadLine();
            int count = Convert.ToInt32(s);
            int[] list = new int[count];
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Введите " + i.ToString() + " число:");
                list[i] = Convert.ToInt32(Console.ReadLine());
            }
            int k = 0, c = 0;
            for (int i = 0; i < count; i++)
            {
                if ((list[i] % 5 == 0) && (list[i] % 7 != 0))
                {
                    k++;
                    c += list[i];
                }
            }
            Console.WriteLine("Кол-во: " + k.ToString());
            Console.WriteLine("Сумма: " + c.ToString());
            Console.ReadKey();
        }
    }
}