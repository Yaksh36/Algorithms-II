using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Network
{
    public class MinimumSpanningTree<T> where T:IComparable<T>
    {
        public int Count { get; set; }

        public Dictionary<T, Vertex<T>> Vertices = new Dictionary<T, Vertex<T>>();
        //Tracks edges weight, <sourceVertex, DestinationVertex>
        public List<KeyValuePair<int, Tuple<Vertex<T>, Vertex<T>>>> treeEdges =
            new List<KeyValuePair<int, Tuple<Vertex<T>, Vertex<T>>>>();

        public void AddVertex(Vertex<T> vertex)
        {
            Vertices[vertex.Data] = vertex;
            Count++;
        }

        public void AddEdge(T sourceNode, T destinationNode, int weight)
        {
            var source =  Vertices[sourceNode];
            var destination = Vertices[destinationNode];
            source.Edges.AddLast(new Tuple<Vertex<T>, int>(destination,weight));
            treeEdges.Add(new KeyValuePair<int, Tuple<Vertex<T>, Vertex<T>>>(weight,new Tuple<Vertex<T>,
                Vertex<T>>(source,destination)));
        }

        public int PrimsAlgorithm()
        {
            //Sort the edges
            treeEdges =  treeEdges.OrderBy(e=> e.Key).ToList();
            
            var tempVertices = new HashSet<T>();
            var trackEdges = new List<KeyValuePair<int, Tuple<Vertex<T>, Vertex<T>>>>();
            var resultEdges = new List<KeyValuePair<int, Tuple<Vertex<T>, Vertex<T>>>>();
            var queue = new Queue<KeyValuePair<int, Tuple<Vertex<T>, Vertex<T>>>>();
            
            //Pick the edge with least weight
            queue.Enqueue(treeEdges.First());

            while (queue.Count != 0)
            {
                var edge = queue.Dequeue();
                resultEdges.Add(edge);
                
                var v1 = edge.Value.Item1;
                var v2 = edge.Value.Item2;
                var tempV = new Vertex<T>[] {v1,v2 };
                
                if (!tempVertices.Contains(v1.Data))
                {
                    tempVertices.Add(v1.Data);
                }
                if (!tempVertices.Contains(v2.Data))
                {
                    tempVertices.Add(v2.Data);
                }

                foreach (var vertex in tempV)
                {
                    foreach (var e in vertex.Edges)
                    {
                        if (!tempVertices.Contains(e.Item1.Data))
                        {
                            trackEdges.Add(new KeyValuePair<int, Tuple<Vertex<T>, Vertex<T>>>(e.Item2, new Tuple<Vertex<T>, Vertex<T>>(vertex, e.Item1)));
                        }
                    }
                }

                trackEdges = trackEdges.Where(e => !tempVertices.Any(v => v.Equals(e.Value.Item2.Data))).ToList();

                if (trackEdges.Count > 0)
                {
                    trackEdges = trackEdges.OrderBy(e=> e.Key).ToList();
                    queue.Enqueue(trackEdges.First());
                    trackEdges.RemoveAt(0);
                }
            }
            
            PrintTree(resultEdges);
            return resultEdges.Count > 0 ? resultEdges.Sum(e => e.Key) : -1;
        }

        public void PrintTree(List<KeyValuePair<int, Tuple<Vertex<T>, Vertex<T>>>> edges)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("graph EthernetNetwork {");
            foreach (var vertexPair in Vertices)
            {
                stringBuilder.AppendLine(vertexPair.Key + ";");
            }

            foreach (var edgePair in edges)
            {
                string edgeConnection = edgePair.Value.Item1.Data + " -- " + edgePair.Value.Item2.Data + " [label=\"" +
                                        edgePair.Key + "\"];";
                stringBuilder.AppendLine(edgeConnection);
            }

            stringBuilder.AppendLine("}");

            File.WriteAllText("treeOutputFile", stringBuilder.ToString());
            var args = $"\"treeOutputFile\" -Tpng -O";
            var processInfo = new ProcessStartInfo("dot", args)
            {
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };
            var process = Process.Start(processInfo);
            process?.WaitForExit(1000);
        }
    }
}