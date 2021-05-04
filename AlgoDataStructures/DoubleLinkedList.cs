using System;
using System.Collections.Generic;

namespace AlgoDataStructures
{
    public class DoubleLinkedList<T>
    {
        public DNode<T> Head { get; set; }
        public DNode<T> Tail { get; set; }
        
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
            DNode<T> node = new DNode<T>(val);
            if (Head != null)
            {
                if (Head.Next == null)
                {
                    Head.Next = node;
                    node.Prev = Head;
                }
                else
                {
                    Tail.Next = node;
                    node.Prev = Tail;
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
                DNode<T> currentNode = Head;
                DNode<T> nodeToPlaceAt = new DNode<T>(val);

                int i = 0;
                while (currentNode.Next != null && i != index)
                {
                    i++;
                    currentNode = currentNode.Next;
                }

                var previous = currentNode.Prev;
                previous.Next = nodeToPlaceAt;
                nodeToPlaceAt.Next = currentNode;
                currentNode.Prev = nodeToPlaceAt;

                Count++;
            }
        }
        
        public DNode<T> Get(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException("Index out of bounds");
            }
            else
            {
                DNode<T> currentNode = Head;
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
                DNode<T> currentNode = Head;
                int i = 0;
                while (currentNode.Next != null && i != index - 1)
                {
                    i++;
                    currentNode = currentNode.Next;
                }

                DNode<T> nodeToDelete = currentNode.Next;

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
        
            DNode<T> newTail = Get(Count - 2);
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
                DNode<T> currentNode = Head;
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
            DNode<T> currentNode = Head;
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