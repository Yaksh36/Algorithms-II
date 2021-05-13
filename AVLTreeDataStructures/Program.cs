using System;
using AVLTreeDataStruct;

namespace AVLTree
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            AVLTree<int> tree = new AVLTree<int>();
            tree.Add(24);
            tree.Add(10);
            tree.Add(11);
            tree.Add(56);
            tree.Add(13);
            var ar = tree.ToArray();
            Console.WriteLine(tree.ToArray());
        }
    }
}