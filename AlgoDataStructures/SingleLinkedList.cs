using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoDataStructures
{
    public class SingleLinkedList<T>
    {
        public Node<T> Head { get; set; }
        public Node<T> Tail { get; set; }

        private int count;

        public int Count
        {
            get
            {
                return count;
            }
            set
            {
                count = value;
            }
        }

        public void Add(T val)
        {
            //Add the node to the tail
            Node<T> node = new Node<T>(val);
            if (Head != null)
            {
                if (Head.Next == null)
                {
                    Head.Next = node;
                }
                else
                {
                    Tail.Next = node;
                }
            }
            else
            {
                Head = node;
            }

            //Update the tail node to the new node.
            Tail = node;
            Count++;
        }

        // A C D
        public void Insert(T val, int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException("Index out of bounds");
            }
            else
            {
                Node<T> currentNode = Head;
                Node<T> nodeToPlaceAt = new Node<T>(val);

                int i = 0;
                while (currentNode.Next != null && i != index - 1)
                {
                    i++;
                    currentNode = currentNode.Next;
                }

                var temp = currentNode.Next;
                currentNode.Next = nodeToPlaceAt;
                nodeToPlaceAt.Next = temp;

                Count++;
            }
        }
        
        public Node<T> Get(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException("Index out of bounds");
            }
            else
            {
                Node<T> currentNode = Head;
                int i = 0;
                while (currentNode.Next != null && i != index)
                {
                    i++;
                    currentNode = currentNode.Next;
                }

                return currentNode;
            }
        }

        public T Remove()
        {
            Head = Head.Next;
            Count--;

            return Head.Data;
        }

        public T RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException("Index out of bounds");
            }
            else
            {
                Node<T> currentNode = Head;
                int i = 0;
                while (currentNode.Next != null && i != index - 1)
                {
                    i++;
                    currentNode = currentNode.Next;
                }

                Node<T> nodeToDelete = currentNode.Next;

                if (nodeToDelete != null)
                {
                    currentNode.Next = nodeToDelete.Next;
                }
                else
                {
                    currentNode.Next = null;
                }

                Count--;

                return currentNode.Next.Data;
            }
        }

        public T RemoveLast()
        {
        
            Node<T> newTail = Get(Count - 2);
            newTail.Next = null;
            
            Tail = newTail; 
            return Tail.Data;
        }

        public override string ToString()
        {
            if (Count == 0)
            {
                return "";
            }
            else
            {
                var tempArr = new List<T>();
                Node<T> currentNode = Head;
                while (currentNode != null)
                {
                    tempArr.Add(currentNode.Data);
                    currentNode = currentNode.Next;
                }

                return string.Join(", ", tempArr);
            }
        }

        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public int Search(T val)
        {
            int index = 0;
            Node<T> currentNode = Head;
            while (currentNode != null)
            {
                if (val.Equals(currentNode.Data))
                {
                    return index;
                }
                currentNode = currentNode.Next;
                index++;
            }

            return -1;
        }
    }
}