using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using SBL;
using Models;
using Microsoft.AspNetCore.Mvc;
using DL;
using Microsoft.EntityFrameworkCore;
using WebUI.Controllers;

namespace Tests
{
    public class ControllerTests
    {
        private readonly DbContextOptions<ElephantDBContext> options;

        [Fact]
        public void HomeControllerHomeShouldReturnListOfStores()
        {
            //Arrange
            var mockBL = new Mock<IBL>();
            mockBL.Setup(x => x.GetAllStoreFronts()).Returns(
                    new List<StoreFront>()
                    {
                        new StoreFront() {
                            Id = 1,
                            StoreName = "Pikachu"
                        },
                        new StoreFront()
                        {
                            Id = 2,
                            StoreName = "Weasel"
                        }
                    }
                );
            var controller = new HomeController(mockBL.Object);

            //Act
            var result = controller.Home();

            //Assert
            //First, make sure we are getting the right type of the result obj
            var viewResult = Assert.IsType<ViewResult>(result);

            //Next, we wanna make sure, that in this viewresult, the model we have for it
            //is list of RestaurantVM's
            var model = Assert.IsAssignableFrom<IEnumerable<StoreFront>>(viewResult.ViewData.Model);

            //lastly, let's make sure there're two of them
            Assert.Equal(2, model.Count());
        }
        [Fact]
        public void SignUpShouldCreateACustomer()
        {
            //Arrange
            var mockBL = new Mock<IBL>();
            var controller = new HomeController(mockBL.Object);

            //Act
            var result = controller.SignUp("Mawile", "BestMon");

            //Assert
            Assert.IsType<ViewResult>(result);
        }
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void AdminIndexShouldGiveView(int i)
        {
            //Arrange
            var mockBL = new Mock<IBL>();
            var controller = new AdminController(mockBL.Object);

            //Act
            var result = controller.Index(i);

            //Assert
            Assert.IsType<RedirectToActionResult>(result);
        }
    }
}
