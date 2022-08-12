using System;

namespace Task269v
{ 
    class Task269
    {
        public static void Main(string[] args)
        {
            string sentense1 = "brb brilliant bbcode bbc bershka";
 
            string[] sentense1Spl = sentense1.Split(' ', '.');
 
            int count = 0;
 
            foreach (var s in sentense1Spl)
            {
                if (s.Substring(0, 1) == "b")
                    count++;
            }
            Console.WriteLine(count);
            Console.ReadLine();
        }
        }
    }
