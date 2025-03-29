using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hands_ON11
{
    enum NodeColor { Red, Black }

    class Node
    {
        public int Key;
        public Node Left, Right, Parent;
        public int Height;
        public NodeColor Color;
        public Node(int key)
        {
            Key = key;
            Left = Right = Parent = null;
            Color = NodeColor.Red;
            Height = 1;

        }
    }
}
