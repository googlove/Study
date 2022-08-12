using System;

namespace T302
{
    class Task302
    {
        public static void Main(string[] args)
        {
            int[] digits = new int[10];
            int number = Convert.ToInt32(Console.ReadLine());
 
            while (number > 0) {
                int rem;
                number = Math.DivRem(number, 10, out rem);
                digits[rem]++;
            }
            for (int i = 0; i < digits.Length; i++)
                Console.WriteLine("{0}: {1}", i, digits[i]);
        }
    }
}