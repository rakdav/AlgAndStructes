using System.Diagnostics;

Console.Write("Введите число:");
long x = long.Parse(Console.ReadLine()!);
Console.Write("Введите степень:");
int n = int.Parse(Console.ReadLine()!);
Stopwatch stopWatch1 = new Stopwatch();
stopWatch1.Start();
Console.WriteLine($"Рекурсивная реализация:{PowerRec(x,n)}");
stopWatch1.Stop();
Console.WriteLine("Время работы алгоритма:" + stopWatch1.ElapsedTicks.ToString());
stopWatch1 = new Stopwatch();
stopWatch1.Start();
Console.WriteLine($"Итерационная реализация:{PowerIter(x, n)}");
Console.WriteLine("Время работы алгоритма:" + stopWatch1.ElapsedTicks.ToString());
//Рекурсивная реализация быстрого возведения в степень
long PowerRec(long x,int n)
{
    if (n == 0) return 1;
    if (n % 2 == 0)
    {
        var p = PowerRec(x, n / 2);
        return p * p;
    }
    else return x * PowerRec(x, n - 1);
}
//Итерационная реализация
long PowerIter(long x, int n)
{
    var res = 1L;
    while (n > 0)
    {
        if ((n & 1) == 0)
        {
            x *= x;
            n >>= 1;
        }
        else
        {
            res*= x;
            --n;
        }
    }
    return res;
}
