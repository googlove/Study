using System;
using System.Collections.Generic;

namespace _329
{
    class Task329
    {

        static int[] SplitToDigits(int n)
        {
            List<int> digits = new List<int>();

            do
            {
                digits.Add(n % 10);
                n /= 10;
            } while (n != 0);

            return digits.ToArray();
        }

        static int Sum(int[] arr)
        {
            int sum = 0;
            foreach (int i in arr)
                sum += i;

            return sum;
        }

        static void Main(string[] args)
        {
            const int N = 10000;
            const int M = 4;

            for (int i = 0; i < N; ++i)
            {
                int digitsSum = Sum(SplitToDigits(i));
                if (digitsSum * digitsSum == M)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}



            
        
    