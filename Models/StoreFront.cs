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

        public string StoreName { get; set; }
        public List<Inventory> storeInventory { get; set; }
        public List<Orders> storeOrders { get; set; }

        public override string ToString()
        {
            return $"Id: {this.Id}, Name: {this.StoreName}";
        }
    }
}