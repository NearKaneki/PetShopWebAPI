using DAL;
using Entities;
using Moq;
using NUnit.Framework;
using PetShopWebAPI.Controllers;
using PetShopWebAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Threading.Tasks;


namespace MSSQLTests
{
    internal class BookingControllerTest
    {

        [Test]
        public void Book()
        {
            var repoStub = new Mock<IRepo>();
          //  repoStub.Setup(x => x.BookingItem());

            var controller = new BookingController(repoStub.Object);
        }

        [Test]
        public void BookingNullCountAvailibleItem()
        {
            //Arrange
            int itemid = 0;

            DtoForBooking Fakedto = new DtoForBooking { 
             Count = int.MaxValue,
              Email = " ",
               ItemId = itemid,
                Name = " "
            };

            Item item = new Item
            {
                ID = itemid,
                ItemDescription = "",
                AmountAll = 0,
                AmountAvailable = 0,
                Name = "Имя2",
                Picture = "",
                Price = 1,
                SubCathegoryID = 0
            };

            var repoStub = new Mock<IRepo>();
             repoStub.Setup(x => x.Get(itemid)).Returns(item);

            //Act
            var controller = new BookingController(repoStub.Object);
            var result =  controller.SendEmail(Fakedto);

            //Assert
            Assert.IsInstanceOf<BadRequestObjectResult>(result);

        }  
        
        [Test]
        public void BookingItem()
        {
            //Arrange
            int itemid = 0;

            DtoForBooking Fakedto = new DtoForBooking { 
             Count = 1,
              Email = " ",
               ItemId = itemid,
                Name = " "
            };

            Item item = new Item
            {
                ID = itemid,
                ItemDescription = "",
                AmountAll = 1,
                AmountAvailable = 1,
                Name = "Имя2",
                Picture = "",
                Price = 1,
                SubCathegoryID = 0
            };

            var repoStub = new Mock<IRepo>();
             repoStub.Setup(x => x.Get(itemid)).Returns(item);

            //Act
            var controller = new BookingController(repoStub.Object);
            var result =   controller.SendEmail(Fakedto);

            //Assert

            Assert.IsInstanceOf<OkObjectResult>(result);
        }
    }
}
