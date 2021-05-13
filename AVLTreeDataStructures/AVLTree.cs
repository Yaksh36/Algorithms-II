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
            }
            else if (value.CompareTo(currentNode.Data) > 0)
            {
                currentNode.Right = Place(value, currentNode.Right);
            }else
            {
                return currentNode;
            }
            
            int balance = Balance(currentNode);
            int height = HeightRecursive(currentNode);

            //L
            if (balance > 1 && value.CompareTo(currentNode.Left.Data) < 0)
            {
                return RightRotation(currentNode);
            }

            //R
            if (balance < -1 && value.CompareTo(currentNode.Right.Data) > 0)
            {
                return LeftRotation(currentNode);
            }
            
            //LR
            if (balance > 1 && value.CompareTo(currentNode.Left.Data) > 0)
            {
                return LeftRotationRight(currentNode);
            }
            
            //RL
            if (balance < -1 && value.CompareTo(currentNode.Right.Data) < 0)
            {
                return RightRotationLeft(currentNode);
            }

            return currentNode;
        }

        private Node<T> RightRotation(Node<T> parent)
        {
            //11
            Node<T> pivot = parent.Left;
            //null
            Node<T> temp = parent.Right;
            

            pivot.Right = parent;
            parent.Left = temp;
            return pivot;
        }
        
        private Node<T> LeftRotation(Node<T> parent)
        {
            //11
            Node<T> pivot = parent.Right;
            //null
            Node<T> temp = parent.Left;
            
            pivot.Left = parent;
            parent.Right = temp;
            return pivot;
        }
        
        private Node<T> LeftRotationRight(Node<T> parent)
        {
            Node<T> pivot = parent.Left;
            parent.Left = RightRotation(pivot);
            return LeftRotation(parent);
        }
        
        private Node<T> RightRotationLeft(Node<T> parent)
        {
            Node<T> pivot = parent.Right;
            parent.Right = LeftRotation(pivot);
            return RightRotation(parent);
        }
        
        private int Balance(Node<T> root)
        {
            int balanceFactor = HeightRecursive(root.Left) - HeightRecursive(root.Right);
            //Console.WriteLine("Balance Factor:" + balanceFactor);
            return balanceFactor;
        }

        public T[] ToArray()
        {
            List<T> tempList = new List<T>();
            TraverseLevelOrder(Root,tempList);
            return tempList.ToArray();
        }
        
        protected void TraverseLevelOrder(Node<T> currentNode, List<T> list)
        {
            if (currentNode != null)
            {
                list.Add(currentNode.Data);
                TraverseInOrder(currentNode.Left,list);
                TraverseInOrder(currentNode.Right,list);
            }
        }

    }
}