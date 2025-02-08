using BinaryTree;
using static System.Runtime.InteropServices.JavaScript.JSType;

BinaryTree<QuizItem> GetTree()
{
    BinaryTree<QuizItem> tree = new BinaryTree<QuizItem>();
    tree.Root = new BinaryTreeNode<QuizItem>()
    {
        Data = new QuizItem("Do you have experience in developing applications ? "),
        Children = new List<TreeNode<QuizItem>>()
       {
           new BinaryTreeNode<QuizItem>()
           {
               Data = new QuizItem("Have you worked as a developer for more than 5 years?"),
               Children = new List<TreeNode<QuizItem>>()
               {
                   new BinaryTreeNode<QuizItem>()
                   {
                      Data=new QuizItem("Apply as a senior developer!")
                   },
                   new BinaryTreeNode<QuizItem>()
                   {
                      Data=new QuizItem("Apply as a middle developer!")
                   }
               },
           },
           new BinaryTreeNode<QuizItem>()
           {
               Data=new QuizItem("Have you completed the university?"),
               Children=new List<TreeNode<QuizItem>>()
               {
                   new BinaryTreeNode<QuizItem>()
                   {
                       Data = new QuizItem("Apply for a junior developer!")
                   },
                   new BinaryTreeNode<QuizItem>()
                   {
                       Data = new QuizItem("Will you find some time during the semester?"),
                       Children=new List<TreeNode<QuizItem>>()
                       {
                           new BinaryTreeNode<QuizItem>()
                            {
                            Data = new QuizItem("Apply for our long-time internship program!")
                            },
                            new BinaryTreeNode<QuizItem>()
                            {
                            Data = new QuizItem("Apply for summer internship program!")
                            }
                       }
                   }
               }
           }
       }
    };
    return tree;
}
//BinaryTree<QuizItem> tree=
class QuizItem
{
    public string Text { get; set; }
    public QuizItem(string text)=>Text = text;
}
