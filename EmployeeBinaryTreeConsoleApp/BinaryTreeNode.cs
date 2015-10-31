using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeConsoleApplication
{
    //Class for the Node of a binary tree with 2 childs and generic value
    public class BinaryTreeNode<T>
    {
        public T Value { get; set; }
        
        private BinaryTreeNode<T> leftChild;

        private BinaryTreeNode<T> rightChild;

        public BinaryTreeNode(T value, BinaryTreeNode<T> leftChild, BinaryTreeNode<T> rightChild) 
        {
            if(value == null)
            {
                throw new ArgumentNullException("You cannot insert null value!");
            }

            this.leftChild = leftChild;
            this.rightChild = rightChild;
            this.Value = value;
        }

        public BinaryTreeNode(T value) : this(value, null, null) 
        {
        }

        //Property for the private field leftChild
        public BinaryTreeNode<T> LeftChild 
        {
            get
            { 
                return this.leftChild; 
            }
            set
            {
                if (value == null)
                {
                    return;
                }

                this.leftChild = value;
            }
        }

        //Property for the private field rightChild
        public BinaryTreeNode<T> RightChild
        {
            get
            {
                return this.rightChild;
            }
            set
            {
                if (value == null)
                {
                    return;
                }

                this.rightChild = value;
            }
        }



    }
}
