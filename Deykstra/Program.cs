﻿//вершина графа
public class GraphVertex
{
    public string? Name { get; }
    public List<GraphEdge> Edges { get; }
    public GraphVertex(string vertexName)
    {
        Name = vertexName;
        Edges = new List<GraphEdge>();
    }
    public void AddEdge(GraphEdge newEdge)
    {
        Edges.Add(newEdge);
    }
    public void AddEdge(GraphVertex vertex,int edgeWeight)
    {
        AddEdge(new GraphEdge(vertex, edgeWeight));
    }
    public override string? ToString() => Name;
}
//ребро графа
public class GraphEdge
{
    public GraphVertex ConnectedVertex { get; }
    public int EdgeWeight { get; }

    public GraphEdge(GraphVertex connectedVertex, int edgeWeight)
    {
        ConnectedVertex = connectedVertex;
        EdgeWeight = edgeWeight;
    }
}
