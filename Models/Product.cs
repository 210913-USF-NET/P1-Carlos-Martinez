using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Product
    {
        public Product() {}

        // constructor w/ Name
        public Product(string name)
        {
            this.Name = name;
        }

        public Product(string name, int Price, string Description) : this(name)
        {
            this.Price = Price;
            this.Description = Description;
        }

        // properties
        public int Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public int Price { get; set; }
        public string Description { get; set; }
        
        public override string ToString()
        {
            return $"Name: {this.Name}, Price: {this.Price}";
        }
    }
}