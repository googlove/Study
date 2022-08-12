#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <windows.h>
#include <stdlib.h>
#define SIZE 8
using namespace std;
int main()
{
  int a[SIZE][SIZE]; 
  int d[SIZE]; 
  int v[SIZE]; 
  int temp, minindex, min;
  int begin_index = 0;
  SetConsoleOutputCP(1251);
    SetConsoleCP(1251);

  system("cls");
  for (int i = 0; i<SIZE; i++)
  {
    a[i][i] = 0;
    for (int j = i + 1; j<SIZE; j++) {
      printf("Введите расстояние %d - %d: ", i + 1, j + 1);
      scanf("%d", &temp);
      a[i][j] = temp;
      a[j][i] = temp;
    }
  }
  // Вывод матрицы связей
  for (int i = 0; i<SIZE; i++)
  {
    for (int j = 0; j<SIZE; j++)
      printf("%5d ", a[i][j]);
    printf("\n");
  }
  //Инициализация вершин и расстояний
  for (int i = 0; i<SIZE; i++)
  {
    d[i] = 10000;
    v[i] = 1;
  }
  d[begin_index] = 0;
  // Шаг алгоритма
  do {
    minindex = 10000;
    min = 10000;
    for (int i = 0; i<SIZE; i++)
    { // Если вершину ещё не обошли и вес меньше min
      if ((v[i] == 1) && (d[i]<min))
      { // Переприсваиваем значения
        min = d[i];
        minindex = i;
      }
    }
    if (minindex != 10000)
    {
      for (int i = 0; i<SIZE; i++)
      {
        if (a[minindex][i] > 0)
        {
          temp = min + a[minindex][i];
          if (temp < d[i])
          {
            d[i] = temp;
          }
        }
      }
      v[minindex] = 0;
    }
  } while (minindex < 10000);
  printf("\nКратчайшие расстояния до вершин: \n");
  for (int i = 0; i<SIZE; i++)
    printf("%5d ", d[i]);

  int ver[SIZE]; 
  int end = 4; 
  ver[0] = end + 1; 
  int k = 1; 
  int weight = d[end]; 

  while (end != begin_index)
  {
    for (int i = 0; i<SIZE; i++)
      if (a[end][i] != 0)  
      {
        int temp = weight - a[end][i]; 
        if (temp == d[i])
        {                 
          weight = temp; 
          end = i;      
          ver[k] = i + 1; 
          k++;
        }
      }
  }
  printf("\nВывод кратчайшего пути\n");
  for (int i = k - 1; i >= 0; i--)
    printf("%3d ", ver[i]);
  getchar(); getchar();
  return 0;
}
