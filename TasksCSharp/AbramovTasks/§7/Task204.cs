using System;


namespace _204
{
    class Task204
    {

        
            static void Main(string[] args)
            {
                int[] a = new int[8];
                int vis = 0, nis = 1111, psum = 0;
                double osum = 0.0;
                Console.WriteLine("Введите 8 оценок");
                for (int i = 0;
                    i < a.Length;
                    i++)
                    a[i] = Convert.ToInt32(Console.ReadLine());
                for (int i = 0;
                    i < a.Length;
                    i++)
                    Console.WriteLine("Оценки спортсмена = " + a[i]);
                for (int i = 0;
                    i < a.Length;
                    i++)
                {
                    if (a[i] > vis)
                        vis = a[i];
                    if (a[i] < nis)
                        nis = a[i];
                }

                Console.WriteLine("Самая низкая оценка = " + nis);
                Console.WriteLine("Самая высокая оценка = " + vis);
                for (int i = 0;
                    i < a.Length;
                    i++)
                    psum = psum + a[i];
                osum = ((psum - nis - vis));
                osum = osum / 6;
                Console.WriteLine("Среднее арифметическое без учёта наибольшей и наименьшей оценок = "
                                  + string.Format("{0:F3}", osum));
                Console.ReadKey();
            }
        }
    }

