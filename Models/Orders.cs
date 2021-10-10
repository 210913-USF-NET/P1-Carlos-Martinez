using System;
using System.Collections.Generic;

namespace Models
{
    public class Orders
    {
        public Orders()
        {
            this.Date = DateTime.Now;
        }
        public Orders(int CustomerId, int StoreId, List<LineItem> OrderLines, int Total) : this()
        {
            this.CustomerId = CustomerId;
            this.StoreFrontId = StoreId;
            this.OrderLines = OrderLines;
            this.Total = Total;
        }
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Total { get; set; }
        public List<LineItem> OrderLines { get; set; }
        public int CustomerId { get; set; }
        public int StoreFrontId { get; set; }
    }
}