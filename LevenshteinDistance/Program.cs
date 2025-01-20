Console.Write("Введите первое слово:");
string first = Console.ReadLine()!;
Console.Write("Введите второе слово:");
string second = Console.ReadLine()!;
Console.WriteLine("Расстояние Левинштейна:"+LevenshteinDistance(first,second));
Console.WriteLine("Расстояние Левинштейна:" + LevenshteinDistanceRec(first,first.Length, second,second.Length));
Console.WriteLine("Расстояние Даверау-Левинштейна:" + DamerauLevenshteinDistance(first, second));

//Расстояние Левенштейна
int Minimum(int a, int b, int c) => (a = a < b ? a : b) < c ? a : c;
int Minim(int a, int b) => a < b ? a : b;

//Итеративная реализация
int LevenshteinDistance(string first,string second)
{
    var n = first.Length + 1;
    var m = second.Length + 1;
    var matrxix = new int[n, m];
    const int deletionCast = 1;
    const int insertionCost = 1;
    for (int i = 0; i < n; i++)
    {
        matrxix[i, 0] = i;
    }
    for (int j = 0; j < m; j++)
    {
        matrxix[0,j] = j;
    }
    for(var i = 1; i < n; i++)
    {
        for (int j = 1; j < m; j++)
        {
            var substitutionCost = first[i - 1] == second[j - 1] ? 0 : 1;
            matrxix[i, j] = Minimum(matrxix[i - 1, j] + deletionCast,
                matrxix[i, j - 1] + insertionCost,
                matrxix[i - 1, j - 1] + substitutionCost);
        }
    }
    return matrxix[n - 1, m - 1];
}

int DamerauLevenshteinDistance(string first, string second)
{
    var n = first.Length + 1;
    var m = second.Length + 1;
    var matrxix = new int[n, m];
    const int deletionCast = 1;
    const int insertionCost = 1;
    for (int i = 0; i < n; i++) matrxix[i, 0] = i;
    for (int j = 0; j < m; j++) matrxix[0, j] = j;
    for (var i = 1; i < n; i++)
    {
        for (int j = 1; j < m; j++)
        {
            var substitutionCost = first[i - 1] == second[j - 1] ? 0 : 1;
            matrxix[i, j] = Minimum(matrxix[i - 1, j] + deletionCast,
                matrxix[i, j - 1] + insertionCost,
                matrxix[i - 1, j - 1] + substitutionCost);

            if (i > 1 && j > 1 && first[i - 1] == second[j - 2] && first[i - 2] == second[j - 1])
            {
                matrxix[i, j] = Minim(matrxix[i, j], matrxix[i - 2, j - 2] + substitutionCost);
            }
        }
    }
    return matrxix[n - 1, m - 1];
}
//Рекурсивная реализация
int LevenshteinDistanceRec(string first,int len1, string second, int len2)
{
    if (len1 == 0) return len2;
    if (len2 == 0) return len1;
    var substitutionCost = 0;
    if (first[len1 - 1] != second[len2 - 1]) substitutionCost = 1;
    var deletion = LevenshteinDistanceRec(first, len1 - 1, second, len2) + 1;
    var insertion = LevenshteinDistanceRec(first, len1, second, len2-1) + 1;
    var substitution = LevenshteinDistanceRec(first, len1 - 1, second, len2-1) + substitutionCost;
    return Minimum(deletion, insertion, substitution);
}