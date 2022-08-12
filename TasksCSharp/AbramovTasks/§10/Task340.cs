using System;


namespace _340
{
     class Task340
    {
        public static void Main(string[] args)
        {
            int[] fun(int[] a, int m)
            {
                int len = a.Length, i, j, k;
                for (i = 0; i < len; i++)
                for (j = i; j < len; j++)
                for (k = j; k < len; k++)
                    if (a[i] + a[j] + a[k] == m)
                    {
                        int[] ret = new int[3];
                        ret[0] = i; ret[1] = j; ret[2] = k;
                        return ret;
                    }
                return null;  
            }
            {
                Random r = new Random();
                int[] a = new int[20];
                string str = "values: ";
                for (int i = 0; i < 20; i++) str += (a[i] = r.Next(30) + 2).ToString()+" ";
                int m = 30;
                str += "\nm: "+m.ToString()+"\n";
                int[] result = fun(a,m);
                if (result == null) Console.WriteLine(str+"no result");
                else Console.WriteLine(str+"result: "+result[0].ToString()+" "+result[1].ToString()+" "+result[2].ToString());
            }
        }
    }
}