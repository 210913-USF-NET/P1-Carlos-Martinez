using System;
using Xunit;
using Models;

namespace Tests
{
    public class ModelTests
    {
        [Fact]
        public void CustomerShouldCreate()
        {
            Customer test = new Customer();

            Assert.NotNull(test);
        }
        [Fact]
        public void InventoryShouldCreate()
        {
            Inventory test = new Inventory();

            Assert.NotNull(test);
        }
        [Fact]
        public void LineItemShouldCreate()
        {
            LineItem test = new LineItem();

            Assert.NotNull(test);
        }
        [Fact]
        public void OrdersShouldCreate()
        {
            Orders test = new Orders();

            Assert.NotNull(test);
        }
        [Fact]
        public void ProductShouldCreate()
        {
            Product test = new Product();

            Assert.NotNull(test);
        }
        [Fact]
        public void StoreFrontShouldCreate()
        {
            StoreFront test = new StoreFront();

            Assert.NotNull(test);
        }
    }
}