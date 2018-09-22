using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE83
{
    class Vertex
    {
        public char lable;
        public bool isInTree;
        public Vertex(char l)
        {
            lable = l;
            isInTree = false;
        }
    }
}
