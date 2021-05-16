using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace MazeSolver
{
    public class Graph<T> where T:IComparable<T>
    {
        public int Count { get; set; }

        public Dictionary<T, Vertex<T>> Vertices = new Dictionary<T, Vertex<T>>();

        public void AddEdge(T sourceNode, T destinationNode)
        {
            var source =  Vertices[sourceNode];
            var destination = Vertices[destinationNode];
            source.Edges.AddLast(destination);
        }

        public void AddVertex(Vertex<T> vertex)
        {
            Vertices[vertex.Data] = vertex;
            Count++;
        }

        public List<Vertex<T>> FindShortestPath(T source, T destination)
        {
            if (!Vertices.ContainsKey(source) || !Vertices.ContainsKey(destination))
            {
                Console.WriteLine("One of the vertices do no exist");
                return null;
            }
            
            if (!Breadth(Vertices[source], Vertices[destination]))
            {
                Console.WriteLine("Cannot solve the graph");
                return null;
            }

            Queue<Vertex<T>> queue = new Queue<Vertex<T>>();
            HashSet<Vertex<T>> shortestPathFound = new HashSet<Vertex<T>>();

            Dictionary<T, Vertex<T>> visited = new Dictionary<T, Vertex<T>>();
            Dictionary<Vertex<T>, Vertex<T>> predecessor = new Dictionary<Vertex<T>, Vertex<T>>();
            
            Vertex<T> start = Vertices[source];
            visited[start.Data] =start;
            queue.Enqueue(start);
            
            while (queue.Count != 0)
            {
                Vertex<T> vertex = queue.Dequeue();
                shortestPathFound.Add(vertex);

                //Reached the destination
                if (vertex.Data.CompareTo(Vertices[destination].Data) == 0)
                {
                    //build path
                    return BuildPath(vertex, predecessor);
                }

                foreach (var neighbor in vertex.Edges)
                {
                    if (shortestPathFound.Contains(neighbor))
                    {
                        continue;
                    }

                    // Calculate total distance to neighbor via current node
                    int totalDistance = vertex.Distance;
                    predecessor[neighbor] = vertex;
                    // Neighbor not yet discovered?
                    if (!visited.ContainsKey(neighbor.Data))
                    {
                        visited[neighbor.Data] = neighbor;
                        neighbor.Distance = vertex.Distance + 1;
                        queue.Enqueue(neighbor);
                    }else if (totalDistance < neighbor.Distance + 1)
                    {
                        neighbor.Distance = vertex.Distance + 1;
                        predecessor[neighbor] = vertex;

                        //Update the position in queue
                        queue = new Queue<Vertex<T>>(queue.Where(x => !x.Data.Equals(neighbor.Data)));
                        queue.Enqueue(neighbor);
                    }
                }

            }

            return null;
        }

        private List<Vertex<T>> BuildPath(Vertex<T> vertex, Dictionary<Vertex<T>,Vertex<T>> predecessor)
        {
            List<Vertex<T>> path = new List<Vertex<T>>();
            while (vertex != null)
            {
                path.Add(vertex);
                vertex = predecessor.ContainsKey(vertex) ? predecessor[vertex] : null;
            }

            path.Reverse();
            
            return path;
        }

        public bool Breadth(Vertex<T> source, Vertex<T> destination)
        {
            Dictionary<T, bool> visited = new Dictionary<T, bool>();

            Queue<Vertex<T>> queue = new Queue<Vertex<T>>();
            visited[source.Data] = true;
            queue.Enqueue(source);

            while (queue.Count != 0)
            {
                source = queue.Dequeue();

                LinkedList<Vertex<T>> adjacents = source.Edges;
                foreach (var vertex in adjacents)
                {
                    if (!visited.ContainsKey(vertex.Data))
                    {
                        visited[vertex.Data] = true;
                        queue.Enqueue(vertex);

                        if (vertex.Data.CompareTo(destination.Data) == 0)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        
        /*public void Breadth(Vertex<T> source)
        {
            Dictionary<T, bool> visited = new Dictionary<T, bool>();

            Queue<Vertex<T>> queue = new Queue<Vertex<T>>();
            visited[source.Data] = true;
            queue.Enqueue(source);

            while (queue.Count != 0)
            {
                source = queue.Dequeue();
                Console.WriteLine(source.Data);

                LinkedList<Vertex<T>> adjacents = source.Edges;
                foreach (var vertex in adjacents)
                {
                    if (!visited.ContainsKey(vertex.Data))
                    {
                        visited[vertex.Data] = true;
                        queue.Enqueue(vertex);
                    }
                }
            }
        }*/
    }
}