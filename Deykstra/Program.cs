//вершина графа
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

//Граф
public class Graph
{
    public List<GraphVertex> Vertices { get; }
    public Graph()
    {
        Vertices = new List<GraphVertex>();
    }
    public void AddVertex(string vertexName)
    {
        Vertices.Add(new GraphVertex(vertexName));
    }
    public GraphVertex FindVertex(string vertexName)
    {
        foreach (var v in Vertices)
        {
            if (v.Name!.Equals(vertexName)) return v;
        }
        return null!;
    }
    public void AddEdge(string firstName, string secondName,int weight)
    {
        var v1 = FindVertex(firstName);
        var v2 = FindVertex(secondName);
        if (v2 != null && v1 != null)
        {
            v1.AddEdge(v2, weight);
            v2.AddEdge(v1, weight);
        }
    }
}

public class GraphVertexInfo
{
    public GraphVertex Vertex { get; set; }
    public bool IsUnvisited { get; set; }
    public int EdgesWeightSum { get; set; }
    public GraphVertex PreviusVertex { get; set; }

    public GraphVertexInfo(GraphVertex vertex)
    {
        Vertex = vertex;
        IsUnvisited = true;
        EdgesWeightSum = int.MaxValue;
        PreviusVertex = null!;
    }
}

public class Dijkstra
{
    Graph graph;
    List<GraphVertexInfo> infos;
    public Dijkstra(Graph graph)
    {
        this.graph = graph;
    }
    void InitInfo()
    {
        infos = new List<GraphVertexInfo>();
        foreach (var v in graph.Vertices) infos.Add(new GraphVertexInfo(v));
    }
    GraphVertexInfo GetVertexInfo(GraphVertex v)
    {
        foreach (var i in infos)
        {
            if (i.Vertex.Equals(v)) return i;
        }
        return null!;
    }
    public GraphVertexInfo FindVisitredVertexWithMinSum()
    {
        var minValue = int.MaxValue;
        GraphVertexInfo minVertexInfo = null;
        foreach(var i in infos)
        {
            if (i.IsUnvisited && i.EdgesWeightSum < minValue)
            {
                minVertexInfo = i;
                minValue = i.EdgesWeightSum;
            }
        }
        return minVertexInfo!;
    }
    public string FindShortestPath(GraphVertex startVertex,GraphVertex finishVertex)
    {
        InitInfo();
        var first = GetVertexInfo(startVertex);
        first.EdgesWeightSum = 0;
        while (true)
        {
            var current = FindVisitredVertexWithMinSum();
            if (current == null) break;
            SetSumToNextVertex(current);
        }
        return GetPath(startVertex, finishVertex);
    }
    void SetSumToNextVertex(GraphVertexInfo info)
    {
        info.IsUnvisited = false;
        foreach(var e in info.Vertex.Edges)
        {
            var nextInfo = GetVertexInfo(e.ConnectedVertex);
            var sum = info.EdgesWeightSum + e.EdgeWeight;
            if (sum < nextInfo.EdgesWeightSum)
            {
                nextInfo.EdgesWeightSum = sum;
                nextInfo.PreviusVertex = info.Vertex;
            }
        }
    }
    string GetPath(GraphVertex startVertex,GraphVertex endVertex)
    {
        var path = endVertex.ToString();
        while (startVertex != endVertex)
        {
            endVertex = GetVertexInfo(endVertex).PreviusVertex;
            path = endVertex.ToString() + path;
        }
        return path!;
    }
    public string FindShortestPath(string startName,string finishName)
    {
        return FindShortestPath(graph.FindVertex(startName), graph.FindVertex(finishName));
    }
}
