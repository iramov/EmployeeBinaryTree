using System;
using System.Collections.Generic;
using System.Linq;

namespace BinaryTreeConsoleApplication
{
    public class Employee
    {
        public string FirstName { get; set; }

        public bool HasBoss { get; set; }

        public override string ToString()
        {
            return this.FirstName;
        }

        public override int GetHashCode()
        {
            return FirstName.GetHashCode();
        }

        public override bool Equals(object other)
        {
            var employee = other as Employee;
            if (other == null || employee == null)
            {
                return false;
            }

            return this.FirstName.Equals(employee.FirstName);
        }
    }
}
