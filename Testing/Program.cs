using System;
using Common;

namespace Testing
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            DisjointSetsDataStructure sets = new DisjointSetsDataStructure(5);

            sets.Union(0, 1);
            sets.Union(0, 2);
            sets.Union(3, 4);
            sets.Union(2, 3);
            
            if (sets.FindSet(0) != sets.FindSet(4))
                throw new Exception();
        }
    }
}