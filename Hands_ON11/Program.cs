namespace Hands_ON11
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            BinarySearchTree bst = new BinarySearchTree();
            bst.Insert(50);
            bst.Insert(30);
            bst.Insert(70);
            bst.Insert(20);
            bst.Insert(40);
            bst.Insert(60);
            bst.Insert(80);
            Console.WriteLine("Inorder traversal after insertions:");
            bst.Inorder();
            bst.Delete(50);
            Console.WriteLine("Inorder traversal after deletions:");
            bst.Inorder();

            AVLTree avl = new AVLTree();
            avl.Insert(30);
            avl.Insert(20);
            avl.Insert(10);
            avl.Insert(5);
            avl.Insert(15);
            avl.Insert(25);
            avl.Insert(40);
            Console.WriteLine("Inorder traversal after insertions:");
            avl.Inorder(); 
            avl.Delete(20);
            Console.WriteLine("Inorder traversal after deleting 20:");
            avl.Inorder();

            RedBlackTree rbt = new RedBlackTree();
            rbt.Insert(50);
            rbt.Insert(30);
            rbt.Insert(70);
            rbt.Insert(20);
            rbt.Insert(40);
            rbt.Insert(60);
            rbt.Insert(80);
            Console.WriteLine("Inorder traversal of Red-Black Tree:");
            rbt.Inorder(); 
            Console.WriteLine("Red-Black Tree Structure:");
            rbt.PrintTree();
            rbt.Delete(40);
            Console.WriteLine("\nInorder traversal after deleting 40:");
            rbt.Inorder();
            Console.WriteLine("Red-Black Tree Structure after deletion:");
            rbt.PrintTree();
        }
    }
}