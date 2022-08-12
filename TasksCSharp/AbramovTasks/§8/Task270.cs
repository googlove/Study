using System;
using System.Text.RegularExpressions;

namespace Task270g
{
    class Task270
    {
        public static void Main(string[] args)
        {
            string str = "ab + 0.1973 - 1.1 ";
            string newline = null;
            foreach(string line in str.Split(' '))
            {
                if(new Regex(@"\d+.\d+").IsMatch(line))
                {
                    if(line.Split('.')[1].Length > 2)
                    {
                        newline += line.Remove(line.IndexOf('.') + 3) + " ";
                    }
                    else
                    {
                        newline += line + " ";
                    }
                }
                else
                {
                    newline += line + " ";
                }
                
            }
            Console.WriteLine(newline);
            Console.ReadLine();
        }
        }
    }
