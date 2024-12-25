using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleDomen.Models
{
    public class Category
    {
        public int Id { get; protected set; }

        public string Name { get; protected set; }

        public string NameUa { get; protected set; }
    }
}