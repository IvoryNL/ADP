using ADP.Datastructures.Graph;

namespace ADP.Tests;
public static class DataSetGraphHelper
{
    public static GraphADP<string> Dijkstra1
    {
        get
        {
            var graph = new GraphADP<string>();
            graph.AddVertex("S");
            graph.AddVertex("B");
            graph.AddVertex("E");

            graph.AddEdge("S", "E", 7);
            graph.AddEdge("S", "B", 2);

            graph.AddEdge("E", "S", 7);
            graph.AddEdge("E", "B", 3);

            graph.AddEdge("B", "S", 2);
            graph.AddEdge("B", "E", 3);

            return graph;
        }
    }

    public static GraphADP<string> Dijkstra2
    {
        get
        {
            var graph = new GraphADP<string>();
            graph.AddVertex("S");
            graph.AddVertex("A");
            graph.AddVertex("B");
            graph.AddVertex("D");
            graph.AddVertex("E");

            graph.AddEdge("S", "A", 7);
            graph.AddEdge("S", "B", 2);

            graph.AddEdge("A", "S", 7);
            graph.AddEdge("A", "D", 4);
            graph.AddEdge("A", "B", 3);

            graph.AddEdge("D", "A", 4);
            graph.AddEdge("D", "B", 4);
            graph.AddEdge("D", "E", 2);

            graph.AddEdge("B", "E", 12);
            graph.AddEdge("B", "S", 2);
            graph.AddEdge("B", "A", 3);

            graph.AddEdge("E", "D", 2);
            graph.AddEdge("E", "B", 12);

            return graph;
        }
    }

    public static GraphADP<string> Dijkstra3
    {
        get
        {
            var graph = new GraphADP<string>();
            graph.AddVertex("S");
            graph.AddVertex("A");
            graph.AddVertex("B");
            graph.AddVertex("C");
            graph.AddVertex("D");
            graph.AddVertex("F");
            graph.AddVertex("G");
            graph.AddVertex("H");
            graph.AddVertex("I");
            graph.AddVertex("J");
            graph.AddVertex("K");
            graph.AddVertex("L");
            graph.AddVertex("E");

            graph.AddEdge("S", "A", 7);
            graph.AddEdge("S", "B", 2);
            graph.AddEdge("S", "C", 3);

            graph.AddEdge("A", "S", 7);
            graph.AddEdge("A", "D", 4);
            graph.AddEdge("A", "B", 3);

            graph.AddEdge("D", "A", 4);
            graph.AddEdge("D", "B", 4);
            graph.AddEdge("D", "F", 5);

            graph.AddEdge("B", "D", 4);
            graph.AddEdge("B", "S", 2);
            graph.AddEdge("B", "H", 1);
            graph.AddEdge("B", "A", 3);

            graph.AddEdge("F", "D", 5);
            graph.AddEdge("F", "H", 3);

            graph.AddEdge("H", "B", 1);
            graph.AddEdge("H", "F", 3);
            graph.AddEdge("H", "G", 2);

            graph.AddEdge("G", "H", 2);
            graph.AddEdge("G", "E", 2);

            graph.AddEdge("E", "G", 2);
            graph.AddEdge("E", "K", 5);

            graph.AddEdge("C", "S", 3);
            graph.AddEdge("C", "L", 2);

            graph.AddEdge("L", "I", 4);
            graph.AddEdge("L", "J", 4);
            graph.AddEdge("L", "C", 2);

            graph.AddEdge("I", "L", 4);
            graph.AddEdge("I", "J", 6);
            graph.AddEdge("I", "K", 4);

            graph.AddEdge("J", "L", 4);
            graph.AddEdge("J", "I", 6);
            graph.AddEdge("J", "K", 4);

            graph.AddEdge("K", "I", 4);
            graph.AddEdge("K", "J", 4);
            graph.AddEdge("K", "E", 5);

            return graph;
        }
    }

    public static int[][] lijnlijst = new int[][]
    {
        new int[] { 0, 1 },
        new int[] { 0, 2 },
        new int[] { 1, 2 },
        new int[] { 1, 3 },
        new int[] { 2, 4 },
        new int[] { 3, 4 },
        new int[] { 4, 5 },
        new int[] { 5, 6 }
    };

    public static int[][] lijnlijst_gewogen = new int[][]
    {
        new int[] { 0, 1, 99  },
        new int[] { 0, 2, 50  },
        new int[] { 1, 2, 50  },
        new int[] { 1, 3, 50  },
        new int[] { 1, 4, 50  },
        new int[] { 2, 3, 99  },
        new int[] { 3, 4, 75  }
    };

    public static int[][] verbindingsmatrix = new int[][]
    {
        new int [] { 0, 1, 1, 0, 0, 0, 0 },
        new int [] { 1, 0, 1, 1, 0, 0, 0 },
        new int [] { 1, 1, 0, 0, 1, 0, 0 },
        new int [] { 0, 1, 0, 0, 1, 0, 0 },
        new int [] { 0, 0, 1, 1, 0, 1, 0 },
        new int [] { 0, 0, 0, 0, 1, 0, 1 },
        new int [] { 0, 0, 0, 0, 0, 1, 0 }
    };

    public static int[][] verbindingsmatrix_gewogen = new int[][]
    {
        new int [] { 0, 99, 50, 0, 0},
        new int [] { 0, 0, 50, 50, 50 },
        new int [] { 0, 0, 0, 99, 0 },
        new int [] { 0, 0, 0, 0, 75 },
        new int [] { 0, 0, 0, 0, 0 }
    };

    public static int[][] verbindingslijst1 = new int[][]
    {
        new int[] {1, 2},
        new int[] {0, 2, 3},
        new int[] {0, 1, 4},
        new int[] {1, 4},
        new int[] {2, 3, 5},
        new int[] {4, 6},
        new int[] {5}
    };

    public static int[][] verbindingslijst2 = new int[][]
    {
        new int[] {1, 2},
        new int[] {0, 2, 3},
        new int[] {0, 1, 4},
        new int[] {1, 4},
        new int[] {2, 3, 5},
        new int[] {4, 6},
        new int[] {5},
        new int[] { 8},
        new int[] {6, 7, 9},
        new int[] {6, 7, 10},
        new int[] {9, 11},
        new int[] {8, 9},
        new int[] {10, 11},
        new int[] {11}
    };

    public static int[][] verbindingslijst3 = new int[][]
    {
        new int[] {1, 2},
        new int[] {0, 2, 3},
        new int[] { 0, 1, 4 },
        new int[] { 1, 4 },
        new int[] { 2, 3, 5 },
        new int[] { 4, 6 },
        new int[] { 5 },
        new int[] { 6, 8 },
        new int[] { 6, 7, 9 },
        new int[] { 6, 7, 10 },
        new int[] { 9, 11 },
        new int[] { 8, 9, 10 },
        new int[] { 10, 11 },
        new int[] { 11 },
        new int[] { 13, 15 },
        new int[] { 9, 14, 16 },
        new int[] { 9, 13, 15 },
        new int[] { 15, 16 },
        new int[] { 14, 15, 17 },
        new int[] { 16, 18 },
        new int[] { 17 },
        new int[] { 18, 19 },
        new int[] { 17, 19, 20 },
        new int[] { 17, 18, 21 },
        new int[] { 20, 21 },
        new int[] { 19, 20, 22 },
        new int[] { 21, 23 },
        new int[] { 22, 23 },
        new int[] { 22 }
    };

    public static int[][][] verbindingslijst_gewogen1 = new int[][][]
    {
        new int[][]
        {
            new int[] {1, 99},
            new int[] {2, 50}
        },
        new int[][]
        {
            new int[] {2, 50},
            new int[] {3, 50}
        },
        new int[][]
        {
            new int[] {3, 99}
        },
        new int[][]
        {
            new int[] {1, 75}
        },
    };

    public static int[][][] verbindingslijst_gewogen2 = new int[][][]
    {
        new int[][]
        {
            new int[] {1, 99},
            new int[] {2, 50}
        },
        new int[][]
        {
            new int[] {2, 50},
            new int[] {3, 50},
            new int[] {4, 50}
        },
        new int[][]
        {
            new int[] {3, 99}
        },
        new int[][]
        {
            new int[] {4, 75}
        },
        new int[][]
        {
            new int[] {5, 80},
            new int[] {6, 60}
        },
        new int[][]
        {
            new int[] {6, 60},
            new int[] {7, 70},
            new int[] {3, 80}
        },
        new int[][]
        {
            new int[] {7, 99}
        },
        new int[][]
        {
            new int[] {1, 75}
        }
    };

    public static int[][][] verbindingslijst_gewogen3 = new int[][][]
    {
        new int[][]
        {
            new int[] {1, 99},
            new int[] {2, 50}
        },
        new int[][]
        {
            new int[] {2, 50},
            new int[] {3, 50},
            new int[] {4, 50}
        },
        new int[][]
        {
            new int[] {3, 99}
        },
        new int[][]
        {
            new int[] {4, 75}
        },
        new int[][]
        {
            new int[] {5, 80},
            new int[] {6, 60}
        },
        new int[][]
        {
            new int[] {6, 60},
            new int[] {7, 70},
            new int[] {8, 80}
        },
        new int[][]
        {
            new int[] {7, 99}
        },
        new int[][]
        {
            new int[] {8, 75}
        },
        new int[][]
        {
            new int[] {9, 90},
            new int[] {10, 50}
        },
        new int[][]
        {
            new int[] {10, 50},
            new int[] {11, 50},
            new int[] {4, 50}
        },
        new int[][]
        {
            new int[] {11, 90}
        },
        new int[][]
        {
            new int[] {9, 75}
        },
    };
}
