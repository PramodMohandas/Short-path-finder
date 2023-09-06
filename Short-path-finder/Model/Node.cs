using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Short_path_finder.Model
{
    public class Node
    {
        public int x, y;
        public bool walkable;
        public Node parent;
        public int gCost; // Cost from start to current node
        public int hCost; //  cost to target node

        public int fCost => gCost + hCost;

        public Node(int x, int y, bool walkable)
        {
            this.x = x;
            this.y = y;
            this.walkable = walkable;
        }
    }

}
