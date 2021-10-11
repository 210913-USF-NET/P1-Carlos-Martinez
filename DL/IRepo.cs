using System;
using System.Collections.Generic;
using Models;

namespace DL
{
    public interface IRepo
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
        public Product GetOneProduct(int Id);
        public List<Product> GetAllProducts();
    }
}
