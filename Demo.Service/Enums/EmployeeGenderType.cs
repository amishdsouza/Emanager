using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Service.Enums
{
    public class EmployeeGenderType : Enumeration
    {
        public static EmployeeGenderType Male = new EmployeeGenderType(1, "Male");
        public static EmployeeGenderType Female = new EmployeeGenderType(2, "Female");

        public EmployeeGenderType(int id, string name) : base(id, name)
        {

        }

        public static IEnumerable<EmployeeGenderType> List() => new[] { Male, Female };
    }
}
