using System;

namespace Priority_Queue
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            MaxHeapPriorityQueue<int> priorityQueue = new MaxHeapPriorityQueue<int>();
            priorityQueue.Add(10);
            priorityQueue.Add(8);
            priorityQueue.Add(6);
            priorityQueue.Add(12);
            //priorityQueue.Add(2);
            
            
            Console.WriteLine();
        }
    }
}