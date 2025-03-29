using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hands_ON11
{
    class RedBlackTree
    {
        private Node Root;
        private Node TNULL;
        public RedBlackTree()
        {
            TNULL = new Node(0);
            TNULL.Color = NodeColor.Black;
            TNULL.Left = TNULL.Right = null;
            Root = TNULL;
        }
        private void RotateLeft(Node x)
        {
            Node y = x.Right;
            x.Right = y.Left;
            if (y.Left != TNULL)
                y.Left.Parent = x;
            y.Parent = x.Parent;
            if (x.Parent == null)
                Root = y;
            else if (x == x.Parent.Left)
                x.Parent.Left = y;
            else
                x.Parent.Right = y;
            y.Left = x;
            x.Parent = y;
        }
        private void RotateRight(Node x)
        {
            Node y = x.Left;
            x.Left = y.Right;
            if (y.Right != TNULL)
                y.Right.Parent = x;
            y.Parent = x.Parent;
            if (x.Parent == null)
                Root = y;
            else if (x == x.Parent.Right)
                x.Parent.Right = y;
            else
                x.Parent.Left = y;
            y.Right = x;
            x.Parent = y;
        }
        public void Insert(int key)
        {
            Node node = new Node(key) { Parent = null, Left = TNULL, Right = TNULL, Color = NodeColor.Red };
            Node y = null;
            Node x = Root;

            while (x != TNULL)
            {
                y = x;
                if (node.Key < x.Key)
                    x = x.Left;
                else
                    x = x.Right;
            }

            node.Parent = y;
            if (y == null)
                Root = node;
            else if (node.Key < y.Key)
                y.Left = node;
            else
                y.Right = node;

            if (node.Parent == null)
            {
                node.Color = NodeColor.Black;
                return;
            }

            if (node.Parent.Parent == null)
                return;

            FixInsert(node);
        }
        private void FixInsert(Node k)
        {
            while (k.Parent.Color == NodeColor.Red)
            {
                if (k.Parent == k.Parent.Parent.Left)
                {
                    Node u = k.Parent.Parent.Right;
                    if (u.Color == NodeColor.Red)
                    {
                        k.Parent.Color = NodeColor.Black;
                        u.Color = NodeColor.Black;
                        k.Parent.Parent.Color = NodeColor.Red;
                        k = k.Parent.Parent;
                    }
                    else
                    {
                        if (k == k.Parent.Right)
                        {
                            k = k.Parent;
                            RotateLeft(k);
                        }
                        k.Parent.Color = NodeColor.Black;
                        k.Parent.Parent.Color = NodeColor.Red;
                        RotateRight(k.Parent.Parent);
                    }
                }
                else
                {
                    Node u = k.Parent.Parent.Left;
                    if (u.Color == NodeColor.Red)
                    {
                        k.Parent.Color = NodeColor.Black;
                        u.Color = NodeColor.Black;
                        k.Parent.Parent.Color = NodeColor.Red;
                        k = k.Parent.Parent;
                    }
                    else
                    {
                        if (k == k.Parent.Left)
                        {
                            k = k.Parent;
                            RotateRight(k);
                        }
                        k.Parent.Color = NodeColor.Black;
                        k.Parent.Parent.Color = NodeColor.Red;
                        RotateLeft(k.Parent.Parent);
                    }
                }
                if (k == Root)
                    break;
            }
            Root.Color = NodeColor.Black;
        }
        public void Delete(int key)
        {
            Node z = Search(Root, key);
            if (z == TNULL)
            {
                Console.WriteLine("Node not found.");
                return;
            }

            Node y = z;
            Node x;
            NodeColor originalColor = y.Color;

            if (z.Left == TNULL)
            {
                x = z.Right;
                Transplant(z, z.Right);
            }
            else if (z.Right == TNULL)
            {
                x = z.Left;
                Transplant(z, z.Left);
            }
            else
            {
                y = Minimum(z.Right);
                originalColor = y.Color;
                x = y.Right;
                if (y.Parent == z)
                    x.Parent = y;
                else
                {
                    Transplant(y, y.Right);
                    y.Right = z.Right;
                    y.Right.Parent = y;
                }

                Transplant(z, y);
                y.Left = z.Left;
                y.Left.Parent = y;
                y.Color = z.Color;
            }

            if (originalColor == NodeColor.Black)
                FixDelete(x);
        }
        private void FixDelete(Node x)
        {
            while (x != Root && x.Color == NodeColor.Black)
            {
                if (x == x.Parent.Left)
                {
                    Node w = x.Parent.Right;
                    if (w.Color == NodeColor.Red)
                    {
                        w.Color = NodeColor.Black;
                        x.Parent.Color = NodeColor.Red;
                        RotateLeft(x.Parent);
                        w = x.Parent.Right;
                    }

                    if (w.Left.Color == NodeColor.Black && w.Right.Color == NodeColor.Black)
                    {
                        w.Color = NodeColor.Red;
                        x = x.Parent;
                    }
                    else
                    {
                        if (w.Right.Color == NodeColor.Black)
                        {
                            w.Left.Color = NodeColor.Black;
                            w.Color = NodeColor.Red;
                            RotateRight(w);
                            w = x.Parent.Right;
                        }

                        w.Color = x.Parent.Color;
                        x.Parent.Color = NodeColor.Black;
                        w.Right.Color = NodeColor.Black;
                        RotateLeft(x.Parent);
                        x = Root;
                    }
                }
                else
                {
                    Node w = x.Parent.Left;
                    if (w.Color == NodeColor.Red)
                    {
                        w.Color = NodeColor.Black;
                        x.Parent.Color = NodeColor.Red;
                        RotateRight(x.Parent);
                        w = x.Parent.Left;
                    }

                    if (w.Right.Color == NodeColor.Black && w.Left.Color == NodeColor.Black)
                    {
                        w.Color = NodeColor.Red;
                        x = x.Parent;
                    }
                    else
                    {
                        if (w.Left.Color == NodeColor.Black)
                        {
                            w.Right.Color = NodeColor.Black;
                            w.Color = NodeColor.Red;
                            RotateLeft(w);
                            w = x.Parent.Left;
                        }

                        w.Color = x.Parent.Color;
                        x.Parent.Color = NodeColor.Black;
                        w.Left.Color = NodeColor.Black;
                        RotateRight(x.Parent);
                        x = Root;
                    }
                }
            }
            x.Color = NodeColor.Black;
        }
        private void Transplant(Node u, Node v)
        {
            if (u.Parent == null)
                Root = v;
            else if (u == u.Parent.Left)
                u.Parent.Left = v;
            else
                u.Parent.Right = v;

            v.Parent = u.Parent;
        }
        private Node Minimum(Node node)
        {
            while (node.Left != TNULL)
                node = node.Left;
            return node;
        }
        private Node Search(Node node, int key)
        {
            if (node == TNULL || key == node.Key)
                return node;

            if (key < node.Key)
                return Search(node.Left, key);
            else
                return Search(node.Right, key);
        }
        public void Inorder()
        {
            InorderRec(Root);
            Console.WriteLine();
        }

        private void InorderRec(Node node)
        {
            if (node != TNULL)
            {
                InorderRec(node.Left);
                Console.Write(node.Key + " ");
                InorderRec(node.Right);
            }
        }
        public void PrintTree()
        {
            PrintTreeRec(Root, "", true);
        }

        private void PrintTreeRec(Node node, string indent, bool last)
        {
            if (node != TNULL)
            {
                Console.Write(indent);
                if (last)
                {
                    Console.Write("R----");
                    indent += "   ";
                }
                else
                {
                    Console.Write("L----");
                    indent += "|  ";
                }

                string sColor = (node.Color == NodeColor.Red) ? "RED" : "BLACK";
                Console.WriteLine(node.Key + "(" + sColor + ")");
                PrintTreeRec(node.Left, indent, false);
                PrintTreeRec(node.Right, indent, true);
            }
        }
    }


}
