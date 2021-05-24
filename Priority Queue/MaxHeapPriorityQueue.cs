using System;
using System.Collections.Generic;
using System.Net;
using System.Linq;

namespace Priority_Queue
{
    public class MaxHeapPriorityQueue<T> where T:IComparable<T>
    {

        private int count;
        public int Count
        {
            get => count;
            protected set => count = value;
        }

        private List<T> array = new List<T>();

        public void Add(T data)
        {
            array.Add(data);
            count++;
            HeapifyUp(Count - 1);
        }

        private void HeapifyUp(int currentIndex)
        {
            int parentIndex = (currentIndex - 1) / 2;

            if (array[currentIndex].CompareTo(array[parentIndex]) > 0)
            {
                Swap(ref array,currentIndex,parentIndex);
                HeapifyUp(parentIndex);
            }
        }

        private void Swap(ref List<T> list,int i1,int i2)
        {
            var temp = list[i1];
            list[i1] = list[i2];
            list[i2] = temp;
        }

        public T Peek()
        {
            return array[0];
        }

        public T Remove()
        {
            var tempRoot = array[0];
            Swap(ref array,(Count-1),0);
            array.RemoveAt(Count-1);
            count--;
            HeapifyDown(0, ref array, count);

            return tempRoot;
        }

       /// <summary>
       /// Heapify Down is used in the Remove method and The sort array method.
       /// </summary>
       /// <param name="i">The current index</param>
       /// <param name="list"></param>
       /// <param name="n">The size of the array</param>
        private void HeapifyDown(int i, ref List<T> list, int n)
        {
            var largest = i;
            var left = 2 * i + 1; 
            var right = 2 * i + 2;

            if (left < n && list[left].CompareTo(list[largest]) > 0)
            {
                largest = left;
            }
            
            if (right < n && list[right].CompareTo(list[largest]) > 0)
            {
                largest = right;
            }

            if (largest != i)
            {
                Swap(ref list, i,largest);
                HeapifyDown(largest, ref list, n);
            }
        }

        public T[] ToSortedArray()
        {
            var tempArray = array;
            var arrayCount = tempArray.Count;

            while (arrayCount > 0)
            {
                Swap(ref tempArray,(arrayCount-1),0);
                arrayCount--;
                HeapifyDown(0, ref tempArray,arrayCount);
            }
          

            tempArray.Reverse();
            return tempArray.ToArray();
        }
    }
}