public class TreeNode<T>
{
    public T Data { get; set; }
    public TreeNode<T> Parent { get; set; }
    public List<TreeNode<T>> Children { get; set; }
    public int GetHeight()
    {
        int height = 1;
        TreeNode<T> current = this;
        while (current.Parent != null)
        {
            height++;
            current = current.Parent;
        }
        return height;
    }
}
class BinaryTreeNode<T> : TreeNode<T>
{
    public BinaryTreeNode() => Children = new List<TreeNode<T>>() { null!, null! };
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
}
enum TraverselEnum
{
    PREODER,
    INORDER,
    POSTORDER
}
class BinaryTree<T>
{
    public BinaryTreeNode<T> Root { get; set; }
    public int Count { get; set; }
    private void TraversePreOrder(BinaryTreeNode<T> node,
        List<BinaryTreeNode<T>> result)
    {
        if (node != null)
        {
            result.Add(node);
            TraversePreOrder(node.Left, result);
            TraversePreOrder(node.Right, result);
        }
    }
    private void TraverseInOrder(BinaryTreeNode<T> node,
        List<BinaryTreeNode<T>> result)
    {
        if (node != null)
        {
            TraverseInOrder(node.Left, result);
            result.Add(node);
            TraverseInOrder(node.Right, result);
        }
    }
    private void TraversePostOrder(BinaryTreeNode<T> node,
        List<BinaryTreeNode<T>> result)
    {
        if (node != null)
        {
            TraversePostOrder(node.Left, result);
            TraversePostOrder(node.Right, result);
            result.Add(node);
        }
    }
    public List<BinaryTreeNode<T>> Traverse(TraverselEnum mode)
    {
        List<BinaryTreeNode<T>> nodes = new List<BinaryTreeNode<T>>();
        switch(mode)
        {
            case TraverselEnum.PREODER:
                TraversePreOrder(Root, nodes);
                break;
            case TraverselEnum.INORDER:
                TraverseInOrder(Root, nodes);
                break;
            case TraverselEnum.POSTORDER:
                TraversePostOrder(Root, nodes);
                break;
        }
        return nodes;
    }
    public int GetHeight()
    {
        int height = 0;
        foreach(BinaryTreeNode<T> node in Traverse(TraverselEnum.PREODER))
        {
            height = Math.Max(height, node.GetHeight());
        }
        return height;
    }
}
