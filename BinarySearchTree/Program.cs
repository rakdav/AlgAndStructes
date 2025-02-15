using BinarySearchTree;
const int COLUMN_WIDTH = 5;
void VisualizationTree(BinarySearchTree<int> tree,string caption)
{
    Console.WriteLine(tree.Count);
    char[][] console = InitializeVisualization(tree, out int width);
    VisualizationNode(tree.Root, 0, width / 2, console, width);
    Console.WriteLine(caption);
    foreach (char[] row in console)
    {
        Console.WriteLine(row);
    }
}
char[][] InitializeVisualization(BinarySearchTree<int> tree,out int width)
{
    int height = tree.GetHeight();
    width = (int)Math.Pow(2, height) - 1;
    char[][] console = new char[height * 2][];
    for (int i = 0; i < height*2; i++)
    {
        console[i] = new char[COLUMN_WIDTH * 2];
    }
    return console;
}
void VisualizationNode(BinaryTreeNode<int> node, int row,int column, char[][] console, int width)
{
    if (node != null)
    {
        char[] chars = node.Data.ToString().ToCharArray();
        int margin = (COLUMN_WIDTH - chars.Length) / 2;
        for (int i = 0; i < chars.Length; i++)
        {
            console[row][COLUMN_WIDTH * column + margin] = chars[i];
        }
        int columnData = (width + 1) / (int)Math.Pow(2, node.GetHeight() + 1);
        VisualizationNode(node.Left, row + 2, column - columnData, console, width);
        VisualizationNode(node.Right, row + 2, column + columnData, console, width);
        DrawLineLeft(node, row, column,console, columnData);
        DrawLineRight(node, row, column, console, columnData);
    }
}
void DrawLineRight(BinaryTreeNode<int> node,int row,int column, char[][] console,
    int columnDelta)
{
    if (node.Right != null)
    {
        int startColumnIndex = COLUMN_WIDTH * column + 2;
        int endColumnIndex = COLUMN_WIDTH * (column + columnDelta) + 2;
        for(int x = startColumnIndex + 1; x < endColumnIndex; x++)
        {
            console[row + 1][x] = '-';
        }
        console[row + 1][startColumnIndex] = '+';
        console[row][endColumnIndex] = '\u2510';
    }
}

void DrawLineLeft(BinaryTreeNode<int> node, int row, int column, char[][] console,
    int columnDelta)
{
    if (node.Left != null)
    {
        int startColumnIndex = COLUMN_WIDTH * (column-columnDelta) + 2;
        int endColumnIndex = COLUMN_WIDTH * column+ 2;
        for (int x = startColumnIndex + 1; x < endColumnIndex; x++)
        {
            console[row + 1][x] = '-';
        }
        console[row + 1][startColumnIndex] = '\u250c';
        console[row][endColumnIndex] = '+';
    }
}
Console.OutputEncoding = System.Text.Encoding.UTF8;
BinarySearchTree<int> tree = new BinarySearchTree<int>();
tree.Root = new BinaryTreeNode<int>() { Data = 100 };
tree.Root.Left = new BinaryTreeNode<int>()
{ Data = 50, Parent = tree.Root };
tree.Root.Right = new BinaryTreeNode<int>()
{ Data = 150, Parent = tree.Root };
tree.Count = 3;


