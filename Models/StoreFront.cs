using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class StoreFront
    {
        public StoreFront() {}
        
        // constructor w/ Name
        public StoreFront(string name) : this()
        {
            this.StoreName = name;
        }

        // properties
        public int Id { get; set; }

        private string _name;
        [Required] public string StoreName
        {
            get
            {
                return _name;
            }
            set
            {
                if (value?.Length == 0)
                {
                    Exception e = new Exception("Customer name can't be empty!");
                    throw e;
                }
                else
                {
                    _name = value;
                }
            }
        }
        public List<Inventory> storeInventory { get; set; }
        public List<Orders> storeOrders { get; set; }

        public override string ToString()
        {
            return $"Id: {this.Id}, Name: {this.StoreName}";
        }
    }
}