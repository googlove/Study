using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<int> instance = new BinaryTree<int>();
            instance.Add(8);
            instance.Add(5);
            instance.Add(13);
            foreach (var item in instance)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(instance.Contains(1));
            Console.WriteLine(instance.Contains(5));
            Console.WriteLine();
            instance.Remove(2);
            instance.Remove(8);
            foreach (var item in instance)
            {
                Console.WriteLine(item);
            }
            
            Console.ReadKey();
        }
    }
}
