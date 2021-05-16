using System;
using System.Collections.Generic;

namespace MazeSolver
{
    public class Vertex<T> where T:IComparable<T>
    {
        public T Data { get; set; }
        public LinkedList<Vertex<T>> Edges = new LinkedList<Vertex<T>>();
        public int Distance { get; set; }

        public Vertex() { }

        public Vertex(T data)
        {
            Data = data;
        }
        
    }
    
}