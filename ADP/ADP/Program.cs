using ADP.Datastructures.AVL_Tree;

namespace ADP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var avlTree = new AVLTree<int>();
            avlTree.Insert(50);
            avlTree.Insert(30);
            avlTree.Insert(70);
            avlTree.Insert(15);
            avlTree.Insert(45);
            avlTree.Insert(55);
            avlTree.Insert(85);
            avlTree.Remove(55);
            avlTree.Remove(70);
            avlTree.Remove(85);
        }
    }
}