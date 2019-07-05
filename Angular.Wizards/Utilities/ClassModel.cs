using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angular.Wizards.Utilities
{
    internal class ClassModel : IComparable<ClassModel>
    {
        public string FullFilePath { get; set; }
        public string ImportPath { get; set; }
        public string Name { get; set; }

        public int CompareTo(ClassModel other)
        {
            return Name.CompareTo(other.Name);
        }
    }
}
