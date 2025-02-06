Tree<int> tree = new Tree<int>();
tree.Root = new TreeNode<int>() { Data = 100 };
tree.Root.Children = new List<TreeNode<int>>
{
    new TreeNode<int>{Data=50,Parent=tree.Root},
    new TreeNode<int>{Data=1,Parent=tree.Root},
    new TreeNode<int>{Data=150,Parent=tree.Root}
};
tree.Root.Children[2].Children = new List<TreeNode<int>>
{
    new TreeNode<int>{Data=30,Parent=tree.Root.Children[2]}
};
Tree<Person> company = new Tree<Person>();
company.Root = new TreeNode<Person>()
{
    Data = new Person(100, "Маша с кухни", "Кулинар"),
    Parent=null!
};
company.Root.Children = new List<TreeNode<Person>>()
{
    new TreeNode<Person>()
    {
        Data=new Person(1,"Арина","SuperWoman"),
        Parent=company.Root
    },
    new TreeNode<Person>()
    {
        Data=new Person(10,"Сорока","Коллекционер пугатель"),
        Parent=company.Root
    },
     new TreeNode<Person>()
    {
        Data=new Person(20,"Хомячков","Сосед сороки"),
        Parent=company.Root
    }
};
company.Root.Children[2].Children = new List<TreeNode<Person>>()
{
    new TreeNode<Person>()
    {
        Data=new Person(10,"Хомячков сын","Куликов"),
        Parent=company.Root.Children[2]
    }
};
class TreeNode<T>
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
class Tree<T>
{
    public TreeNode<T> Root { get; set; }
}
class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Role { get; set; }
    public Person()
    {
    }
    public Person(int id, string name, string role)
    {
        Id = id;
        Name = name;
        Role = role;
    }
}
