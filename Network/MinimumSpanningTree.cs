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
            var tempVertices = new Dictionary<T, Vertex<T>>();
            var edges = new List<KeyValuePair<int, Tuple<Vertex<T>, Vertex<T>>>>();
            
            //sort the edges by weight
            treeEdges = treeEdges.OrderBy(e=> e.Key).ToList();

            //Take the first edge from the sorted list as prims Algorithm advices to start with the smallest edgex
            Vertex<T> start = treeEdges.First().Value.Item1;
            Vertex<T> startDest = treeEdges.First().Value.Item2;
            
            tempVertices.Add(start.Data,start);
            edges.Add(treeEdges.First());
            
            Queue<Vertex<T>> queue = new Queue<Vertex<T>>();
            queue.Enqueue(startDest);

            while (queue.Count != 0)
            {
                Vertex<T> vertex = queue.Dequeue();
                tempVertices.Add(vertex.Data,vertex);

                var vertexEdges = vertex.Edges.Where(e => !tempVertices.Any(v => v.Key.Equals(e.Item1.Data))).ToList();
                vertexEdges = vertexEdges.OrderBy(e => e.Item2).ToList();
                if (vertexEdges.Count > 0)
                {
                    var destVertex = vertexEdges.First();

                    edges.Add(new KeyValuePair<int, Tuple<Vertex<T>, Vertex<T>>>(destVertex.Item2,
                        new Tuple<Vertex<T>, Vertex<T>>(vertex, destVertex.Item1)));

                    queue.Enqueue(destVertex.Item1);
                }
            }

            //Special case if all the vertices are not included
            var remainder = Vertices.Where(e => !tempVertices.Any(v => v.Key.Equals(e.Key))).ToList();
            if (remainder.Count > 0)
            {
                foreach (var vertex in remainder)
                {
                    var vEdges = vertex.Value.Edges.OrderBy(e => e.Item2).ToList();
                    if (vEdges.Count > 0 && !tempVertices.ContainsKey(vertex.Key))
                    {
                        var destVertex = vEdges.First();
                        tempVertices.Add(destVertex.Item1.Data, destVertex.Item1);
                        edges.Add(new KeyValuePair<int, Tuple<Vertex<T>, Vertex<T>>>(destVertex.Item2, new Tuple<Vertex<T>, Vertex<T>>(vertex.Value,destVertex.Item1)));
                    }
                }
            }

            PrintTree(edges);
            return edges.Count > 0 ? edges.Sum(e => e.Key) : -1;
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