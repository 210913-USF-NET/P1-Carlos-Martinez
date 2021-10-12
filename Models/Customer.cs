using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace Models
{
    public class Customer
    {
        // default constructor
        public Customer() 
        {
            // Start every customer out with 30 dollars. 
            Credit = 30;
        }

        // constructor w/ Name
        public Customer(string Username, string Password) : this()
        {
            this.Username = Username;
            this.Password = Password;
        }

        public Customer(Customer customer)
        {
            this.Id = customer.Id;
            this.Username = customer.Username;
            this.Password = customer.Password;
            this.Credit = customer.Credit;
            this.CustomerOrders = customer.CustomerOrders;
        }

        // properties
        public int Id { get; set; }
        //[Required] public string Username { get; set; }
        private string _name;
        [Required] public string Username
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
        private string _pass;
        [Required] public string Password
        {
            get
            {
                return _pass;
            }
            set
            {
                if (value?.Length == 0)
                {
                    Exception e = new Exception("Customer password can't be empty!");
                    throw e;
                }
                else
                {
                    _pass = value;
                }
            }
        }
        public int Credit { get; set; }
        public List<Orders> CustomerOrders { get; set; }

        public override string ToString()
        {
            return $"Username: {this.Username}, Credit: ${this.Credit}.00, Order Count: {this.CustomerOrders.Count}";
        }
    }
}