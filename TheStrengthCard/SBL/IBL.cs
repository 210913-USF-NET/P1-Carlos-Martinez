using System;
using System.Collections.Generic;
using System.Net.Security;
using Models;

namespace StoreBL
{
    public interface IBL
    {
        List<Customer> GetAllCustomers();
        Customer AddCustomer(Customer customer);
        StoreFront AddStore(StoreFront storeFront);
        Order AddOrder(Order order);
        Product AddProduct(Product product);

        LineItems AddLineItem(LineItems itemToAdd);

        // List<LineItems> AddLineItems(List<LineItems> lineItems);
        Customer GetCustomer(string name);
        List<Inventory> GetInventoriesByStoreId(int storeId);
        Customer UpdateCustomer(Customer customerToUpdate);
        Product UpdateProduct(Product productToUpdate);

        Inventory UpdateInventory(Inventory inventoryToUpdate);

        Order UpdateOrder(Order orderToUpdate);
        void DeleteCustomer(string email);
        List<Customer> SearchCustomer(string quertStr);
        List<Product> GetAllProducts();

        List<Order> GetAllOrders();
        List<StoreFront> GetAllStores();
        List<Inventory> GetAllInventories();
        StoreFront SelectStore(int id);
        List<LineItems> GetLineItems();

        // List<LineItems> GetLineItemsByOrderId(int OrderId);

        decimal CalculateTotal(Order orderToCalculate);

    }
}