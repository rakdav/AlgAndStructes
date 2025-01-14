//алгоритмы сортировки

using System.Diagnostics;

Random random = new Random();
int[] mas = new int[random.Next(10000, 1000000)];
for (int i = 0; i < mas.Length; i++)
{
    mas[i] = random.Next(0, 10000);
}
Stopwatch stopWatch = new Stopwatch();
stopWatch.Start();
if (mas.LinearSearch(random.Next(0, 10000)) == -1)
{
    Console.WriteLine("Не найден");
}
else
{
    Console.WriteLine("Найден");
}
stopWatch.Stop();
Console.WriteLine("Время работы алгоритма:"+stopWatch.ElapsedMilliseconds.ToString());

Array.Sort(mas);
stopWatch = new Stopwatch();
stopWatch.Start();
if (mas.BinarySearch(random.Next(0, 10000),0,mas.Length) == -1)
{
    Console.WriteLine("Не найден");
}
else
{
    Console.WriteLine("Найден");
}
stopWatch.Stop();
Console.WriteLine("Время работы алгоритма:" + stopWatch.ElapsedMilliseconds.ToString());
static class ArrayExt
{
    public static void CheckArray<T>(T[] a)
    {
        if (a == null)
        {
            throw new ArgumentNullException("Массив не может быть нулевым");
        }
        if (a.Length == 0)
        {
            throw new ArgumentException("Длина массива должна быть больше нуля");
        }
    }
    //линейный
    public static int LinearSearch<T>(this T[] mas, T key) where T : struct, IComparable<T>
    {
        CheckArray(mas);
        for (int i = 0; i < mas.Length; i++)
        {
            if (mas[i].Equals(key)) return i;
        }
        return -1;
    }
    //бинарный
    public static int BinarySearch(this int[] mas,int key,int first,int last)
    {
        if (first > last) return -1;
        var middle = (first + last) / 2;
        var middleValue = mas[middle];
        if (middleValue == key) return middle;
        else
        {
            if (middleValue > key) return BinarySearch(mas, key, first, middle - 1);
            else return BinarySearch(mas, key, middle+1, last);
        }
    }
}
