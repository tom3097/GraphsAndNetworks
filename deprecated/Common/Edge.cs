namespace Common
{
    public struct Edge
    {
        public int U { get; }
        public int V { get; }
        public double Weight { get; }

        public Edge(int u, int v, double weight)
        {
            U = u;
            V = v;
            Weight = weight;
        }
    }
}