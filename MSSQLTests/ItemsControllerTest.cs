using DAL;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using PetShopWebAPI.Controllers;
using PetShopWebAPI.Entities;
using System.Collections.Generic;

namespace MSSQLTests
{
    internal class ItemsControllerTest
    {
       private static string filter = "test";
        private List<Item> GetTestItems()
        {
            int i = 0;
            var items = new List<Item>
            {
                new Item
                {
                    ID = i++,
                    ItemDescription = "",
                    AmountAll = 2,
                    AmountAvailable = 1,
                    Name = filter,
                    Picture = "",
                    Price = 1,
                    SubCathegoryID = 0
                },

                 new Item
                 {
                     ID = i++,
                     ItemDescription = "",
                     AmountAll = 2,
                     AmountAvailable = 1,
                     Name = "Имя2",
                     Picture = "",
                     Price = 1,
                     SubCathegoryID = 0
                 }
            };
            return items;
        }
        [Test]
        [System.Obsolete]
        public void ShouldReturnNotNull () 
        {
            //Arrange

            var repoStub = new Mock<IRepo>();
             repoStub.Setup(x => x.GetItems()).Returns(GetTestItems());
            var controller = new ItemsController(repoStub.Object);

            //Act
            var result = controller.Get();
            System.Console.WriteLine(result.Result);

            //Assert
            Assert.IsNotEmpty(result.Value);            
        }
        
        [Test]
        [System.Obsolete]
        public void ShouldReturnNull () 
        {
            //Arrange

            var repoStub = new Mock<IRepo>();
             repoStub.Setup(x => x.GetItems()).Returns(new List<Item>());
            var controller = new ItemsController(repoStub.Object);

            //Act
            var result = controller.Get();

            //Assert
         Assert.IsEmpty(result.Value);            
        }

        [Test]
        public void GetByFilter()
        {
            //Arrange
            var repoStub = new Mock<IRepo>();
            repoStub.Setup(x => x.GetItems()).Returns(GetTestItems());
            var controller = new ItemsController(repoStub.Object);

            //Act
            var result = controller.GetByFilter(filter);

            //Assert
            int i = 0;
          Assert.IsNotEmpty(result.Value);
        }
    }
}
