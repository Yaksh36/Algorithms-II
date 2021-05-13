using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Management.Instrumentation;
using System.Net;
using System.Threading;

namespace Playground
{
     class Program
    {
        public static void Main(string[] args)
        {
            
            SingleLinkedList<int> test = new SingleLinkedList<int>();
            test.add(10);
            test.add(49);
            //test.add(69);
            //test.insert(0, 32);
            //est.remove();
            // test.removeLast();
            // test.removeAt(2);
            // test.clear();
            string str = test.ToString();
            Console.WriteLine(str);
            //Console.WriteLine(test.search(10));
            //Console.WriteLine(test.count);
            //Console.WriteLine(test.get(0));
            //Console.WriteLine(test.get(1));
            //Console.WriteLine(test.get(2));



        }
    }

    public class Node<T> where T : IComparable
    {
        public Node<T> next;
        public T data;

        public Node(T data, Node<T> next=null){
            this.data = data;
            this.next = next;
        }

        public Node()
        {
            
        }
        
    }

    public class doubleNode<T> where T : IComparable
    {
        public doubleNode<T> next;
        public doubleNode<T> prev;
        public T data;
    }

    public class SingleLinkedList<T> where T : IComparable
    {
        public Node<T> head = null;
        public Node<T> tail = null;
        public int count { get; set; } = 0;

        
        public override string ToString()
        {
            string result = "";
            Node<T> current = head;
            List<T> output = new List<T>();
            if (current == null)
            {
                return "";
            }
            while (current != null)
            {
                output.Add(current.data);
                current = current.next;
                
            }


            return String.Join(", ", output);
        }

        public void removeLast()
        {
            Node<T> previous = head;
            Node<T> temp = head.next;
            Node<T> tail = this.tail;
            count--;
            if (head.next != null)
            {
                return;
            }

            while (temp.next != null)
            {
                previous = previous.next;
            }

            previous.next = null;
            temp = null;
            tail = temp;

        }

        public int search(T val)
        {
            Node<T> temp = head;
            int index = 0;
            if (head == null)
            {
                return -1;
            }

            while (!temp.data.Equals(val))
            {
                index++;
                temp = temp.next;

            }

            return index;

        }

        public void removeAt(int index)
        {
            Node<T> previous = head;
            count--;

            if (head == null)
            {
                return;
            }

            if (index == 0)
            {
                head = previous.next;
                return;
            }

            for (int i = 0; previous != null && i < index - 1; i++)
            {
                previous = previous.next;
            }

            if (previous == null || previous.next == null)
            {
                return;
            }

            Node<T> next = previous.next.next;


            previous.next = next;

        }

        public void add(T data)
        {
            Node<T> toAdd = new Node<T>();
            toAdd.data = data;
            if (head == null)
            {
                head = toAdd;
            }
            else
            {
                tail.next = toAdd;
            }
            tail = toAdd;
            count++;
        }

        public void clear()
        {
            head = null;
            count = 0;
        }

        public void insert(int pos, T data)
        {
            
            //Create node
            Node<T> node = new Node<T>();
            node.data = data;
            node.next = null;
            count++;

            if (head == null)
            {
                if (pos != 0)
                {
                    return;
                }
                else
                {
                    head = node;
                }
            }

            if (head != null && pos == 0)
            {
                node.next = head;
                head = node;
                return;
            }

            Node<T> current = head;
            Node<T> previous = null;
            int i = 0;
            while (i < pos)
            {
                previous = current;
                current = current.next;

                if (current == null)
                {
                    break;
                }

                i++;
            }

            node.next = current;
            previous.next = node;
            

        }

        public T get(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException();
            }
            Node<T> temp = head;
            int counter = 0;
            while (temp != null)
            {
                if (counter == index)
                {
                    return temp.data;
                }

                counter++;
                temp = temp.next;

                
            }

            return temp.data;
        }

        public void remove()
        {
            Node<T> temp = head;
            count--;
            if (head == null)
            {
                return;
            }

            head = head.next;
            temp = null;
        }
    }
}