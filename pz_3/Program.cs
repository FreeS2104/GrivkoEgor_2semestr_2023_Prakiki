using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz_3
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();
            int posCount = 0, negCount = 0;
            float sr = 0;

            tree.Insert(-1);
            tree.Insert(2); 
            tree.Insert(3); 
            tree.Insert(-4);
            tree.Insert(-5);
            tree.Insert(-6);
            tree.Insert(7); 
            tree.Insert(8); 


            Console.WriteLine("Дерево");
            tree.PrintTree();
            Console.WriteLine();
            tree.CountPosNegNodes(tree.root, ref posCount, ref negCount, ref sr);
            Console.WriteLine("Среднее арифметическое значений полей узлов дерева: {0} (Задание 1)", sr);
            Console.WriteLine("Количество узлов с положительными значениями: {0} (Задание 2)", posCount);
            Console.WriteLine("Количество узлов с отрицательными значениями: {0} (Задание 2)", negCount);
            Console.WriteLine("Количество узлов со всеми значениями: {0} (Задание 3)", posCount + negCount);

            Console.ReadKey();
        }
    }

    public class TreeNode
    {
        public int data;
        public TreeNode left, right;


        public TreeNode(int item)
        {
            data = item;
            left = right = null;
        }
    }


    public class BinaryTree
    {
        public TreeNode root;

        public BinaryTree()
        {
            root = null;
        }


        public virtual void Insert(int data)
        {
            root = InsertRecursive(root, data);
        }


        public TreeNode InsertRecursive(TreeNode current, int data)
        {

            if (current == null)
            {
                current = new TreeNode(data);
                return current;
            }

            if (data < current.data)
            {
                current.left = InsertRecursive(current.left, data);
            }

            else
            {
                current.right = InsertRecursive(current.right, data);
            }
            return current;
        }


        public void CountPosNegNodes(TreeNode node, ref int posCount, ref int negCount, ref float sr)
        {
            if (node == null)
                return;

            if (node.data > 0)
                posCount++;

            else if (node.data < 0)
                negCount++;
            sr = (sr + node.data) / 2;

            CountPosNegNodes(node.left, ref posCount, ref negCount, ref sr);
            CountPosNegNodes(node.right, ref posCount, ref negCount, ref sr);
        }


        public void PrintTree()
        {
            PrintTreeRecursive(root);
        }


        private void PrintTreeRecursive(TreeNode node)
        {
            if (node == null)
                return;


            Console.Write(node.data + " ");

            PrintTreeRecursive(node.left);
            PrintTreeRecursive(node.right);
        }
    }
}
