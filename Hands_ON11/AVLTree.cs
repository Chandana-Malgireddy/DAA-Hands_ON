using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hands_ON11
{
    class AVLTree
    {
        public Node Root;
        public void Insert(int key)
        {
            Root = InsertRec(Root, key);
        }
        private Node InsertRec(Node node, int key)
        {
            if (node == null) return new Node(key);
            if (key < node.Key)
                node.Left = InsertRec(node.Left, key);
            else if (key > node.Key)
                node.Right = InsertRec(node.Right, key);
            else 
                return node;
            node.Height = 1 + Math.Max(Height(node.Left), Height(node.Right));

            return Balance(node);
        }
        public void Delete(int key)
        {
            Root = DeleteRec(Root, key);
        }
        private Node DeleteRec(Node node, int key)
        {
            if (node == null) return node;

            if (key < node.Key)
                node.Left = DeleteRec(node.Left, key);
            else if (key > node.Key)
                node.Right = DeleteRec(node.Right, key);
            else
            {
                if (node.Left == null || node.Right == null)
                    node = (node.Left != null) ? node.Left : node.Right;
                else
                {
                    node.Key = MinValue(node.Right);
                    node.Right = DeleteRec(node.Right, node.Key);
                }
            }
            if (node == null)
                return node;

            node.Height = 1 + Math.Max(Height(node.Left), Height(node.Right));
            return Balance(node);
        }
        private Node Balance(Node node)
        {
            if (node == null) return node;
            int balance = GetBalance(node);
            if (balance > 1 && GetBalance(node.Left) >= 0)
                return RotateRight(node);
            if (balance > 1 && GetBalance(node.Left) < 0)
            {
                node.Left = RotateLeft(node.Left);
                return RotateRight(node);
            }
            if (balance < -1 && GetBalance(node.Right) <= 0)
                return RotateLeft(node);
            if (balance < -1 && GetBalance(node.Right) > 0)
            {
                node.Right = RotateRight(node.Right);
                return RotateLeft(node);
            }
            return node;
        }

        private Node RotateRight(Node y)
        {
            Node x = y.Left;
            y.Left = x.Right;
            x.Right = y;
            y.Height = 1 + Math.Max(Height(y.Left), Height(y.Right));
            x.Height = 1 + Math.Max(Height(x.Left), Height(x.Right));
            return x;
        }
        private Node RotateLeft(Node x)
        {
            Node y = x.Right;
            x.Right = y.Left;
            y.Left = x;
            x.Height = 1 + Math.Max(Height(x.Left), Height(x.Right));
            y.Height = 1 + Math.Max(Height(y.Left), Height(y.Right));
            return y;
        }
        private int Height(Node node)
        {
            return node == null ? 0 : node.Height;
        }
        private int GetBalance(Node node)
        {
            return node == null ? 0 : Height(node.Left) - Height(node.Right);
        }
        private int MinValue(Node node)
        {
            int minValue = node.Key;
            while (node.Left != null)
            {
                minValue = node.Left.Key;
                node = node.Left;
            }
            return minValue;
        }
        public void Inorder()
        {
            InorderRec(Root);
            Console.WriteLine();
        }

        private void InorderRec(Node root)
        {
            if (root != null)
            {
                InorderRec(root.Left);
                Console.Write(root.Key + " ");
                InorderRec(root.Right);
            }
        }
    }

}
