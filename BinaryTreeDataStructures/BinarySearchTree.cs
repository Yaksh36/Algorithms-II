using System;
using System.Collections.Generic;
using System.Text;

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

        public void Clear()
        {
            Root = null;
            Count = 0;
        }

        public String InOrder()
        {
            var tempArr = new List<T>();
            TraverseInOrder(Root,tempArr);
            return String.Join(", " , tempArr);
        }

        private void TraverseInOrder(Node<T> currentNode, List<T> list)
        {
            if (currentNode != null)
            {
                TraverseInOrder(currentNode.Left,list);
                list.Add(currentNode.Data);
                TraverseInOrder(currentNode.Right,list);
            }
        }
        
        public String PostOrder()
        {
            var tempArr = new List<T>();
            TraversePostOrder(Root,tempArr);
            return String.Join(", " , tempArr);
        }

        private void TraversePostOrder(Node<T> currentNode, List<T> list)
        {
            if (currentNode != null)
            {
                TraversePostOrder(currentNode.Left,list);
                TraversePostOrder(currentNode.Right,list);
                list.Add(currentNode.Data);
            }
        }

        public String PreOrder()
        {
            var tempArr = new List<T>();
            TraversePreOrder(Root,tempArr);
            return String.Join(", " , tempArr);
        }

        private void TraversePreOrder(Node<T> currentNode, List<T> list)
        {
            if (currentNode != null)
            {
                list.Add(currentNode.Data);
                TraversePreOrder(currentNode.Left, list);
                TraversePreOrder(currentNode.Right, list);
            }
        }

        public int Height()
        {
            return HeightRecursive(Root);
        }

        private int HeightRecursive(Node<T> root)
        {
            if (root == null)
            {
                return -1;
            }

            int leftTreeHeight = HeightRecursive(root.Left);
            int rightTreeHeight = HeightRecursive(root.Right);

            return Math.Max(leftTreeHeight, rightTreeHeight) + 1;
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