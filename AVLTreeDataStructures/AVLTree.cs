using System;
using System.Collections.Generic;
using BinaryTreeDataStructures;

namespace AVLTreeDataStruct
{
    public class AVLTree<T>:BinarySearchTree<T> where T:IComparable<T>
    {
        public override void Add(T value)
        {
            Root = Place(value, Root);
            Count++;
        }

        protected override Node<T> Place(T value, Node<T> currentNode)
        {
            if (currentNode == null)
            {
                return new Node<T>(value);
            }
            
            if (value.CompareTo(currentNode.Data) < 0)
            {
                currentNode.Left = Place(value, currentNode.Left);
                currentNode = BalanceTree(currentNode);
            }
            else if (value.CompareTo(currentNode.Data) > 0)
            {
                currentNode.Right = Place(value, currentNode.Right);
                currentNode = BalanceTree(currentNode);
            }else
            {
                return currentNode;
            }

            return currentNode;
        }
        
        private Node<T> BalanceTree(Node<T> current)
        {
            int balanceFactor = Balance(current);
            //Heavy on the left side
            if (balanceFactor > 1)
            {
                current = Balance(current.Left) > 0 ? RotateLL(current) : RotateLR(current);
            }
            //Heavy on the right side
            else if (balanceFactor < -1)
            {
                current = Balance(current.Right) > 0 ? RotateRL(current) : RotateRR(current);
            }
            return current;
        }
        
        private Node<T> RotateRR(Node<T> parent)
        {
            Node<T> pivot = parent.Right;
            parent.Right = pivot.Left;
            pivot.Left = parent;
            return pivot;
        }
        private Node<T> RotateLL(Node<T> parent)
        {
            Node<T> pivot = parent.Left;
            parent.Left = pivot.Right;
            pivot.Right = parent;
            return pivot;
        }
        private Node<T> RotateLR(Node<T> parent)
        {
            Node<T> pivot = parent.Left;
            parent.Left = RotateRR(pivot);
            return RotateLL(parent);
        }
        private Node<T> RotateRL(Node<T> parent)
        {
            Node<T> pivot = parent.Right;
            parent.Right = RotateLL(pivot);
            return RotateRR(parent);
        }

        
        private int Balance(Node<T> root)
        {
            int balanceFactor = HeightRecursive(root.Left) - HeightRecursive(root.Right);
            return balanceFactor;
        }

        public T[] ToArray()
        {
            List<T> tempList = new List<T>();
            Queue<Node<T>> queue = new Queue<Node<T>>();
            queue.Enqueue(Root);
            while (queue.Count != 0)
            {
                var temp = queue.Dequeue();
                tempList.Add(temp.Data);

                if (temp.Left != null)
                    queue.Enqueue(temp.Left);
                
                if (temp.Right != null)
                    queue.Enqueue(temp.Right);
            }
            
            return tempList.ToArray();
        }

    }
}