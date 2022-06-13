using DAL;
using NUnit.Framework;
using PetShopWebAPI.Entities;
using System;

namespace MSSQLTests
{
    public class Tests 
    {

        [Test]// parameters
        public void ItShouldReturnNotNullItemsCollection()
        {          
            var db = new DataContextFactory();
            var repo = new MSSQLRepo(db.getContext());

            var items = repo.GetItems();
      
            DataContextFactory.Destroy(db.getContext());
            Assert.NotNull(items);
        
        }
        [Test]
        public void GetUnexistItem()
        {
            int incorrectId = -1;

            var db = new DataContextFactory();
            var repo = new MSSQLRepo(db.getContext());

            var item  = repo.Get(incorrectId);

            DataContextFactory.Destroy(db.getContext());
            Assert.Null(item);

        }

        [Test]
        public void GetExistItem()
        {
            int correctId = DataContextFactory.ItemId;

            var db = new DataContextFactory();
            var repo = new MSSQLRepo(db.getContext());

            var item = repo.Get(correctId);

            DataContextFactory.Destroy(db.getContext());
            Assert.NotNull(item);

        } 
        [Test]
        public void GetClients()
        {
            int correctId = DataContextFactory.ItemId;

            var db = new DataContextFactory();
            var repo = new MSSQLRepo(db.getContext());

            var clients = repo.GetClients();

            DataContextFactory.Destroy(db.getContext());
            Assert.NotNull(clients);

        }

        [Test]
        public void GetUnexistClient()
        {
            string emptyEmail = "  ";

            var db = new DataContextFactory();
            var repo = new MSSQLRepo(db.getContext());

            var client = repo.Get(emptyEmail);

            DataContextFactory.Destroy(db.getContext());
            Assert.Null(client);

        }

        [Test]
        public void GetExistClient()
        {
            string emptyEmail = "";

            var db = new DataContextFactory();
            var repo = new MSSQLRepo(db.getContext());

            var client = repo.Get(emptyEmail);

            DataContextFactory.Destroy(db.getContext());
            Assert.Null(client);

        }

        [Test]
        public void BookingMoreThanExistItems()
        {
            //Arrange
            int amountBookingItems = int.MaxValue;
            Random rnd = new Random();
            int bookingid = rnd.Next();

            var booking = new Booking {
                ID = bookingid,
                Amount = amountBookingItems,
                BookingDate = DateTime.Now,
                BookingNumber = " ",
                BookingStatus = "",
                ClientID = 1,
                ItemID = DataContextFactory.ZeroCountItemId

            };
            var db = new DataContextFactory();
            var repo = new MSSQLRepo(db.getContext());
  
            //Act
           repo.BookingItem(booking);
           var resultBooking = repo.GetBooking(bookingid);
           DataContextFactory.Destroy(db.getContext());

            //Assert
           Assert.Null(resultBooking);

        } 
        
        [Test]
        public void BookingUnexistItem()
        {
            //Arrange
            int UnexistIdItem = int.MaxValue;
            Random rnd = new Random();
            int bookingid = rnd.Next();

            var booking = new Booking {
                ID = bookingid,
                Amount = 0,
                BookingDate = DateTime.Now,
                BookingNumber = " ",
                BookingStatus = "",
                ClientID = 1,
                ItemID = UnexistIdItem

            };
            var db = new DataContextFactory();
            var repo = new MSSQLRepo(db.getContext());
  
            //Act
           repo.BookingItem(booking);
           var resultBooking = repo.GetBooking(bookingid);
           DataContextFactory.Destroy(db.getContext());

            //Assert
           Assert.Null(resultBooking);

        }


    }
}