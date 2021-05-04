using System;

namespace AlgoDataStructures
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            DoubleLinkedList<char> charLinkedList = new DoubleLinkedList<char>();
            charLinkedList.Add('A');
            charLinkedList.Add('B');
            charLinkedList.Add('C');
            charLinkedList.Add('D');
            charLinkedList.Insert('E',1);
            
            
            Console.WriteLine( " ");
        }
    }
}