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
        public BinaryTreeNode<T> Left
        {
            get { return (BinaryTreeNode<T>)Children[0]; }
            set { Children[0] = value; }
        }
        public BinaryTreeNode<T> Right
        {
            get { return (BinaryTreeNode<T>)Children[1]; }
            set { Children[1] = value; }
        }
        public int GetHeight()
        {
            int height = 1;
            BinaryTreeNode<T> current = this;
            while (current.Parent != null)
            {
                height++;
                current = current.Parent;
            }
            return height;
        }
    }
    public class TreeNode<T>
    {
        public T Data { get; set; }
        public List<TreeNode<T>>? Children { get; set; }
    }
}
