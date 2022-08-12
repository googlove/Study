using SimpleAlgorithmsApp;
using System;
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<string> linkedList = new LinkedList<string>();
// добавление элементов
linkedList.Add("Tom");
linkedList.Add("Alice");
linkedList.Add("Bob");
linkedList.Add("Sam");
 
// выводим элементы
foreach(var item in linkedList)
{
    Console.WriteLine(item);
}
// удаляем элемент
linkedList.Remove("Alice");
foreach (var item in linkedList)
{
    Console.WriteLine(item);
}
// проверяем наличие элемента
bool isPresent = linkedList.Contains("Sam");
Console.WriteLine(isPresent == true ? "Sam присутствует" : "Sam отсутствует");
 
// добавляем элемент в начало            
linkedList.AppendFirst("Bill");
        }
    }
