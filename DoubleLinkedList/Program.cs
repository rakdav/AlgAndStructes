﻿using DoubleLinkedList;

DoublyLinkedList<string> linkedList = new DoublyLinkedList<string>();
// добавление элементов
linkedList.Add("Bob");
linkedList.Add("Bill");
linkedList.Add("Tom");
linkedList.AddFirst("Kate");
foreach (var item in linkedList)
{
    Console.WriteLine(item);
}
// удаление
linkedList.Remove("Bill");
Console.WriteLine();
// перебор с последнего элемента
foreach (var t in linkedList.BackEnumerator())
{
    Console.WriteLine(t);
}
