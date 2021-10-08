using System;
using System.Collections.Generic;
using Models;
using DL;
using System.Text.RegularExpressions;

namespace StoreBL
{
    public class BL : IBL

    {
        private ICustomerRepo _repo;

        public BL(ICustomerRepo repo)
        {
            _repo = repo;
        }
        public List<Customer> GetAllCustomers()
        {
            return _repo.GetAllCustomers();
        }

        public Customer AddCustomer(Customer customer)
        {
            return _repo.AddCustomer(customer);
        }

        public Customer UpdateCustomer(Customer customerToUpdate)
        {
            return _repo.UpdateCustomer(customerToUpdate);
        }

        public List<Customer> SearchCustomer(string quertStr)
        {
            return _repo.SearchCustomer(quertStr);
        }

        public List<Product> GetAllProducts()
        {
            return _repo.GetAllProducts();
        }

        public List<Order> GetAllOrders()
        {
            return _repo.GetAllOrders();
        }

        public List<StoreFront> GetAllStores()
        {
            return _repo.GetAllStores();
        }

        public List<LineItems> GetLineItems()
        {
            return _repo.GetLineItems();
        }

        public void DeleteCustomer(string email)
        {
            _repo.DeleteCustomer(email);
        }

        public Product UpdateProduct(Product productToUpdate)
        {
            return _repo.UpdateProduct(productToUpdate);
        }

        public StoreFront SelectStore(int id)
        {
            return _repo.SelectStore(id);
        }

        public StoreFront AddStore(StoreFront storeFront)
        {
            return _repo.AddStore(storeFront);
        }

        public decimal CalculateTotal(Order orderToCalculate)
        {
            decimal total = 0;
            List<LineItems> lineItems = orderToCalculate.LineItems;


            foreach (LineItems item in lineItems)
            {
                int productId = item.ProductId;
                Product product = _repo.GetProductById(productId);

                total += product.Price;
                if(item.Quantity > 1)
                {
                    total *= item.Quantity;
                }
            
            }

            return total;
        }

        public Order AddOrder(Order order)
        {
            return _repo.AddAnOrder(order);
        }

        public Product AddProduct(Product product)
        {
            return _repo.AddProduct(product);
        }

        public List<Inventory> GetAllInventories()
        {
            return _repo.GettAllInventories();
        }

        public Customer GetCustomer(string name)
        {
            return _repo.GetCustomer(name);
        }

        public List<Inventory> GetInventoriesByStoreId(int storeId)
        {
            return _repo.GetInventoriesByStoreId(storeId);
        }

        public LineItems AddLineItem(LineItems itemToAdd)
        {
            return _repo.AddLineItem(itemToAdd);
        }

        public Inventory UpdateInventory(Inventory inventoryToUpdate)
        {
            return _repo.UpdateInventory(inventoryToUpdate);
        }

        public Order UpdateOrder(Order orderToUpdate)
        {
            return _repo.UpdateOrder(orderToUpdate);
        }

        // public List<LineItems> AddLineItems(List<LineItems> lineItems)
        // {
        //     return _repo.AddLineItems(lineItems);
        // }

        // public List<LineItems> GetLineItemsByOrderId(int orderId)
        // {
        //     return _repo.GetLineItemsById(orderId);
        // }
    }
}
