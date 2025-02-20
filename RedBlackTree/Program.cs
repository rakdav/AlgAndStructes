using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeLib;

namespace RedBlackTree
{
    class Program
    {
        static void Main(string[] args)
        {
            RedBlackTreeList<int> tree = new RedBlackTreeList<int>();
            for (int i = 0; i < 10; i++) tree.Add(i);
            tree.Remove(9);
            Console.WriteLine(tree.ContainsKey(5));
            Console.WriteLine(tree.Count);
            tree.Greatest(out int greatest);
            tree.Least(out int least);
            Console.WriteLine($"{tree.Count} elements in the range {least}-{greatest}");
            Console.WriteLine("Values: " + string.Join(", ", tree.GetEnumerable()));

            Console.Write("Values: ");
            foreach (EntryList<int> node in tree)
            {
                Console.Write(node + " ");
            }
        }
    }
}
