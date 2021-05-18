using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Media;
using System.Xml;
using Comuna;
using Comuna.Graphviz;
using QuickGraph;
using QuickGraph.Graphviz.Dot;

namespace NetworkArchitectWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            /*//Graphviz graphviz = new Graphviz("C:/Users/Yaksh Patel/RiderProjects/Algorithms-II/NetworkArchitectWPF/bin/Debug");

            Graphviz graphviz = new Graphviz("C:/Users/Yaksh Patel/RiderProjects/Algorithms-II/NetworkArchitectWPF/Graphviz/bin");
            
            Graph baseGraph = graphviz.CreateGraph(Attributes.WithLabel("Example"), true);

            baseGraph.NodeAttributes = new Attributes {Shape = Shape.Rectangle};

            Attributes baseAttributes = new Attributes {Style = Styles.Filled};
            Attributes baseNodeAttributes = new Attributes { Style = Styles.Filled};

            Graph sub1 = baseGraph.CreateSubGraph(true, baseAttributes.CopyWithLabel("Subgraph 1"));
            sub1.NodeAttributes = baseNodeAttributes;
            Graph sub2 = baseGraph.CreateSubGraph(true, baseAttributes.CopyWithLabel("Subgraph 2"));
            sub2.NodeAttributes = baseNodeAttributes;

            Node start = baseGraph.CreateNode(Attributes.WithLabel("Entry"));
            Node a0 = sub1.CreateNode(Attributes.WithLabel("A0"));
            Node a1 = sub1.CreateNode(Attributes.WithLabel("A1"));
            Node a2 = sub1.CreateNode(Attributes.WithLabel("A2"));
            Node a3 = sub1.CreateNode(Attributes.WithLabel("A3"));
            Node b0 = sub2.CreateNode(Attributes.WithLabel("B0"));
            Node b1 = sub2.CreateNode(Attributes.WithLabel("B1"));
            Node b2 = sub2.CreateNode(Attributes.WithLabel("B2"));
            Node end = baseGraph.CreateNode(Attributes.WithLabel("End"));

            baseGraph.CreateEdge(start, a0, Attributes.Empty());
            baseGraph.CreateEdge(a0, a1, Attributes.Empty());
            baseGraph.CreateEdge(a1, a2, Attributes.Empty());
            baseGraph.CreateEdge(a2, a3, Attributes.Empty());
            baseGraph.CreateEdge(a3, end, Attributes.Empty());
            baseGraph.CreateEdge(a3, a0, Attributes.Empty());

            // baseGraph.CreateEdge(start, b0, Attributes.Empty());
            // baseGraph.CreateEdge(a1, b2, Attributes.Empty());
            // baseGraph.CreateEdge(b1, a3, Attributes.Empty());
            // baseGraph.CreateEdge(b2, end, Attributes.Empty());

            string a = baseGraph.GenerateDot();
            graphviz.GenerateGraph(baseGraph, GraphRenderingEngine.Dot, GraphOuputType.Jpg, "example.jpg");*/
            
            SaveFileTolDivTest();
           
        }
        
        public void SaveFileTolDivTest()
        {
            SaveFileTest(TolPalettes.CreateTolDivPalette, "div");
        }

        
        private void SaveFileTest(PaletteGenerator paletteGenerator, string name)
        {
            // creates graph and adds nodes
            var network = new Network();
            for (var i = 0u; i < 10; i++)
                network.AddVertex(i);

            // adds connections
            network.AddEdge(new Connection(0, 1));
            network.AddEdge(new Connection(0, 2));
            network.AddEdge(new Connection(0, 9));
            network.AddEdge(new Connection(2, 4));
            network.AddEdge(new Connection(2, 9));
            network.AddEdge(new Connection(4, 7));
            network.AddEdge(new Connection(7, 9));
            network.AddEdge(new Connection(8, 9));

            // creates algorithm and updates communities
            var communityAlg = new CommunityAlgorithm(network, -1, 0.000001);
            communityAlg.Update();
            communityAlg.DisplayCommunities();

            var fullPath = Path.GetFullPath(".");
          
            var fileName = $"graph-{name}-{GraphvizImageType.Png}";
            var dotPath = Path.Combine(fullPath, $"{fileName}.dot");
            var imgPath = $"{dotPath}.png";
            //File.Delete(dotPath);
            //File.Delete(imgPath);

            var filePath = communityAlg.ToGraphvizFile(
                fullPath, fileName, true, GraphvizImageType.Png, paletteGenerator, 1000);

            Console.WriteLine(dotPath);
                
            Console.WriteLine(imgPath);
              

            //File.Delete(dotPath);
            //File.Delete(imgPath);
        }
    }
}