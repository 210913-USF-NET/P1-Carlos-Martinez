using System;
using System.Collections.Generic;
using System.Net.Security;
using Models;

namespace SBL
{
    public interface IBL
    {
        public Object AddObject(Object thing);
        public void UpdateObject(Object thing);
        public void RemoveObject(Object thing);
        public Customer GetOneCustomer(int Id);
        public Customer GetOneCustomer(string username);
        public List<Customer> GetAllCustomers();
        public StoreFront GetOneStoreFront(int Id);
        public StoreFront GetOneStoreFront(string storeName);
        List<StoreFront> GetAllStoreFronts();

        // Password
        public string Hash(string password);
        public bool Verify(string password, string hash);
    }
}