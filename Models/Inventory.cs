namespace Models
{
    public class Inventory
    {
        // Each Inventory is one line in an Inventories object
        
        // constructors
        public Inventory(){}
        public Inventory(Product Product, int StoreFrontId, int Quantity)
        {
            this.StoreFrontId = StoreFrontId;
            this.Quantity = Quantity;
        }

        // properties
        public int Id { get; set; }
        public Product Product { get; set; }
        public int StoreFrontId { get; set; }
        public int Quantity { get; set; }
    }
}