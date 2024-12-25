using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleDomen.Models
{
    public class Product
    {
        public Product(string name, string nameUa, int categoryId)
        {
            NameUa = nameUa;
            Name = name;
            CategoryId = categoryId;
        }

        public Product()
        {
        }

        public int Id { get; protected set; }

        public string Name { get; protected set; }

        public string NameUa { get; protected set; }

        public int CategoryId { get; protected set; }

        public virtual Category Category { get; protected set; }
    }
}