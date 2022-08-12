using System;

namespace Tak256
{
     class Tak256ab
    {
        public static void Main(string[] args)
        {
            string str = "2,1,,123,3,4,";
            int first = str.IndexOf(',');
            int last = str.LastIndexOf(',');
            
            Console.WriteLine("first = {0} last = {1}", first, last);

        }
    }
}