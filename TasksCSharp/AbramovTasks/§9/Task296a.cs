using System;

namespace Task296
{ 
    class Task296a
    {
        const int n = 20;
        static Random rand = new Random();
        static void Main(string[] args)
        {
            int[] array = new int[n];
            int min = 0;
            int max = 0;
 
            for (int i = 0; i < n; i++)
            {
                array[i] = rand.Next(30) - 5;
                Console.Write("{0,3} ", array[i]);
                if (array[i] > array[max])
                    max = i;
                if (array[i] > array[min])
                    min = i;
            }
 
            int t = array[max];
            array[max] = array[min];
            array[min] = t;
            Console.WriteLine();
 
            for (int i = 0; i < n; i++) 
                Console.Write("{0,3} ", array[i]);
            Console.ReadKey();
        }
    }
}
