using System;


namespace polindrom
{
    public class forme
    {
        public static string FindAndShowPalindrom(string s, int l)
        {
            string MaxLongPalindrom = string.Empty;
 
            for (int i = 0; i < s.Length && l + i < s.Length; i++)
            {
                string newStr = s.Substring(i, l + 1);
 
                char[] obrtext = newStr.ToCharArray();
 
                Array.Reverse(obrtext);
 
                string finaltext = new string(obrtext);
 
                if (newStr == finaltext)
                {
                    //MessageBox.Show("Данная запись является палиндромом");
                    Console.WriteLine("Палиндромом {0}", newStr);
 
                    if (newStr.Length > MaxLongPalindrom.Length)
                        MaxLongPalindrom = newStr;
                }
 
            }
            return MaxLongPalindrom;
        }
 
        static void Main()
        {
            int n;
 
            bool flag = true;
 
            do
            {
                flag = true;
                n = 0;
                Console.WriteLine("Введите натуральное число n > 15:");
                if (int.TryParse(Console.ReadLine(), out n))
                    if (n >= 0 && n > 15) flag = false;
                    else flag = true;
                else flag = true;
            }
            while (flag);
            string str = string.Empty;
            do
            {
                Console.WriteLine();
                str = string.Empty;
                Console.WriteLine("Введите {0} символов", n);
                str = Console.ReadLine();
            }
            while (str.Length < n);
 
            string MaxLongPalindrom = string.Empty;
            Console.WriteLine();
            for (int i = 1; i < str.Length; i++)
            {
                string Palindrom = FindAndShowPalindrom(str, i);
                if (MaxLongPalindrom.Length < Palindrom.Length)
                    MaxLongPalindrom = Palindrom;
            }
            Console.WriteLine();
            if (MaxLongPalindrom != string.Empty)
                Console.WriteLine("Наибольшая длина символов-палиндромов {0}", MaxLongPalindrom.Length);
            else
                Console.WriteLine("0");
            //Delay
            Console.ReadKey();
        }
    }
}