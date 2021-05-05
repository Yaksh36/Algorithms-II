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
            charLinkedList.Add('D');
            char a = charLinkedList.RemoveLast();

            Console.WriteLine( a);
        }
    }
}