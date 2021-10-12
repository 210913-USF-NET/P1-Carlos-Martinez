using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Inventory
    {
        // Each Inventory is one line in an Inventories object
        
        // constructors
        public Inventory(){}
        public Inventory(int ProductId, int StoreFrontId, int Quantity)
        {
            this.ProductId = ProductId;
            this.StoreFrontId = StoreFrontId;
            this.Quantity = Quantity;
        }

        // properties
        public int Id { get; set; }
        [Required] public int ProductId { get; set; }
        [Required] public int StoreFrontId { get; set; }
        [Required] public int Quantity { get; set; }
    }
}