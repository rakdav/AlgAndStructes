using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphsProject
{
    public class Node<T>
    {
        public int Index { get; set; }
        public T Data { get; set; }
        public List<Node<T>> Neighbors { get; set; } = new();
        public List<int> Weights { get; set; } = new();
        public override string? ToString()
        {
            return $"Узел с индексом {Index+1}:{Data}," +
                $" соседей:{Neighbors.Count}";
        }
    }
}
