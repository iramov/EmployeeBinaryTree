namespace BinaryTreeConsoleApplication
{
    using System.Collections.Generic;

    public class TreeBuilder
    {
        /// <summary>
        /// Static method for building a binary tree and returning it
        /// </summary>
        /// <param name="employee">Current employee(at the start the root)</param>
        /// <param name="employees">Dictionary with employees</param>
        /// <returns>Binary tree</returns>
        public static BinaryTree<Employee> recursiveTreeBuilder(Employee employee, Dictionary<Employee, List<Employee>> employees)
        {
            BinaryTree<Employee> tree;

            //When the node is found the recursion goes deeper
            foreach (var pair in employees)
            {
                //searching for perticular node, so it can build the tree correctly
                if (pair.Key.FirstName == employee.FirstName)
                {
                    //taking the left and right child of this node
                    if (pair.Value.Count == 2)
                    {
                        var employeeLeftSubordinate = pair.Value[0];
                        var employeeRightSubordinate = pair.Value[1];
                        //building the tree recursively by building first the left subtree and then the right
                        tree = new BinaryTree<Employee>(employee, recursiveTreeBuilder(employeeLeftSubordinate, employees),
                                                                   recursiveTreeBuilder(employeeRightSubordinate, employees));
                        return tree;
                    }
                    else
                    {
                        var employeeLeftSubordinate = pair.Value[0];
                        //building the tree recursively by building first the left subtree and then the right
                        tree = new BinaryTree<Employee>(employee, recursiveTreeBuilder(employeeLeftSubordinate, employees),
                                                                   null);
                        return tree;
                    }
                    
                }
            }
            //When it reaches a leaf(node with no children) it returns it as tree with only a root and no children
            return tree = new BinaryTree<Employee>(employee);
        }
    }
}
