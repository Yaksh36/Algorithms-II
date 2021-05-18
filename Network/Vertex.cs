using System;
using System.Collections.Generic;
using System.Linq;

namespace Network
{
    public class Vertex<T> where T:IComparable<T>
    {
        public T Data { get; set; }
        public LinkedList<Tuple<Vertex<T>, int>> Edges = new LinkedList<Tuple<Vertex<T>, int>>();
        public Vertex() { }

        public Vertex(T data)
        {
            Data = data;
        }
    }
}