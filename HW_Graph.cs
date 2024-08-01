namespace Data_Structure2
{
    internal class HW_Graph
    {

        static void Main()
        {
            List<int>[] graph1 = new List<int>[8];

            for (int i = 0; i < graph1.Length; i++)
            {
                graph1[i] = new List<int>();
            }
            // 인접 리스트 그래프
            graph1[0].Add(1);
            graph1[0].Add(3);
            graph1[0].Add(4);
            graph1[1].Add(6);
            graph1[3].Add(1);
            graph1[3].Add(7);
            graph1[5].Add(3);
            graph1[5].Add(6);
            graph1[7].Add(6);


            ListGraph graph3 = new ListGraph(8);

            graph3.graph[0].Add(1);
            graph3.graph[0].Add(3);
            graph3.graph[0].Add(4);
            graph3.graph[1].Add(6);
            graph3.graph[3].Add(1);
            graph3.graph[3].Add(7);
            graph3.graph[5].Add(3);
            graph3.graph[5].Add(6);
            graph3.graph[7].Add(6);

            // 연결되어 있지 않는 노드까지 다 출력
            Console.WriteLine("리스트 그래프 출력");
            for (int i = 0; i < graph3.graph.Length; i++)
            {
                Console.Write($"{i}노드 : \n");

                foreach (int j in graph3.graph[i])
                {
                    int count = 0;
                    if (graph3.CheckConnect(i, j) != false)
                    {
                        Console.Write($"{j,+5}노드");
                    }

                    Console.WriteLine();
                }
            }
            Console.WriteLine("===================================================");
            
            // 인접 행렬 그래프
            bool[,] graph2 = new bool[8, 8];
            graph2[0, 1] = true;
            graph2[0, 3] = true;
            graph2[0, 4] = true;
            graph2[1, 6] = true;
            graph2[3, 1] = true;
            graph2[3, 7] = true;
            graph2[5, 3] = true;
            graph2[5, 6] = true;
            graph2[7, 6] = true;

            MatrixGraph graph4 = new MatrixGraph(8);
            graph4.graph[0, 1] = true;
            graph4.graph[0, 1] = true;
            graph4.graph[0, 3] = true;
            graph4.graph[0, 4] = true;
            graph4.graph[1, 6] = true;
            graph4.graph[3, 1] = true;
            graph4.graph[3, 7] = true;
            graph4.graph[5, 3] = true;
            graph4.graph[5, 6] = true;
            graph4.graph[7, 6] = true;

            Console.WriteLine("행렬 그래프 출력");
            for (int i = 0; i < graph4.graph.GetLength(0); i++) //graph4.graph.Length 는 8*8=64이라서 안되나 그럼 뭘 해야하지
            { 
                bool connection = false; // 연결되어 있는 함수만 출력하기
                
                for (int j = 0; j < graph4.graph.GetLength(0); j++)
                {
                    if(graph4.CheckConnect(i, j))
                    {
                        if(!connection)
                        {
                            Console.Write($"{i}노드 : \n"); 
                            connection = true;
                        }
                        Console.Write($"{j,+5}노드");
                    }                                                           
                }
                if (connection)
                    Console.WriteLine();
            }
            Console.WriteLine("===================================================\n");


        }

        public abstract class Graph
        {
            public abstract void Connect(int from, int to);
            public abstract void Disconnect(int from, int to);
            public abstract bool CheckConnect(int from, int to);
        }

        public class MatrixGraph : Graph
        {
            public bool[,] graph;

            public MatrixGraph(int vertex)
            {
                graph = new bool[vertex, vertex];
            }
            public override void Connect(int from, int to)
            {
                graph[from, to] = true;
            }
            public override void Disconnect(int from, int to)
            {
                graph[from, to] = false;
            }
            public override bool CheckConnect(int from, int to)
            {
                return graph[from, to]; //bool값은 기본이 false니까 없으면 자동으로 false를 뱉는다.
            }
        }

        public class ListGraph : Graph
        {
            public List<int>[] graph;

            public ListGraph(int vertex)
            {
                graph = new List<int>[vertex]; //
                for (int i = 0; i < vertex; i++)
                {
                    graph[i] = new List<int>();
                }
            }

            public override bool CheckConnect(int from, int to)
            {
                return graph[from].Contains(to);
            }
            public override void Connect(int from, int to)
            {
                graph[from].Add(to);
            }
            public override void Disconnect(int from, int to)
            {
                graph[from].Remove(to);
            }
        }



    }
}
