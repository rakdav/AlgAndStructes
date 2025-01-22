using System.Diagnostics;

int[] mas = new int[100000];
Random random = new Random();
for (int i = 0; i < mas.Length; i++)
    mas[i] = random.Next(1, 1000);
Stopwatch stopWatch = new Stopwatch();
stopWatch.Start();
//mas = BubbleSort(mas);
//mas = ShakerSort(mas);
mas = InsertionSort(mas);
stopWatch.Stop();
Console.WriteLine("Время работы алгоритма:" + stopWatch.ElapsedMilliseconds.ToString());

void Swap(ref int a,ref int b)
{
    var temp = a;
    a = b;
    b = temp;
}
//сортировка пузырьком
int[] BubbleSort(int[] mas)
{
    for (int i = 0; i < mas.Length-1; i++)
    {
        for (int j = i+1; j < mas.Length; j++)
        {
            if (mas[i] > mas[j]) Swap(ref mas[i], ref mas[j]);
        }
    }
    return mas;
}
//шейкерная сортировка
int[] ShakerSort(int[] mas)
{
    for(int i = 0; i < mas.Length / 2; i++)
    {
        var swapFlag = false;
        for (int j = i; j < mas.Length-i-1; j++)
        {
            if (mas[j] > mas[j+1])
            {
                Swap(ref mas[j - 1], ref mas[j]);
                swapFlag = true;
            }
        }
        for(var j = mas.Length - 2 - i; j > i; j--)
        {
            if (mas[j - 1] > mas[j])
            {
                Swap(ref mas[j - 1], ref mas[j]);
                swapFlag = true;
            }
        }
        if (!swapFlag) break;
    }
    return mas;
}
//сортировка вставками
int[] InsertionSort(int[] array)
{
    for(var i = 1; i < mas.Length; i++)
    {
        var key = mas[i];
        var j = i;
        while ((j > 1) && (mas[j-1]>key))
        {
            Swap(ref mas[j - 1], ref mas[j]);
            j--;
        }
        mas[j] = key;
    }
    return mas;
}
