using System;

namespace Priority_Queue
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            MaxHeapPriorityQueue<int> priorityQueue = new MaxHeapPriorityQueue<int>();
            priorityQueue.Add(2);
            priorityQueue.Add(7);
            priorityQueue.Add(26);
            priorityQueue.Add(25);
            priorityQueue.Add(19);
            priorityQueue.Add(17);
            priorityQueue.Add(1);
            priorityQueue.Add(90);
            priorityQueue.Add(3);
            priorityQueue.Add(36);

            //int i = priorityQueue.Remove();
            
            int[] i = priorityQueue.ToSortedArray();
            //priorityQueue.Add(2);
            
            
            Console.WriteLine();
        }
    }
}