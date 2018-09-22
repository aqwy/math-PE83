using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE83
{
    class Vertex
    {
        public string vertName;
        public bool isInTree;
        public Vertex(string vname)
        {
            vertName = vname;
            isInTree = false;
        }
    }
}
