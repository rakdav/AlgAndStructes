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
            UpdateIndeces();
            return node;
        }
        public void RemoveNode(Node<T> nodeToRemove)
        {
            Nodes.Remove(nodeToRemove);
            UpdateIndeces();
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
        public List<Edge<T>> GetEdges()
        {
            List<Edge<T>> edges = new List<Edge<T>>();
            foreach(Node<T> from in Nodes)
            {
                for(int i=0;i<from.Neightbors.Count;i++)
                {
                    Edge<T> edge = new Edge<T>()
                    {
                        From = from,
                        To = from.Neightbors[i],
                        Weight = i < from.Weights.Count ? from.Weights[i] : 0
                    };
                    edges.Add(edge);
                }
            }
            return edges;
        }
        private void UpdateIndeces()
        {
            int i = 0;
            Nodes.ForEach(n => n.Index = i++);
        }
        public List<Node<T>> DFS()
        {
            bool[] isVisited = new bool[Nodes.Count];
            List<Node<T>> result = new List<Node<T>>();
            DFS(isVisited, Nodes[0], result);
            return result;
        }
        private void DFS(bool[] isVisited,Node<T> node,List<Node<T>> result)
        {
            result.Add(node);
            isVisited[node.Index] = true;
            foreach(Node<T> neighbor in node.Neightbors)
            {
                if (!isVisited[neighbor.Index]) DFS(isVisited,neighbor,result);
            }
        }
        public List<Node<T>> BFS()
        {
            return BFS(Nodes[0]);
        }
        private List<Node<T>> BFS(Node<T> node)
        {
            bool[] isVisited = new bool[Nodes.Count];
            isVisited[node.Index] = true;
            List<Node<T>> result = new List<Node<T>>();
            Queue<Node<T>> queue = new Queue<Node<T>>();
            queue.Enqueue(node);
            while (queue.Count > 0)
            {
                Node<T> next = queue.Dequeue();
                result.Add(next);
                foreach(Node<T> neightbor in next.Neightbors)
                {
                    isVisited[neightbor.Index] = true;
                    queue.Enqueue(neightbor);
                }
            }
            return result;
        }
    }
}
