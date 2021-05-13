using System;
using BinaryTreeDataStructures;

namespace AVLTree
{
    public class AvlTreeNode<T> : Node<T> where T : IComparable<T>
    {
        public int BalanceFactor { get; set; }

        public AvlTreeNode()
        {
            
        }
    }
}