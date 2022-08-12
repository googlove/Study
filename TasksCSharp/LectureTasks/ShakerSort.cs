using System;

namespace ShakerSort
{
    class Program
    {
       static void Main(int[] myint)
            {
                int left = 0,
                    right = myint.Length - 1,
                    count = 0;

                while (left < right)
                {
                    for (int i = left; i < right; i++)
                    {
                        count++;
                        if (myint[i] > myint[i + 1])
                            Swap(myint, i, i + 1);
                    }

                    right--;

                    for (int i = right; i > left; i--)
                    {
                        count++;
                        if (myint[i - 1] > myint[i])
                            Swap(myint, i - 1, i);
                    }

                    left++;
                }

                Console.WriteLine("\nКоличество сравнений = {0}", count.ToString());
            }

            /* Поменять элементы местами */
            static void Swap(int[] myint, int i, int j)
            {
                int glass = myint[i];
                myint[i] = myint[j];
                myint[j] = glass;
            }
        }
    }