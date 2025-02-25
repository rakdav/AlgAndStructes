using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphsProject
{
    public class Graph<T>
    {
        private bool _isDirected = false;
        private bool _isWeighted = false;
        public List<Node<T>> Nodes { get; set; } = new();
        public Graph(bool isDirected, bool isWeighted)
        {
            _isDirected = isDirected;
            _isWeighted = isWeighted;
        }
        public Edge<T> this[int from,int to]
        {
            get
            {
                Node<T> nodeFrom = Nodes[from];
                Node<T> nodeTo = Nodes[to];
                int i = nodeFrom.Neightbors.IndexOf(nodeTo);
                if (i > 0)
                {
                    Edge<T> edge = new Edge<T>()
                    {
                        From=nodeFrom,
                        To=nodeTo,
                        Weight=i<nodeFrom.Weights.Count?
                        nodeFrom.Weights[i]:0
                    };
                    return edge;
                }
                return null;
            }
        }
        public Node<T> AddNode(T value)
        {
            Node<T> node = new Node<T> { Data = value };
            Nodes.Add(node);
            //UpdateIndeces();
            return node;
        }
        public void RemoveNode(Node<T> nodeToRemove)
        {
            Nodes.Remove(nodeToRemove);
            //UpdateIndeces();
            foreach(Node<T> node in Nodes)
            {
                RemoveEdge(node, nodeToRemove);
            }
        }
        public void AddEdge(Node<T> from,Node<T> to,int weight=0)
        {
            from.Neightbors.Add(to);
            if (_isWeighted) from.Weights.Add(weight);
            if (!_isDirected)
            {
                to.Neightbors.Add(from);
                if (_isWeighted) to.Weights.Add(weight);
            }
        }
        public void RemoveEdge(Node<T> from,Node<T> to)
        {
            int index = from.Neightbors.FindIndex(n => n == to);
            if (index > 0)
            {
                from.Neightbors.RemoveAt(index);
                if (_isWeighted) to.Weights.RemoveAt(index);
            }
        }
    }
}
