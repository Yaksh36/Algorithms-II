using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Network
{
    internal class Program
    {
        public static void Main(string[] args)
        {   
            Console.WriteLine("Please enter the location of file containing the maze:");
            String fileLocation = Console.ReadLine();
            Console.WriteLine("The location is: " +  fileLocation);
            
            //Read file
            if (fileLocation != null)
            {
                //var lines = File.ReadAllLines(fileLocation);
                var lines = File.ReadAllLines("C:/Users/Yaksh Patel/Downloads/TestCase2.txt");
                MinimumSpanningTree<String> graph = new MinimumSpanningTree<string>(); 
                int index = 0;
                foreach (var line in lines)
                {
                    //All Nodes
                    if (index == 0)
                    {
                        var nodes = line.Split(',');
                        foreach (var node in nodes)
                        {
                            Vertex<String> vertex = new Vertex<string>(node);  
                            graph.AddVertex(vertex);
                        }
                    }
                    else
                    {
                        var nodes = line.Split(',').ToList();
                        if (nodes.Count > 0)
                        {
                            var tempSource = nodes[0];
                            nodes.RemoveAt(0);

                            foreach (var node in nodes)
                            {
                                string[] socketConnection = node.Split(':');
                                graph.AddEdge(tempSource, socketConnection[0], int.Parse(socketConnection[1]));
                            }
                        }
                    }
                    index++;
                }

                Console.WriteLine();
                Console.WriteLine("Socket Set: {0}", String.Join(", ", graph.Vertices.Select(e => e.Key)));
                Console.WriteLine("Cable Needed: {0}", graph.PrimsAlgorithm());
            }
        }
    }
}