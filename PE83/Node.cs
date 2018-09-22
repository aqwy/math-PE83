using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE83
{
    class Node
    {
        public Node(int weight, int i, int j)
        {
            Weight = weight;
            I = i;
            J = j;
            Distance = long.MaxValue;
        }
        public int Weight { get; }
        public int I { get; }
        public int J { get; }
        public long Distance { get; set; }

        private sealed class DistanceRelationalComparer : Comparer<Node>
        {
            public override int Compare(Node x, Node y)
            {
                if (ReferenceEquals(x, y)) return 0;
                if (ReferenceEquals(null, y)) return 1;
                if (ReferenceEquals(null, x)) return -1;
                return x.Distance.CompareTo(y.Distance);
            }
        }
        public static Comparer<Node> DistanceComparer { get; } = new DistanceRelationalComparer();

    }
}
