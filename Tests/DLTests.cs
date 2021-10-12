using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Xunit;
using DL;
using Models;

namespace Tests
{
    public class DLTests
    {
        private readonly DbContextOptions<ElephantDBContext> options;

        public DLTests()
        {
            //we are constructing db context options
            //using options builder everytime we instantiate DLTests class
            //and using SQlite's in memory db
            //instead of our real db
            options = new DbContextOptionsBuilder<ElephantDBContext>()
                        .UseSqlite("Filename=Test.db").Options;
            Seed();
        }

        [Fact]
        public void GetAllCustomersShouldGetAllCustomers()
        {
            using (var context = new ElephantDBContext(options))
            {
                //Arrange
                IRepo repo = new DBRepo(context);

                //Act
                var customers = repo.GetAllCustomers();

                //Assert
                Assert.Equal(2, customers.Count);
            }
        }
        [Fact]
        public void GetAllProductsShouldGetAllProducts()
        {
            using (var context = new ElephantDBContext(options))
            {
                //Arrange
                IRepo repo = new DBRepo(context);

                //Act
                var Products = repo.GetAllProducts();

                //Assert
                Assert.Equal(2, Products.Count);
            }
        }
        [Fact]
        public void GetAllStoreFrontsShouldGetAllStoreFronts()
        {
            using (var context = new ElephantDBContext(options))
            {
                //Arrange
                IRepo repo = new DBRepo(context);

                //Act
                var StoreFronts = repo.GetAllStoreFronts();

                //Assert
                Assert.Equal(2, StoreFronts.Count);
            }
        }

        [Fact]
        public void AddingACustomerShouldAddACustomer()
        {
            using (var context = new ElephantDBContext(options))
            {
                //Arrange with my repo and the item i'm going to add
                IRepo repo = new DBRepo(context);
                Models.Customer restoToAdd = new Models.Customer()
                {
                    Id = 99,
                    Username = "Veronica",
                    Credit = 79,
                    Password = "notreal"
                };

                //Act
                repo.AddObject(restoToAdd);
            }

            using (var context = new ElephantDBContext(options))
            {
                //Assert
                Customer resto = context.Customers.FirstOrDefault(r => r.Id == 99);

                Assert.NotNull(resto);
                Assert.Equal("Veronica", resto.Username);
                Assert.Equal(79, resto.Credit);
            }
        }

        private void Seed()
        {
            using (var context = new ElephantDBContext(options))
            {
                //first, we are going to make sure
                //that the DB is in clean slate
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Customers.AddRange(
                    new Customer()
                    {
                        Id = 1,
                        Username = "Zapdos",
                        Credit = 55,
                        Password = "777"
                    },
                    new Customer()
                    {
                        Id = 2,
                        Username = "Articuno",
                        Credit = 80,
                        Password = "777"
                    }
                );

                context.Products.AddRange(
                    new Product()
                    {
                        Id = 1,
                        Name = "Pokeball",
                        Price = 10
                    },
                    new Product()
                    {
                        Id = 2,
                        Name = "Great Ball",
                        Price = 30
                    }
                );

                context.StoreFronts.AddRange(
                    new StoreFront()
                    {
                        Id = 1,
                        StoreName = "Pokecenter"
                    },
                    new StoreFront()
                    {
                        Id = 2,
                        StoreName = "Pokemart"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
