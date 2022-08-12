using System;
using System.Linq;

namespace _207
{


    class Task207
    {
        private static void Main()
        {
            const int n = 59015509;

            int result = int.Parse(new string(n.ToString().Where(x => x != '0' && x != '5').ToArray()));

            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}