using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MazeSolver
{
    internal class Program
    {
        //C:\Users\Yaksh Patel\Downloads\TestMazes.txt
        public static void Main(string[] args)
        {
            Console.WriteLine("Please enter the location of file containing the maze:");
            String fileLocation = Console.ReadLine();
            Console.WriteLine("The location is: " +  fileLocation);
            
            //Read file
            if (fileLocation != null)
            {
               var lines = File.ReadAllLines(fileLocation);
               //var lines = File.ReadAllLines("C:/Users/Yaksh Patel/Downloads/TestMazes.txt");
               List<String[]> mazes = new List<string[]>();
               var tempList = new List<String>();
               foreach (var line in lines)
               {
                   if (line=="")
                   {
                       mazes.Add(tempList.ToArray());
                       tempList.Clear();
                   }
                   else
                   {
                       tempList.Add(line);
                   }
               }

               if (tempList.Count > 0)
               {
                   mazes.Add(tempList.ToArray());
                   tempList.Clear();
               }
               //mazes
               foreach (var maze in mazes)
               {
                   Graph<String> graph = new Graph<string>(); 
                   int index = 0;
                   string source = "", destination = "";
                   foreach (var line in maze)
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
                       else if (index == 1)
                       {
                           string[] l = line.Split(',');
                           source = l[0];
                           destination = l[1];
                       }
                       else if (index >= 2)
                       {
                           var nodes = line.Split(',').ToList();
                           if (nodes.Count > 0)
                           {
                               var tempSource = nodes[0];
                               nodes.RemoveAt(0);

                               foreach (var node in nodes)
                               {
                                   graph.AddEdge(tempSource, node);
                               }
                           }
                       }
                       index++;
                   }

                   List<Vertex<String>> result =  graph.FindShortestPath(source, destination);
                   if (result != null)
                   {
                       Console.Write("The shortest path from " + source + " to " + destination + " is: ");
                       foreach (var vertex in result)
                       {
                           Console.Write(vertex.Data);

                       }
                   }

                   Console.WriteLine();
               }
               
            }
        }
    }
}