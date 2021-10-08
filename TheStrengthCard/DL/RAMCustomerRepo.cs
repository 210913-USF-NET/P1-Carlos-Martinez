using System;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace DL
{
    public sealed class RAMCustomerRepo 
    {
        private static RAMCustomerRepo _instance;
        private static List<Customer> _customers;
        private RAMCustomerRepo()
        {
            _customers = new List<Customer>()
            {
                new Customer()
                {
                    Name = "Tenzin",
                    Address = "123",
                    Email = "1234"

                }
            };
        }

        public static RAMCustomerRepo GetInstance()
        {
            if (_instance == null)
            {
                _instance = new RAMCustomerRepo();
            }

            return _instance;
        }

        /// <summary>
        ///   Adds a new restaurant to the json file.
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public Customer AddCustomer(Customer customer)
        {
            // _customers.Add(customer);
            return customer;
        }
        public Customer GetCustomer(string email)
        {
            foreach (var customer in _customers)
            {
                if (customer.Email.Equals(email))
                {
                    return customer;
                }
            }
            return null;
        }



        public void DeleteCustomer(string email)
        {
            Customer customer = GetCustomer(email);
            if (_customers != null)
            {
                _customers.Remove(customer);
            }
        }

        public List<Customer> GetAllCustomers()
        {
            return _customers;
        }

        public Customer UpdateCustomer(Customer customerToUpdate)
        {
            _customers.Add(customerToUpdate);
            return customerToUpdate;

        }

        public Customer AddAnOrder(Order order)
        {
            throw new Exception();
        }

        public List<Customer> SearchCustomer(string queryStr)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public List<Order> GetAllOrders()
        {
            throw new NotImplementedException();
        }
    }
}