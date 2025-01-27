using System.ComponentModel;
using System.Diagnostics;

int[] mas = new int[10000000];
Random random = new Random();
for (int i = 0; i < mas.Length; i++)
    mas[i] = random.Next(1, 1000);
Stopwatch stopWatch1 = new Stopwatch();
stopWatch1.Start();
//mas = BubbleSort(mas);
//mas = ShakerSort(mas);
//mas = InsertionSort(mas);
//mas = StoogeSort(mas, 0, mas.Length - 1);
//mas = ShellSort(mas);
mas = MergeSort(mas, 0, mas.Length - 1);
stopWatch1.Stop();
//foreach(int i in mas) Console.Write(i+" ");
Console.WriteLine();
Console.WriteLine("Время работы алгоритма:" + stopWatch1.ElapsedMilliseconds.ToString());
//Stopwatch stopWatch2 = new Stopwatch();
//stopWatch2.Start();
//mas = PancakeSort(mas);
//Console.WriteLine("Время работы алгоритма:" + stopWatch2.ElapsedMilliseconds.ToString());

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
//Реализация сортировки по частям
int[] StoogeSort(int[] mas,int startIndex,int endIndex)
{
    if (mas[startIndex] > mas[endIndex])
    {
        Swap(ref mas[startIndex], ref mas[endIndex]);
    }
    if (endIndex - startIndex > 1)
    {
        var len = (endIndex - startIndex + 1) / 3;
        StoogeSort(mas, startIndex, endIndex - len);
        StoogeSort(mas, startIndex+len, endIndex);
        StoogeSort(mas, startIndex, endIndex - len);
    }
    return mas;
}
//алгоритм блинной сортировки
void Flip(int[] mas,int end)
{
    for(var start=0;start<end;start++,end--)
    {
        var temp = mas[start];
        mas[start] = mas[end];
        mas[end] = temp;
    }
}
int IndexOfMax(int[] mas,int n)
{
    int result = 0;
    for (int i = 1; i <=n; i++)
    {
        if (mas[i] > mas[result]) result = i;
    }
    return result;
}
int[] PancakeSort(int[] mas)
{
    for (var subarrayLength=mas.Length-1;subarrayLength>=0;subarrayLength--)
    {
        var indexOfMax = IndexOfMax(mas, subarrayLength);
        if(indexOfMax!=subarrayLength)
        {
            Flip(mas, indexOfMax);
            Flip(mas, subarrayLength);
        }
    }
    return mas;
}

//сортировка Шелла
int[] ShellSort(int[] mas)
{
    var d = mas.Length / 2;
    while (d >= 1)
    {
        for (int i = d; i < mas.Length; i++)
        {
            var j = i;
            while ((j >= d) && (mas[j - d] > mas[j]))
            {
                Swap(ref mas[j], ref mas[j - d]);
                j = j - d;
            }
        }
        d = d / 2;
    }
    return mas;
}
//сортировка слиянием
//метод слияния массивов
void Merge(int[] mas,int lowIndex,int middleIndex,int highIndex)
{
    var left = lowIndex;
    var right = middleIndex + 1;
    var tempArray = new int[highIndex - lowIndex + 1];
    var index = 0;
    while((left<=middleIndex)&&(right<=highIndex))
    {
        if (mas[left] < mas[right])
        {
            tempArray[index] = mas[left];
            left++;
        }
        else
        {
            mas[index] = mas[right];
            right++;
        }
        index++;
    }
    for (int i = left; i <=middleIndex; i++)
    {
        mas[index] = mas[i];
        index++;
    }
    for (int i = right; i <=highIndex; i++)
    {
        mas[index] = mas[i];
        index++;
    }
    for (int i = 0; i < mas.Length; i++)
    {
        mas[lowIndex + i] = mas[i];
    }
}
int[] MergeSort(int[] mas,int lowIndex,int highIndex)
{
    if (lowIndex < highIndex)
    {
        var middleIndex = (lowIndex + highIndex) / 2;
        MergeSort(mas, lowIndex, middleIndex);
        MergeSort(mas, middleIndex + 1, highIndex);
        Merge(mas, lowIndex, middleIndex, highIndex);
    }
    return mas;
}

