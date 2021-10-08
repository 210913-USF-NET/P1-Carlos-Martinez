using System.Collections.Generic;
using Model = Models;
using Entity = DL.Entities;
using System.Linq;

namespace DL
{
    public class DBOrderRepo : IOrderRepo
    {
        private Entity.P0TenzinStoreContext _context;

        public DBOrderRepo(Entity.P0TenzinStoreContext context)
        {
            _context = context;
        }
        public Model.Order AddOrder(Model.Order order)
        {
            Entity.Order orderToAdd = new Entity.Order()
            {
                Total = order.Total
            };

            orderToAdd = _context.Add(orderToAdd).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
            return new Model.Order
            {
                Id = orderToAdd.Id,
                Total = (decimal)orderToAdd.Total
            };
        }

        public void DeleteOrder(Model.Order orderToDelete)
        {
            throw new System.NotImplementedException();
        }

        public List<Model.Order> GetAllOrders()
        {
            return _context.Orders.Select(order => new Model.Order()
            {
                Id = order.Id,
                Total = (decimal)order.Total
            }).ToList();
        }

        public Model.Order GetOrder(Model.Order order)
        {
            throw new System.NotImplementedException();
        }

        public Model.Order UpdateOrder(Model.Order orderToUpdate)
        {
            Entity.Order updateOrder = new Entity.Order()
            {
                Id = orderToUpdate.Id,
                Total = orderToUpdate.Total
            };

            updateOrder = _context.Orders.Update(updateOrder).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new Model.Order()
            {
                Id = updateOrder.Id,
                Total = (decimal)updateOrder.Total
            };
        }
    }
}