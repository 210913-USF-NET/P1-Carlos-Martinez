using System;
using System.Collections.Generic;
using Models;
using System.IO;
using System.Text.Json;
using System.Linq;
using Serilog;

namespace DL
{
    public class CustomerFileRepo
    {
        private const string filePath = "../DL/Customers.json";

        private string jsonString;

        public Customer AddCustomer(Customer customer)
        {
            Log.Debug("Adding customer, {0}", customer.ToString());
            //Get all customer from the file as Lists
            List<Customer> allCustomer = GetAllCustomers();
            allCustomer.Add(customer);

            //serialize 
            jsonString = JsonSerializer.Serialize(allCustomer);
            File.WriteAllText(filePath, jsonString);
            return customer;
        }

        public void DeleteCustomer(string email)
        {
            throw new System.NotImplementedException();
        }

        public List<Customer> GetAllCustomers()
        {
            //read the file from the file path
            jsonString = File.ReadAllText(filePath);
            //translate the serialized string into List<Customer> object!
            return JsonSerializer.Deserialize<List<Customer>>(jsonString);
        }

        public Customer UpdateCustomer(Customer customerToUpdate)
        {
            List<Customer> allCustomers = GetAllCustomers();
            int customerIndex = GetAllCustomers().FindIndex(c => c.Equals(customerToUpdate));
            

            //Update the customer in the list
            allCustomers[customerIndex] = customerToUpdate;

            jsonString = JsonSerializer.Serialize(allCustomers);

            File.WriteAllText(filePath, jsonString);


            return customerToUpdate;
        }


        public Customer GetCustomer(string email)
        {
            throw new System.NotImplementedException();
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