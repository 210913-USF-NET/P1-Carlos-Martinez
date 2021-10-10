namespace Models
{
    public class LineItem
    {
        public LineItem(){}
        public LineItem(int OrderId, Product Product, int Quantity)
        {
            this.OrderId = OrderId;
            this.Product = Product;
            this.Quantity = Quantity;
        }
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}