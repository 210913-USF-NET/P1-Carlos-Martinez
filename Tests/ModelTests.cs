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
        [Theory]
        [InlineData("")]
        public void CustomerShouldNotAllowInvalidNames(string username)
        {
            Customer test = new Customer();
            
            Assert.Throws<Exception>(() => test.Username = username);
        }
        [Theory]
        [InlineData("")]
        public void CustomerShouldNotAllowInvalidPasswords(string password)
        {
            Customer test = new Customer();

            Assert.Throws<Exception>(() => test.Password = password);
        }
        [Theory]
        [InlineData("")]
        public void StoreFrontShouldNotAllowInvalidNames(string name)
        {
            StoreFront test = new StoreFront();

            Assert.Throws<Exception>(() => test.StoreName = name);
        }
    }
}