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
    }
}
