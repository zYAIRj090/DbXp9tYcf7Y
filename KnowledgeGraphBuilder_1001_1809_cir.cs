// 代码生成时间: 2025-10-01 18:09:51
// KnowledgeGraphBuilder.cs
// This class is responsible for building a knowledge graph using CSharp and .NET framework.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace KnowledgeGraph
{
    public class KnowledgeGraphBuilder
    {
        private const string GraphJsonFilePath = "./knowledge_graph.json";

        // Represents a node in the graph
        public class GraphNode
        {
            public string Id { get; set; }
            public string Label { get; set; }
            public Dictionary<string, string> Properties { get; set; } = new Dictionary<string, string>();
        }

        // Represents an edge connecting two nodes
        public class GraphEdge
        {
            public string FromNodeId { get; set; }
            public string ToNodeId { get; set; }
            public string Label { get; set; }
        }

        public GraphNode[] Nodes { get; private set; } = Array.Empty<GraphNode>();
        public GraphEdge[] Edges { get; private set; } = Array.Empty<GraphEdge>();

        public void AddNode(GraphNode node)
        {
            if (node == null) throw new ArgumentNullException(nameof(node));
            if (string.IsNullOrEmpty(node.Id)) throw new ArgumentException("Node ID cannot be null or empty.");

            Nodes = Nodes.Concat(new[] { node }).ToArray();
           SaveGraph();
        }

        public void AddEdge(GraphEdge edge)
        {
            if (edge == null) throw new ArgumentNullException(nameof(edge));
            if (string.IsNullOrEmpty(edge.FromNodeId) || string.IsNullOrEmpty(edge.ToNodeId)) throw new ArgumentException("Edge nodes cannot be null or empty.");

            Edges = Edges.Concat(new[] { edge }).ToArray();
           SaveGraph();
        }

        private void SaveGraph()
        {
            // Serialize the graph to JSON and save to a file
            var graphData = new
            {
                Nodes = Nodes,
                Edges = Edges
            };

            var json = JsonSerializer.Serialize(graphData, new JsonSerializerOptions { WriteIndented = true });
            System.IO.File.WriteAllText(GraphJsonFilePath, json);
        }

        public void LoadGraph()
        {            
            // Load the graph from a JSON file
            if (System.IO.File.Exists(GraphJsonFilePath))
            {
                var json = System.IO.File.ReadAllText(GraphJsonFilePath);
                var graphData = JsonSerializer.Deserialize<GraphData>(json);

                Nodes = graphData.Nodes;
                Edges = graphData.Edges;
            }
            else
            {
                Nodes = Array.Empty<GraphNode>();
                Edges = Array.Empty<GraphEdge>();
            }
        }
    }

    public class GraphData
    {
        public GraphNode[] Nodes { get; set; }
        public GraphEdge[] Edges { get; set; }
    }
}
