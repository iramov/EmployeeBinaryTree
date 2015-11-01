using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeConsoleApplication
{
    public class BinaryTree<T>
    {
        private BinaryTreeNode<T> root;

        //Constructor for tree with root and 2 nullable childs
        public BinaryTree(T value, BinaryTree<T> leftChild, BinaryTree<T> rightChild) 
        {
            if (value == null)
            {
                throw new ArgumentNullException("Cannot insert null value!");
            }

            BinaryTreeNode<T> leftChildNode = leftChild != null ? leftChild.root : null;
            BinaryTreeNode<T> rightChildNode = rightChild != null ? rightChild.root : null;

            this.root = new BinaryTreeNode<T>(value, leftChildNode, rightChildNode);
        }

        //Constructor for a tree with root without childs
        public BinaryTree(T value) : this (value, null, null)
        {
        }

        public BinaryTreeNode<T> Root
        {
            get 
            {
                return this.root;
            }
        }

        //Printer for the tree
        private void PrintInorder(BinaryTreeNode<T> root)
        {
            if (root == null)
            {
                return;
            }

            PrintInorder(root.LeftChild);

            Console.Write(root.Value + " ");

            PrintInorder(root.RightChild);
        }

        public void PrintInorder()
        {
            PrintInorder(this.root);
            Console.WriteLine();
        }

        // Returns the number of matches of firstEmployee and the second one in the subtree.
        private int CountMatches(BinaryTreeNode<T> root, BinaryTreeNode<T> firstEmployee, BinaryTreeNode<T> secondEmployee)
        {
            if (root == null) 
            {
                return 0;
            }
 
            int matches = CountMatches(root.LeftChild, firstEmployee, secondEmployee) + CountMatches(root.RightChild, firstEmployee, secondEmployee);
            if (root.Value.Equals(firstEmployee.Value) || root.Value.Equals(secondEmployee.Value))
            {
                return 1 + matches;
            }
            else
            {
                return matches;
            }
        }

        //Searching for the LeastCommonAncestor top-bottom counting the matches in each subtree and deciding where to go next left or right
        public BinaryTreeNode<T> LeastCommonSearch(BinaryTreeNode<T> root, BinaryTreeNode<T> firstEmployee, BinaryTreeNode<T> secondEmployee) 
        {
            if (root == null || firstEmployee == null || secondEmployee == null) 
            {
                return null;
            }
            if (root.Value.Equals(firstEmployee.Value) || root.Value.Equals(secondEmployee.Value))
            { 
                return root;
            } 
            int totalMatches = CountMatches(root.LeftChild, firstEmployee, secondEmployee);
            //The searched Nodes are at each side of this Node
            if (totalMatches == 1)
            {
                return root;
            }
            //The searched Nodes are at the left side of this Node and proceeding with the left subtree
            else if (totalMatches == 2)
            {
                return LeastCommonSearch(root.LeftChild, firstEmployee, secondEmployee);
            }
            // totalMatches == 0 going for the right subtree 
            else 
            {
                return LeastCommonSearch(root.RightChild, firstEmployee, secondEmployee);
            }
        }
    }
}
