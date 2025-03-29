using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hands_ON11
{
    class BinarySearchTree
    {
        public Node Root;
        public BinarySearchTree() { Root = null; }

        public void Insert(int key)
        {
            Root = InsertRec(Root, key);
        }

        private Node InsertRec(Node root, int key)
        {
            if (root == null)
            {
                root = new Node(key);
                return root;
            }
            if (key < root.Key)
                root.Left = InsertRec(root.Left, key);
            else if (key > root.Key)
                root.Right = InsertRec(root.Right, key);
            return root;
        }
        public void Delete(int key)
        {
            Root = DeleteRec(Root, key);
        }

        private Node DeleteRec(Node root, int key)
        {
            if (root == null) return root;
            if (key < root.Key)
                root.Left = DeleteRec(root.Left, key);
            else if (key > root.Key)
                root.Right = DeleteRec(root.Right, key);
            else
            {
                if (root.Left == null) return root.Right;
                else if (root.Right == null) return root.Left;
                root.Key = MinValue(root.Right);
                root.Right = DeleteRec(root.Right, root.Key);
            }
            return root;
        }
        private int MinValue(Node root)
        {
            int minValue = root.Key;
            while (root.Left != null)
            {
                minValue = root.Left.Key;
                root = root.Left;
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
