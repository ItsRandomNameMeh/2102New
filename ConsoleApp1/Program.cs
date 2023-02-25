using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Реализация алгоритма Краскала");
            ConsoleUI ui = new ConsoleUI();
            ui.GraphFromFile();
        }
        public class ConsoleUI
        {
            private string[] filenames = new string[] { @"..\..\..\..\TestFiles\test.txt", @"..\..\..\..\TestFiles\test1.txt", @"..\..\..\..\TestFiles\test2.txt" };

            public void GraphFromFile()
            {
                foreach (string filename in filenames)
                {
                    string[] lines = System.IO.File.ReadAllLines(filename);

                    Graph graph = new Graph();
                    foreach (string line in lines)
                    {
                        string[] splitted = line.Split();
                        Edge edge = new Edge(splitted[0], splitted[1], Int32.Parse(splitted[2]));
                        graph.Add(edge);
                    }
                    Console.WriteLine("Graph: ");
                    Console.WriteLine(graph.ToString());
                    Result(graph);
                }
            }

            public void Result(Graph graph)
            {
                graph = graph.FindMinimumSpanningTree();
                Console.WriteLine();
                Console.WriteLine("Min backbone: ");
                Console.Write(graph.ToString());
                Console.WriteLine(graph.GetWeight());
                Console.WriteLine();
            }
        }
    }
}
