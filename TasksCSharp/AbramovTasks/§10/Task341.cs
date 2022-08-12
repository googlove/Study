using System;

namespace _341
{
      class Task341
      {
          static void Main(string[] args)
          {
              int[] arr = { 1, 2, 4, 7, 3, 1 };
   
              int minDiff = Int32.MaxValue;
              int minDiffId1 = -1;
              int minDiffId2 = -1;
   
              int maxDiff = Int32.MinValue;
              int maxDiffId1 = -1;
              int maxDiffId2 = -1;
   
              for (int i = 0; i < arr.Length; ++i)
              {
                  for (int j = i + 1; j < arr.Length; ++j)
                  {
                      int absDiff = Math.Abs(arr[i] - arr[j]);
                      if (absDiff < minDiff)
                      {
                          minDiff = absDiff;
                          minDiffId1 = i;
                          minDiffId2 = j;
                      }
   
                      if (absDiff > maxDiff)
                      {
                          maxDiff = absDiff;
                          maxDiffId1 = i;
                          maxDiffId2 = j;
                      }
                  }
              }
   
              Console.WriteLine(String.Join(" ", arr));
              Console.WriteLine("Минимальная разность = {0}. Элементы: {1}, {2}", minDiff, arr[minDiffId1], arr[minDiffId2]);
              Console.WriteLine("Максимальная разность = {0}. Элементы: {1}, {2}", maxDiff, arr[maxDiffId1], arr[maxDiffId2]);
          }
      }
      }