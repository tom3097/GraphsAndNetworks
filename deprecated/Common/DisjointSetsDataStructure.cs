namespace Common
{
    public class DisjointSetsDataStructure
    {
        private readonly DisjointSetElement[] _elements;

        public DisjointSetsDataStructure(int size)
        {
            _elements = new DisjointSetElement[size];
            for (int i = 0; i < size; ++i)
            {
                _elements[i] = new DisjointSetElement { Rank = 0, Parent = i };
            }
        }

        public int FindSet(int node)
        {
            if (node == _elements[node].Parent)
                return node;
            _elements[node].Parent = FindSet(_elements[node].Parent);
            return _elements[node].Parent;
        }

        public void Union(int firstNode, int secondNode)
        {
            int firstRoot = FindSet(firstNode);
            int secondRoot = FindSet(secondNode);

            if (_elements[firstRoot].Rank < _elements[secondRoot].Rank)
            {
                _elements[firstRoot].Parent = secondRoot;
            }
            else if (_elements[firstRoot].Rank > _elements[secondRoot].Rank)
            {
                _elements[secondRoot].Parent = firstRoot;
            }
            else
            {
                _elements[secondRoot].Parent = firstRoot;
                _elements[firstRoot].Rank++;
            }
        }

        private struct DisjointSetElement
        {
            public int Rank { get; set; }
            public int Parent { get; set; }
        }
    }
}