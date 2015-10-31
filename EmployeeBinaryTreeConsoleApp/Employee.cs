using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeConsoleApplication
{
    public class Employee : IEquatable<Employee>
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

        public bool Equals(Employee other)
        {
            return this.FirstName.Equals(other.FirstName);
        }
    }
}
