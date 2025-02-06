using System.Collections;
using System.ComponentModel;
using System.Diagnostics;

int[] mas = new int[1000000];
Random random = new Random();
for (int i = 0; i < mas.Length; i++)
{
    mas[i] = random.Next(1, 1000);
   // Console.Write(mas[i]+" ");
}
Console.WriteLine();
Stopwatch stopWatch1 = new Stopwatch();
stopWatch1.Start();
//mas = BubbleSort(mas);
//mas = ShakerSort(mas);
//mas = InsertionSort(mas);
//mas = StoogeSort(mas, 0, mas.Length - 1);
//mas = ShellSort(mas);
//mas = MergeSort(mas, 0, mas.Length - 1);
//mas = SelectionSort(mas);
//mas = QuickSort(mas, 0, mas.Length - 1);
//mas = GnomeSort(mas);
mas = TreeSort(mas);
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
void Merge(int[] array, int lowIndex, int middleIndex, int highIndex)
{
    var left = lowIndex;
    var right = middleIndex + 1;
    var tempArray = new int[highIndex - lowIndex + 1];
    var index = 0;

    while ((left <= middleIndex) && (right <= highIndex))
    {
        if (array[left] < array[right])
        {
            tempArray[index] = array[left];
            left++;
        }
        else
        {
            tempArray[index] = array[right];
            right++;
        }

        index++;
    }

    for (var i = left; i <= middleIndex; i++)
    {
        tempArray[index] = array[i];
        index++;
    }

    for (var i = right; i <= highIndex; i++)
    {
        tempArray[index] = array[i];
        index++;
    }

    for (var i = 0; i < tempArray.Length; i++)
    {
        array[lowIndex + i] = tempArray[i];
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
//сортировка выбором
int IndexOfMin(int[] array, int n)
{
    int result = n;
    for (var i = n; i < array.Length; ++i)
    {
        if (array[i] < array[result])
        {
            result = i;
        }
    }
    return result;
}
int[] SelectionSort(int[] array)
{
    int indx; 
    for (int i = 0; i < array.Length; i++) 
    {
        indx = i; 
        for (int j = i; j < array.Length; j++) 
        {
            if (array[j] < array[indx])
            {
                indx = j; 
            }
        }
        if (array[indx] == array[i]) 
            continue;
        int temp = array[i]; 
        array[i] = array[indx];
        array[indx] = temp;
    }
    return array;
}
//быстрая сортировка (сортировка Хоара)
int Partition(int[] array,int minIndex,int maxIndex)
{
    var pivot = minIndex - 1;
    for (int i = minIndex; i < maxIndex; i++)
    {
        if (array[i] < array[maxIndex])
        {
            pivot++;
            Swap(ref array[pivot], ref array[i]);
        }
    }
    pivot++;
    Swap(ref array[pivot], ref array[maxIndex]);
    return pivot;
}
int[] QuickSort(int[] array,int minIndex,int maxIndex)
{
    if (minIndex >= maxIndex) return array;
    var pivotIndex = Partition(array, minIndex, maxIndex);
    QuickSort(array, minIndex, pivotIndex - 1);
    QuickSort(array, pivotIndex + 1, maxIndex);
    return array;
}

//Гномья сортировка
int[] GnomeSort(int[] array)
{
    var index = 1;
    var nextIndex = index + 1;
    while (index < mas.Length)
    {
        if (array[index - 1] < array[index])
        {
            index = nextIndex;
            nextIndex++;
        }
        else
        {
            Swap(ref array[index - 1], ref array[index]);
            index--;
            if (index == 0)
            {
                index = nextIndex;
                nextIndex++;
            }
        }
    }
    return array;
}
//Сортировка бинарным деревом
int[] TreeSort(int[] array)
{
    var treeNode = new TreeNode(array[0]);
    for (int i = 1; i < array.Length; i++)
    {
        treeNode.Insert(new TreeNode(array[i]));
    }
    return treeNode.Transform();
}
public class TreeNode
{
    public int Data { get; set; }
    public TreeNode Left { get; set; }
    public TreeNode Right { get; set; }
    public TreeNode(int data)=>Data = data;
    public void Insert(TreeNode node)
    {
        if (node.Data < Data)
        {
            if (Left == null) Left = node;
            else Left.Insert(node);
        }
        else
        {
            if (Right == null) Right = node;
            else Right.Insert(node);
        }
    }
    public int[] Transform(List<int> elements=null)
    {
        if (elements == null) elements = new List<int>();
        if (Left != null) Left.Transform(elements);
        elements.Add(Data);
        if (Right != null) Right.Transform(elements);
        return elements.ToArray();
    }
}
