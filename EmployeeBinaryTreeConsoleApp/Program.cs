namespace BinaryTreeConsoleApplication
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            //constructing the main fields
            var readFromConsole = new ReadFromConsole();
            var employeeOne = new Employee();
            var employeeTwo = new Employee();
            var root = new Employee();
            var employees = new Dictionary<Employee, List<Employee>>();

            //Filling the fields with data from the console input
            readFromConsole.Read(employeeOne, employeeTwo, employees,ref root);

            if (employees.Count == 0)
            {
                Console.WriteLine("You didn't enter the tree!");
            }
            else
            {
                //Printing the root of Tree to check, if we entered the tree right.
                if (employees.ContainsKey(root))
                {
                    Console.WriteLine("Name of the ROOT: " + root.FirstName);
                }

                //Taking the subordinates of the root of the tree for building the EmployeeTree
                //Creating a tree using the recursiveTreeBuilder(root, root.left/root.right, dictianary with the employees)
                List<Employee> subordinates = employees[root];
                BinaryTree<Employee> employeeTree = new BinaryTree<Employee>(root, TreeBuilder.recursiveTreeBuilder(subordinates[0], employees),
                                                                                    TreeBuilder.recursiveTreeBuilder(subordinates[1], employees));
                //Printing the tree after the creation
                Console.WriteLine("Printing the builded tree");
                employeeTree.PrintInorder();

                //Starting the loop for searching LeastCommonAncestor(LCA) of two employees
                string line = "";
                while (true)
                {

                    Console.WriteLine("\nPlease enter the first name of the first employee whose boss you search:");
                    employeeOne.FirstName = Console.ReadLine();
                    Console.WriteLine("Please enter the first name of the second employee whose boss you search:");
                    employeeTwo.FirstName = Console.ReadLine();

                    BinaryTreeNode<Employee> employeeOneNode = new BinaryTreeNode<Employee>(employeeOne);
                    BinaryTreeNode<Employee> employeeTwoNode = new BinaryTreeNode<Employee>(employeeTwo);

                    //Calling the LCA for the builded tree with the (root, firstSearched, secondSearched) and returning their Boss
                    BinaryTreeNode<Employee> searchedBoss = employeeTree.LeastCommonAncestor(employeeOneNode, employeeTwoNode);

                    if (searchedBoss == null)
                    {
                        Console.WriteLine("Your employees doesn't have common ancestor");
                    }
                    else
                    {
                        Console.WriteLine("The LCA of the two employees is: " + searchedBoss.Value.FirstName);
                    }


                    Console.WriteLine("If you want to exit the search write END, else press Enter to begin new search");
                    line = Console.ReadLine();
                    if (line == "END")
                    {
                        break;
                    }

                }
            }
            
            Console.WriteLine("\nTo exit press any key!");
            Console.ReadKey();
        }
    }
}
