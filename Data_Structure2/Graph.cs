using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Graph
{
    internal class Program
    {
        /************************************************************************
         * 그래프 (Graph)
         * 
         * 정점의 모음과 이 정점을 잇는 간선의 모음의 결합
         * 한 노드에서 출발하여 다시 자기 자신의 노드로 돌아오는 순환구조를 가질 수 있음
         * 간선의 방향성에 따라 단방향 그래프, 양방향 그래프가 있음
         * 간선의 가중치에 따라   연결 그래프, 가중치 그래프가 있음
         ************************************************************************/

        // <인접행렬 그래프>
        // 그래프 내의 각 정점의 인접 관계를 나타내는 행렬
        // 2차원 배열을 [출발지, 도착지] 으로 표현
        // 장점 : 인접여부 접근이 빠름   O(1)
        // 단점 : 메모리 사용량이 많음   O(n^2);

        // 단방향 연결 그래프
        bool[,] graph1 =
        {
            {  true,  true, false, false },
            { false,  true,  true, false },
            {  true, false,  true, false },
            { false,  true,  true, false },
        };

        // 양방향 가중치 그래프 (단절은 높은값으로 표현)
        const int INF = 99999;
        int[,] graph2 =
        {
            {   0,   4, INF, INF },
            {   4,   0,   8,   3 },
            { INF,   8,   0,   3 },
            { INF,   3,   3,   0 }
        };


        // <인접리스트 그래프>
        // 그래프 내의 각 정점의 인접 관계를 표현하는 리스트
        // 인접한 간선만을 리스트에 추가하여 관리
        // 장점 : 메모리 사용량이 적음                         O(n)
        // 단점 : 인접여부를 확인하기 위해 리스트 탐색이 필요  O(n)

        static void Main1(string[] args)
        {
            bool[,] graph2 = new bool[4, 4];

            List<int>[] graph = new List<int>[4];
            for (int i = 0; i < graph.Length; i++)
            {
                graph[i] = new List<int>();
            }

            // 연결 추가
            graph[0].Add(1); graph2[0, 1] = true;
            graph[0].Add(3); graph2[0, 3] = true;
            graph[1].Add(2); graph2[1, 2] = true;
            graph[2].Add(0); graph2[2, 0] = true;

            // 연결 제거
            graph[0].Remove(1); graph2[0, 1] = false;

            // 연결 확인
            graph[0].Contains(1); bool connect = graph2[0, 1];
        }
    }

    public abstract class Graph
    {
        public abstract void Connect(int from, int to);
        public abstract void DisConnect(int from, int to);
        public abstract bool IsConnect(int from, int to);
    }

    public class MatrixGraph : Graph
    {
        private bool[,] graph;

        public MatrixGraph(int vertex)
        {
            graph = new bool[vertex, vertex];
        }

        public override void Connect(int from, int to)
        {
            graph[from, to] = true;
        }

        public override void DisConnect(int from, int to)
        {
            graph[from, to] = false;
        }

        public override bool IsConnect(int from, int to)
        {
            return graph[from, to];
        }
    }

    public class ListGraph : Graph
    {
        private List<int>[] graph;

        public ListGraph(int vertex)
        {
            graph = new List<int>[vertex];
            for (int i = 0; i < vertex; i++)
            {
                graph[i] = new List<int>();
            }
        }

        public override void Connect(int from, int to)
        {
            graph[from].Add(to);
        }

        public override void DisConnect(int from, int to)
        {
            graph[from].Remove(to);
        }

        public override bool IsConnect(int from, int to)
        {
            return graph[from].Contains(to);
        }
    }
}
