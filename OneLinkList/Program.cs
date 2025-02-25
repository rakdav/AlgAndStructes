using OneLinkList;

OneLinkList.LinkedList<string> list = new OneLinkList.LinkedList<string>();
list.Add("Tom");
list.Add("Bob");
list.Add("Sam");
list.Add("Голубчиков");
foreach (var item in list)
{
    Console.Write(item+" ");
}
Console.WriteLine();
Console.WriteLine(list.Count);
list.Remove("Голубчиков");
foreach (var item in list)
{
    Console.Write(item + " ");
}
Console.WriteLine();
Console.WriteLine(list.Contains("Sam")?"Присутствует":"отсутствует");
list.Clear();
list.AppendFirst("Bill");
foreach (var item in list)
{
    Console.Write(item + " ");
}