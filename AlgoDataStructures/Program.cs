using System;

namespace AlgoDataStructures
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            SingleLinkedList<char> charLinkedList = new SingleLinkedList<char>();
            charLinkedList.Add('A');
            charLinkedList.Add('B');
            charLinkedList.Add('C');
            charLinkedList.Add('B');
            
            int index = charLinkedList.Search('B');
            
            Console.WriteLine(index + " ");
        }
    }
}