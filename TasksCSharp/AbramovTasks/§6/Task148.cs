using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3
{
    class Task148
    {
        static void Main(string[] args)
        {

            //6.	Составить программу печати таблицы температур по Цельсию от 0 до 100 градусов 
            //с шагом в один градус и их эквивалентов по шкале Фаренгейта, используя для перевода формулу tF = 9tc/5 + 32.

            for (int temperature = 0; temperature < 101; temperature++)
            {

                double tFarinhate = 9 * temperature / 5 + 32;
                Console.WriteLine($"Градус Цельсія: {temperature} = {tFarinhate} F");

            }
            Console.ReadKey();
        }


    }
    

    }
