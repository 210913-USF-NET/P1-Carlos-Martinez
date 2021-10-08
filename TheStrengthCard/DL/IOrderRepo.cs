using System.Collections.Generic;
using Models;

namespace DL
{
    public interface IOrderRepo
    {
        Order AddOrder(Order order);
        Order GetOrder(Order order);

        List<Order> GetAllOrders();

        void DeleteOrder(Order orderToDelete);

        Order UpdateOrder(Order orderToUpdate);
    }
}