using System;

namespace BinaryTreeDataStructures
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            BinarySearchTree<int> binarySearchTree = new BinarySearchTree<int>();
            binarySearchTree.Add(6);
            binarySearchTree.Add(4);
            binarySearchTree.Add(8);
            binarySearchTree.Add(3);
            binarySearchTree.Add(5);
            binarySearchTree.Add(7);
            binarySearchTree.Add(9);
            int a = binarySearchTree.Count;
            //bool ans = binarySearchTree.Contains(9);
           //binarySearchTree.Clear();
            string preOrder = binarySearchTree.PreOrder();
            int height = binarySearchTree.Height();
            Console.WriteLine("Hello");
        }
    }
}