using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    public class BinaryTreeNode<T>:TreeNode<T>
    {
        public BinaryTreeNode() => Children = new List<TreeNode<T>>() { null!, null! };
        public BinaryTreeNode<T> Parent { get; set; }
    }
    public class TreeNode<T>
    {
        public T Data { get; set; }
        public List<TreeNode<T>>? Children { get; set; }
    }
}
