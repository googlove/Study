using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace RSA
{
    static class Program
    {
        private static void Main()
        {
            try
            {
                Console.WriteLine("           *****    Ласкаво просимо, ЧИМ МИ МОЖЕМО ВАМ ДОПОМОГТИ?     *****\n");
            A:
                Console.WriteLine("           *****              Головне меню              *****\n");
                Console.WriteLine("Натиснiть \"1\" Якщо Ви хочете зашифрувати свої Персональнi данi\n");
                Console.WriteLine("Натиснiть \"2\" Якщо Ви хочете РАЗШИРОВАТИ свої Персональнi данi\n");
                Console.WriteLine("Натиснiть \"3\" Якщо ви хочете Згенерувати КЛЮЧ ШИФРОВАННЯ\n\n");
                int x = Convert.ToInt16(Console.ReadLine());
                if (x == 1)
                {
                    Console.WriteLine("PRESS \"1\" Якщо у вас є КЛЮЧ ШИФРОВАННЯ");
                    Console.WriteLine("PRESS \"0\" Повернутися назад");
                    x = Convert.ToInt16(Console.ReadLine());
                    if (x == 1)
                    {
                        DataEncrypt objdataEncrypt = new DataEncrypt();
                        Console.WriteLine("Введiть ключ шифрування = ");
                        ulong e = Convert.ToUInt64(Console.ReadLine());
                        Console.WriteLine("Введiть MOD (n) = ");
                        ulong n = Convert.ToUInt64(Console.ReadLine());
                        Console.WriteLine("Введiть шлях до файлу");
                        string path = Directory.GetCurrentDirectory() + "/../../../data.txt";
                        objdataEncrypt.Encrypt(e, n, path, x);
                        goto A;
                    }
                    else
                        goto A;
                }
                else
                {
                    if (x == 2)
                    {
                        DataEncrypt objdataEncrypt = new DataEncrypt();
                        Console.WriteLine("Введiть ключ дешифрування");
                        ulong e = Convert.ToUInt64(Console.ReadLine());
                        Console.WriteLine("Введiть MOD (n) = ");
                        ulong n = Convert.ToUInt64(Console.ReadLine());
                        Console.WriteLine("Введiть шлях до файлу");
                        string path = Directory.GetCurrentDirectory() + "/../../../data.txt"; //Console.ReadLine();
                        objdataEncrypt.Encrypt(e, n, path, x);
                        goto A;
                    }
                    if (x == 3)
                    {
                        Encryptor objEncryptor = new Encryptor();
                        objEncryptor.KeyGenerator();
                        goto A;
                    }
                    else
                        goto A;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }

    class Encryptor
    {
        uint _p, _q;
        ulong _n, _fin, _e, _d;
        bool _x = true, _y = true;
        public void KeyGenerator()
        {
            uint temp;
            do
            {
                Console.WriteLine("Введiть будь-якi два простих числа");
                Console.WriteLine("Go for Some Real Big Thing like...");
                Console.WriteLine("127, 131, 137, 139, 149, 151, 157, 163, 167, 173, 179, 181, 191, 193, 197, 199, etc... \n 1009 1013 1019 1021 1031 1033 1039 1049 1051 1061 1063 1069 1087 1091 1093 1097 1103 1109 1117 1123 1129 \n  9803 9811 9817 9829 9833 9839 9851 9857 9859 9871 9883 9887 9901 9907 9923 9931 9941 9949 ");
                _p = Convert.ToUInt32(Console.ReadLine());
                _q = Convert.ToUInt32(Console.ReadLine());
                temp = _p * _q;
                _x = PrimeChecker(_p);
                _y = PrimeChecker(_q);
            } while (_x == false || _y == false || temp < 95 || _p == _q);

            _n = _p * _q; Console.WriteLine("n = " + _n);
            _fin = (_p - 1) * (_q - 1); Console.WriteLine("fin = " + _fin);
            //1 < e && e < fin
            CoPrime(_e, _fin); Console.WriteLine("e = " + _e);
            for (uint i = 0; i < _fin * _fin; i++)
            {
                if ((i * _e) % _fin == 1)
                {
                    _d = i;
                    Console.WriteLine("d = " + _d);
                    break;
                }
            }
        }

        bool PrimeChecker(uint a)
        {
            bool isPrime = true;
            for (int i = 2; i <= a / 2; ++i)
            {
                if (a % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }
            return isPrime;
        }

        private void CoPrime(ulong ekey, ulong fiN)
        {
            for (ekey = 0; ekey < fiN; ekey++)
            {
                var isCoPrime = true;
                for (uint i = 2; i < fiN; i++)
                {
                    if ((fiN % i == 0 || i % fiN == 0) && (ekey % i == 0 || i % ekey == 0) && ekey != i)
                    {
                        //Console.WriteLine(i);
                        isCoPrime = false;
                        break;
                    }
                }

                if (!isCoPrime) continue;
                //Console.WriteLine(fiN + " and " + ekey + " are co primes");
                _e = ekey;
                break;
            }
        }

    }

    internal class DataEncrypt
    {
        public void Encrypt(ulong e, ulong n, string path, int a)
        {
            // Readfilefunction
            Console.WriteLine("Reading Data from your File.");
            string data = Reading(path);
            // MOD 95 0..94   32..126     
            //RSA method 
            // getting ascii
            Console.WriteLine("The Ascii Values are ....................................");
            int x = data.Count();
            int[] asciiArray = new int[x];
            for (int i = 0; i < x; i++)
            {
                asciiArray[i] = Convert.ToInt16(data[i]);
                Console.Write(asciiArray[i] + " ");
            }
            Console.Write("\n \n");
            Console.WriteLine("Кроки, якi ми таємно робимо:");
            Console.WriteLine("***Вiдображення***");        
            // mapping    [32,126] ----> [0,94]
            int[] mappedArray = new int[x];
            for (int i = 0; i < x; i++)
            {
                mappedArray[i] = ((asciiArray[i] - 32) * ((94 - 0) / (126 - 32))) + 0;
                //Console.Write(mappedArray[i] + " ");                                             
            }
            Console.Write("\n");                                                             
            // encryption
            Console.WriteLine("***Блоковий метод***");                                            
            ulong[] blocks;
            if (a == 1)
            {
                blocks = BlockMeToE(mappedArray, n); // block method
                Console.WriteLine("*****Шифрування блокiв даних.*****");
                Console.WriteLine(" Following are the Encrypted Numbers.");
            }
            else
            {
                blocks = BlockMeToD(mappedArray, n);
                Console.WriteLine("Розшифровка блокiв даних.");
                Console.WriteLine("Нижче наведено розшифрованi числа.");
            }

            var c = new int[blocks.Count()];
            for (var i = 0; i < blocks.Count(); i++)
            {
                c[i] = (int)iCanEncrypt(blocks[i], e, n);
                Console.Write(c[i] + " ");
            }
            Console.Write("\n \n");
            Console.WriteLine("ReBlock, to change it to printable asciis");
            int[] tuDigNum;
            if (a == 1)
            {
                tuDigNum = ReBlockE(c, n);
            }
            else
            {
                tuDigNum = ReBlockD(c, n);
            }
            Console.WriteLine("Назад на карту.");
            // data is now encrypted 
            // map back
            // mapping   [32,126] <---- [0, 94]
            x = tuDigNum.Count();
            int[] newmapArry = new int[tuDigNum.Count()];
            for (int i = 0; i < tuDigNum.Count(); i++)
            {
                newmapArry[i] = ((tuDigNum[i] - 0) * ((94 - 0) / (126 - 32))) + 32;
                //Console.Write(newmapArry[i] + " ");
            }
            Console.Write("\n");
            // get char
            Console.WriteLine("Отримання символiв....");
            char[] chars = new char[x];
            for (int i = 0; i < x; i++)
            {
                chars[i] = Convert.ToChar(newmapArry[i]);
                // print string
                Console.Write(chars[i]);
            }
            Console.Write("\n");
            string charsStr = new string(chars);
            Console.WriteLine(Writing(charsStr, path));
        }

        static string Reading(string path)
        {
            string data = null;
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string line;
                    for (var i = 0; (line = sr.ReadLine()) != null; i++)
                    {
                        data += line;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            Console.WriteLine(data);
            return (data);
        }

        private static string Writing(string data, string path)
        {
            try
            {
                using (var fw = new StreamWriter /*File.AppendText*/(path))
                {
                    fw.WriteLine(data);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be write:");
                Console.WriteLine(e.Message);
            }
            return ("File has been Written");
        }

        ulong[] BlockMeToE(int[] mappedArray, ulong n)
        {
            List<char> outp = new List<char>();
            for (int i = 0; i < mappedArray.Count(); i++)      //Adding zeros to make each digit even
            {
                if (mappedArray[i] < 10)
                {
                    outp.Add(Convert.ToChar(48));           // 48 is ascii of 0
                    outp.Add(Convert.ToChar(mappedArray[i] + 48));
                }
                else
                {
                    outp.Add(Convert.ToChar((mappedArray[i] / 10) + 48));
                    outp.Add(Convert.ToChar((mappedArray[i] % 10) + 48));
                }
            }
            //------------------------------------------------------------------
            int nDigtInPairs = 0;
            ulong pairs = 95;           //Checking which 95 pair is close to n
            while (true)
            {
                if (pairs > n)
                {
                    break;
                }
                pairs = 95 + (pairs * 100);
                nDigtInPairs = nDigtInPairs + 2;
            }

            //nDigtInPairs = nDigtInPairs - 2;
            //Console.WriteLine("Block Pair number is = " + pairs);       // pair has the 95 pair value close to n
            //Console.WriteLine("Number of digits in Pairs is = " + nDigtInPairs);
            //------------------------------------------------------------------
            var fizzalogic = outp.Count() % nDigtInPairs;
            for (var i = 0; i < fizzalogic; i++) { outp.Insert(0, '0'); } // adding zeros to make it proper blocks 

            var block = new char[nDigtInPairs];
            var blockstring = new List<string>();      //making blocks and saving them to induvidual string
            var f = 0;
            for (var i = 0; i < outp.Count(); i++)
            {
                block[f] = outp[i];
                f += 1;
                if (f < nDigtInPairs) continue;
                blockstring.Add(new string(block));
                f = 0;
            }
            //------------------------------------------------------------------
            //Console.WriteLine("Blocks are ....................................................");
            var hehe = blockstring.ToArray();
            var blocknums = new ulong[blockstring.Count()];     //each block is converting to number
            for (var i = 0; i < blockstring.Count(); i++)
            {
                blocknums[i] = Convert.ToUInt64(hehe[i]);
                //Console.Write(hehe[i] + " ");
            }
            Console.Write("\n");

            return blocknums;
        }
        ulong[] BlockMeToD(int[] mappedArray, ulong nn)
        {
            var sn = Convert.ToString(nn);
            var nDigtInPairs = sn.Count();
            //Console.WriteLine("Block Pair number is = " + nDigtInPairs);       // block pair number is nDigitinPairs =to number of digits in n

            var outp = new List<char>();
            for (var i = 0; i < mappedArray.Count(); i++)      //Adding zeros to make each digit even
            {
                if (mappedArray[i] < 10)
                {
                    outp.Add(Convert.ToChar(48));           // 48 is ascii of 0
                    outp.Add(Convert.ToChar(mappedArray[i] + 48));
                }
                else
                {
                    outp.Add(Convert.ToChar((mappedArray[i] / 10) + 48));
                    outp.Add(Convert.ToChar((mappedArray[i] % 10) + 48));
                }
            }
            //------------------------------------------------------------------
            var fizzalogic = outp.Count() % nDigtInPairs; //comented
            ///*may be at the end*/
            for (var i = 0; i < fizzalogic; i++) { outp.Insert(0, '0'); } // adding zeros to make it proper blocks 

            var block = new char[nDigtInPairs];
            var blockstring = new List<string>();      //making blocks and saving them to induvidual string
            var f = 0;
            for (var i = 0; i < outp.Count(); i++)
            {
                block[f] = outp[i];
                f = f + 1;
                if (f >= nDigtInPairs)
                {
                    blockstring.Add(new string(block));
                    f = 0;
                }
            }

            //Console.WriteLine("Blocks are ....................................................");  
            string[] hehe = blockstring.ToArray();
            ulong[] blocknums = new ulong[blockstring.Count()];     //each block is converting to number
            for (int i = 0; i < blockstring.Count(); i++)
            {
                blocknums[i] = Convert.ToUInt64(hehe[i]);
                //Console.Write(hehe[i] + " ");
            }
            Console.Write("\n");

            return blocknums;
        }

        private int[] ReBlockE(int[] cc, ulong nn)
        {
            var sn = Convert.ToString(nn);
            var xn = sn.Count();

            var ctostring = new List<string>();
            for (var i = 0; i < cc.Count(); i++)
            {
                var temp = Convert.ToString(cc[i]);
                var array = temp.ToCharArray();
                var outp = new List<char>(array);
                while (outp.Count() < xn)
                {
                    outp.Insert(0, '0');
                }
                var hehe = outp.ToArray();
                var s = new string(hehe);
                ctostring.Add(s);
                //Ctostring.Add(temp);
            }
            string x = string.Concat(ctostring.ToArray());
            //string.Join(",", Ctostring.ToArray());
            //Console.WriteLine("concatinated String.................................................................");
            //Console.WriteLine(x);
            //Console.WriteLine("converting to two digit Number......................................................");

            var tuDigitBlock = new List<string>();
            for (var i = 0; i < x.Count(); i = i + 2)
            {
                string b;
                var a = Convert.ToString(x[i]);
                try
                {
                    b = Convert.ToString(x[i + 1]);
                }
                catch (Exception)
                {
                    //Console.WriteLine("writing zeo");
                    b = Convert.ToString('0');
                }
                var two = a + b;
                tuDigitBlock.Add(two);
                //Console.Write(two + " ");
            }
            Console.Write("\n");
            var aarray = tuDigitBlock.ToArray();
            var tuDigNum = new int[aarray.Count()]; // it has array of two digit numbers
            for (var i = 0; i < aarray.Count(); i++)
            {
                tuDigNum[i] = Convert.ToInt16(aarray[i]);
            }
            return tuDigNum;
        }

        private static int[] ReBlockD(IReadOnlyList<int> cc, ulong nn)
        {
            var nDigtInPairs = 0;
            ulong pairs = 95;           //Checking which 95 pair is close to n
            while (true)
            {
                if (pairs > nn)
                {
                    break;
                }
                pairs = 95 + (pairs * 100);
                nDigtInPairs = nDigtInPairs + 2;
            }
            //nDigtInPairs = nDigtInPairs - 2;
            //Console.WriteLine("Block Pair number is = " + pairs);       // pair has the 95 pair value close to n
            //Console.WriteLine("Number of digits in Pairs is = " + nDigtInPairs);

            List<string> ctostring = new List<string>();
            for (var i = 0; i < cc.Count(); i++)
            {
                var temp = Convert.ToString(cc[i]);
                var array = temp.ToCharArray();
                var outp = new List<char>(array);
                while (outp.Count() < nDigtInPairs)
                {
                    outp.Insert(0, '0');
                }
                var hehe = outp.ToArray();
                var s = new string(hehe);
                ctostring.Add(s);
                //Ctostring.Add(temp);
            }
            var x = string.Concat(ctostring.ToArray());
            //string.Join(",", Ctostring.ToArray());
            //Console.WriteLine("concatinated String.................................................................");
            //Console.WriteLine(x);
            //Console.WriteLine("converting to two digit Number......................................................");

            var tuDigitBlock = new List<string>();
            for (int i = 0; i < x.Count(); i = i + 2)
            {
                string b;
                string a = Convert.ToString(x[i]);
                try
                {
                    b = Convert.ToString(x[i + 1]);
                }
                catch (Exception)
                {
                    //Console.WriteLine("writing zeo");
                    b = Convert.ToString('0');
                }
                var two = a + b;
                tuDigitBlock.Add(two);
                //Console.Write(two + " ");
            }
            Console.Write("\n");
            var aarray = tuDigitBlock.ToArray();
            var tuDigNum = new int[aarray.Count()]; // it has array of two digit numbers
            for (var i = 0; i < aarray.Count(); i++)
            {
                tuDigNum[i] = Convert.ToInt16(aarray[i]);
            }
            return tuDigNum;
        }

        private BigInteger iCanEncrypt(ulong num, ulong e, ulong n)
        {
            BigInteger number = num;
            BigInteger exponent = e;
            BigInteger mod = n;
            BigInteger ans = BigInteger.ModPow(number, exponent, mod);
            return ans;
        }

    }

}
