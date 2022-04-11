using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Service.Enums
{
    public abstract class Enumeration 
    {
        protected Enumeration()
        {
        }

        protected Enumeration(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
    }

}
