using System;
using System.Collections.Generic;
using System.Net;

namespace Priority_Queue
{
    public class MaxHeapPriorityQueue<T> where T:IComparable<T>
    {
        public Node<T> Root { get; set; }
        
        public int Count { get; set; }

        private List<Node<T>> array = new List<Node<T>>();

        public void Add(T data)
        {
            Root = InsertRecursive(Root, data);
        }

        private Node<T> InsertRecursive(Node<T> node, T data, Node<T> parent = null)
        {
            if (node == null)
            {
                Count++;
                var n = new Node<T>(data, parent);
                array.Add(n);
                return Heapify(n, data);
            }
            
            if (node.Left == null)
            {
                node.Left = InsertRecursive(node.Left,data, node);
            }else if (node.Right == null)
            {
                node.Right = InsertRecursive(node.Right, data, node);
            }else
            {
                node.Left = InsertRecursive(node.Left, data, node.Left);
            }

            return node;
        }

        private Node<T> Heapify(Node<T> node, T data)
        {
            if (node.Parent != null)
            {
                if (data.CompareTo(node.Parent.Data) > 0)
                {
                    node.Data = node.Parent.Data;
                    node.Parent.Data = data;
                    node.Parent = Heapify(node.Parent, data);
                }
            }

            return node;
        }

        public Node<T> Peek()
        {
            return Root;
        }

        public Node<T> Remove()
        {

            return null;
        }
    }
}