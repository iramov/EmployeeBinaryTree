namespace BinaryTreeConsoleApplication
{
    using System;
    using System.Collections.Generic;

    public class ReadFromConsole
    {
        /// <summary>
        /// Method for searching a Dictionary with Employees for the employee without a boss
        /// </summary>
        /// <param name="employees">Dictionary(boss, subordinates) with all the employees</param>
        /// <returns>The employee without a boss</returns>
        private Employee SearchingForTheRoot(IDictionary<Employee, List<Employee>> employees)
        {
            Employee root = new Employee();
            foreach (KeyValuePair<Employee, List<Employee>> pair in employees)
            {
                var employee = pair.Key;
                if (employee.HasBoss == false)
                {
                    root = employee;
                    break;
                }
            }
            return root;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeOne">First searched employee</param>
        /// <param name="employeeTwo">Second searched employee</param>
        /// <param name="employees">Dictionary(boss, subordinates) with all the employees</param>
        /// <param name="root">The employee without manager</param>
        public void Read(Employee employeeOne, Employee employeeTwo, IDictionary<Employee, List<Employee>> employees,ref Employee root)
        {
            int countingTheNodes = 0;
            //Algorithm for reading boss - subordinate
            Console.WriteLine("Please enter the employee tree relations: (To exit type end)");
            while (true)
            {
                string line = Console.ReadLine();
                if (line == "end")
                {
                    break;
                }

                //Splitting the input line and getting only the meaningfull records
                char[] splitters = {' ', ',', '-'};
                string[] words = line.Split(splitters, StringSplitOptions.RemoveEmptyEntries);

                //
                if (words.Length > 0)
                {
                    //The first word in the line is the boss name and the second is the subordinate ones
                    Employee boss = new Employee();
                    boss.FirstName = words[0];
                    Employee subordinate = new Employee();
                    subordinate.FirstName = words[1];
                    subordinate.HasBoss = true;

                    if (employees.ContainsKey(boss) && employees[boss].Count == 2)
	                {
	                	 Console.WriteLine("You cannot enter more then 2 childs for this parent");
	                }
                    else
	                {
                        //After finding a boss in the Dictionary and inserting his subordinate the flag will become 1, 
                        //else there will be new boss record
                        int flagFound = 0;
                        foreach (KeyValuePair<Employee, List<Employee>> pair in employees)
                        {
                            //Checking if the subordinate is not boss in some previous input
                            if (pair.Key.FirstName == subordinate.FirstName)
                            {
                                pair.Key.HasBoss = true;
                            }

                            //If the current pair-boss has only 1 subordinate
                            if (pair.Value.Count == 1)
                            {
                                //checking if the current inputed boss isn't subordinate of someone else
                                if(pair.Value[0].FirstName == boss.FirstName)
                                {
                                    boss.HasBoss = true;
                                }
                            }

                            //If the current pair-boss has only 2 subordinates 
                            if (pair.Value.Count == 2)
                            {
                                //checking if the current inputed boss isn't subordinate of someone else
                                if((pair.Value[0].FirstName == boss.FirstName) || (pair.Value[1].FirstName == boss.FirstName))
                                {
                                    boss.HasBoss = true;
                                }
                            }

                            //If the boss is already entered in the Dictionary only the subordinate is added in
                            if (pair.Key.FirstName == boss.FirstName)
                            {
                                pair.Value.Add(subordinate);
                                flagFound++;
                            }
                        }

                        //Entering a new record in the dictionary with 1 boss and 1 subordinate
                        if (flagFound == 0)
                        {
                            List<Employee> subordinates = new List<Employee>();
                            subordinates.Add(subordinate);
                            employees.Add(boss, subordinates);
                        }

                        //counting the entered nodes in the dictionary for the binary tree check
                        countingTheNodes++;
	                }  
                }
                
            }
            if (countingTheNodes == 1)
            {
                Console.WriteLine("You've entered non binary tree!");
                employees.Clear();  
            }
            else
            {
                //Method that returns the root(employee without boss)
                root = SearchingForTheRoot(employees);
            }
            
        }
    }
}
