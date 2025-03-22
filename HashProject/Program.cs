//Хэш — это какая-то функция, сопоставляющая объектам какого-то множества числовые значения из ограниченного промежутка.

//«Хорошая» хэш-функция:
//    1. Быстро считается — за линейное от размера объекта время;
//    2. Имеет не очень большие значения — влезающие в 64 бита;
//    3. «Детерминированно-случайная» — если хэш может принимать n
//различных значений, то вероятность того, что хэши от двух случайных объектов совпадут, равна примерно 1/n.

//Обычно хэш-функция не является взаимно однозначной: одному хэшу может соответствовать много объектов. Такие функции называют сюръективными.

using System.Security.Cryptography;
using System.Text;

double x = 8.6;
Console.WriteLine(x.GetHashCode());

Console.Write("Введите фразу:");
string line = Console.ReadLine()!;
Console.WriteLine(HashCode(line));
Console.WriteLine(GetHash(line));
Console.WriteLine(CreateSHA256(line));
string GetHash(string str)
{
    MD5 md5 = MD5.Create();
    var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
    return Convert.ToBase64String(hash);
}

string CreateSHA256(string str)
{
    using SHA256 hash = SHA256.Create();
    return Convert.ToHexString(hash.ComputeHash(Encoding.ASCII.GetBytes(str)));
}

long HashCode(string str)
{
    const int k = 31, mod = (int)1e9+7;
    long h = 0;
    foreach(char c in str)
    {
        int x = (int)(c - 'a' + 1);
        h = (h * k + x) % mod;
    }
    return h;
}