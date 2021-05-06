using System;

namespace BinaryTreeDataStructures
{
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        public Node<T> Root { get; set; }

        private int count;
        public int Count
        {
            get => count;
            private set => count = value;
        }

        public void Add(T value)
        {
            Root = Place(value, Root);
            Count++;
        }

        public bool Contains(T value)
        {
            return Find(value, Root);
        }

        public void Remove(T value)
        {
            Root = RemoveRecursive(value, Root);
        }

        private Node<T> RemoveRecursive(T value, Node<T> currentNode)
        {
            if (currentNode == null)
            {
                return null;
            }

            if (currentNode.Data.CompareTo(value) == 0)
            {
                //Delete logic
                if (currentNode.Right == null)
                {
                    Count--;
                    return currentNode.Left;
                }

                if (currentNode.Left == null)
                {
                    Count--;
                    return currentNode.Right;
                }

                if (currentNode.Left != null && currentNode.Right != null)
                {
                    Count--;
                    T smallestValue = FindSmallestValue(currentNode.Right); 
                    currentNode.Data = smallestValue;
                    currentNode.Right = RemoveRecursive(smallestValue, currentNode.Right);
                    return currentNode;
                }
            }

            if (value.CompareTo(currentNode.Data) < 0)
            {
                currentNode.Left = RemoveRecursive(value, currentNode.Left);
                return currentNode;
            }

            currentNode.Right = RemoveRecursive(value, currentNode.Right);
            return currentNode;
        }

        private T FindSmallestValue(Node<T> root)
        {
            return root.Left == null ? root.Data : FindSmallestValue(root.Left);
        }

        private bool Find(T value, Node<T> currentNode)
        {
            if (currentNode == null)
            {
                return false;
            }

            if (value.CompareTo(currentNode.Data) == 0)
            {
                return true;
            }

            return value.CompareTo(currentNode.Data) < 0
                ? Find(value, currentNode.Left)
                : Find(value, currentNode.Right);
        }
        
        private Node<T> Place(T value, Node<T> currentNode)
        {

            if (currentNode == null)
            {
                return new Node<T>(value);
            }
            
            if (value.CompareTo(currentNode.Data) < 0)
            {
                currentNode.Left = Place(value, currentNode.Left);
            }
            else if (value.CompareTo(currentNode.Data) > 0)
            {
                currentNode.Right = Place(value, currentNode.Right);
            }else
            {
                return currentNode;
            }

            return currentNode;
        }
        
    }
}