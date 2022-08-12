
using System;

namespace Abramov
{
    internal class Task75
    {
        public static void Main(string[] args)
        {

            int k = 0;
            int l = 0;
            int n;
            int sum = 0;

            Console.Write("Введите число: ");
            Int32.TryParse(Console.ReadLine(), out n); // число

            {
                {
                    if (n % 5 == 0 || n % 3 == 0)
                    {
                        {
                            if (n % 3 == 0)
                                Console.Write("Тройками");
                        }
                        {
                            if (n % 5 == 0)
                                Console.Write("Пятерками");
                        }
                    }


                    else
                    {
                        while (sum != n)
                        {
                            k += 3;
                            sum = k + l;


                            {
                                if (sum > n)
                                {
                                    sum = 0;
                                    k = 0;
                                    l += 5;

                                }
                            }



                        }

                        Console.Write("Число состоит из {0} троек и {1} пятерок sum = {2}", k / 3, l / 5, sum);
                        Console.ReadKey();


                    }

                    Console.ReadKey();

                }
            }
        }
    }
}
