namespace ADP.Datastructures.Graph.Helpers
{
    public static class GraphDatasetReaderExtension
    {
        public static void ReadAdjacencyListUnweightedInt(this GraphADP<int> graph, int[][] data)
        {
            for (var i = 0; i < data.Length; i++)
            {
                var vertexData = i;
                graph.AddVertex(vertexData);
            }

            for (var i = 0; i < data.Length; i++)
            {
                for (var j = 0; j < data[i].Length; j++)
                {
                    var vertexData = i;
                    var edgeData = data[i][j];
                    if (!graph.AdjacencyList.ContainsKey(edgeData))
                    {
                        graph.AddVertex(edgeData);
                    }

                    graph.AddEdge(vertexData, edgeData);
                }
            }
        }

        public static void ReadAdjacencyListWeightedInt(this GraphADP<int> graph, int[][][] data)
        {
            for (var i = 0; i < data.Length; i++)
            {
                var vertexData = i;
                graph.AddVertex(vertexData);
            }

            for (var i = 0; i < data.Length; i++)
            {
                for (var j = 0; j < data[i].Length; j++)
                {
                    var vertexData = i;
                    var edgeData = data[i][j];
                    if (!graph.AdjacencyList.ContainsKey(edgeData[0]))
                    {
                        graph.AddVertex(edgeData[0]);
                    }

                    graph.AddEdge(vertexData, edgeData[0], edgeData[1]);
                }
            }
        }

        public static void ReadEdgeListUnweightedInt(this GraphADP<int> graph, int[][] data)
        {
            for (var i = 0; i < data.Length; i++)
            {
                var vertexValue = data[i][0];
                if (!graph.AdjacencyList.ContainsKey(vertexValue))
                {
                    graph.AddVertex(vertexValue);
                }

                var edgeValue = data[i][1];
                if (!graph.AdjacencyList.ContainsKey(edgeValue))
                {
                    graph.AddVertex(edgeValue);
                }

                graph.AddEdge(vertexValue, edgeValue);
            }
        }

        public static void ReadEdgeListWeightedInt(this GraphADP<int> graph, int[][] data)
        {
            for (var i = 0; i < data.Length; i++)
            {
                var vertexValue = data[i][0];
                if (!graph.AdjacencyList.ContainsKey(vertexValue))
                {
                    graph.AddVertex(vertexValue);
                }

                var edgeValue = data[i][1];
                if (!graph.AdjacencyList.ContainsKey(edgeValue))
                {
                    graph.AddVertex(edgeValue);
                }

                var weightValue = data[i][2];
                graph.AddEdge(vertexValue, edgeValue, weightValue);
            }
        }

        public static void ReadAdjacencyMatrixUnweightedInt(this GraphADP<int> graph, int[][] data)
        {
            for (var i = 0; i < data.Length; i++)
            {
                graph.AddVertex(i);

                for (var j = i + 1; j < data[i].Length; j++)
                {
                    var edgeValue = data[i][j];
                    if (edgeValue == 1)
                    {
                        if (!graph.AdjacencyList.ContainsKey(j))
                        {
                            graph.AddVertex(j);
                        }

                        graph.AddEdge(i, j);
                        graph.AddEdge(j, i);
                    }
                }
            }
        }

        public static void ReadAdjacencyMatrixWeightedInt(this GraphADP<int> graph, int[][] data)
        {
            for (var i = 0; i < data.Length; i++)
            {
                if (!graph.AdjacencyList.ContainsKey(i))
                {
                    graph.AddVertex(i);
                }

                for (var j = 0; j < data[i].Length; j++)
                {
                    var edgeWeightValue = data[i][j];
                    if (edgeWeightValue > 0)
                    {
                        if (!graph.AdjacencyList.ContainsKey(j))
                        {
                            graph.AddVertex(j);
                        }

                        graph.AddEdge(i, j, edgeWeightValue);
                    }
                }
            }
        }
    }
}
