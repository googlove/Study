using System;

namespace Task262
{
    class Task262b
    {
        public static void Main(string[] args)
        {
            //б) сделано задание aba, код универсален.
            string str = "ababbbbabaaba"; // 3
            string str1 = "aba";
 
            int i = 0, cnt = 0;
            while ((i = str.IndexOf(str1, i)) >= 0)
            {
                i += str1.Length;
                cnt++;
            }
 
            Console.WriteLine(cnt);
        }
    }
}