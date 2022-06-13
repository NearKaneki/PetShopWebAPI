using DAL;
using Microsoft.EntityFrameworkCore;
using PetShopWebAPI.Entities;
using System;

namespace MSSQLTests
{
    public class DataContextFactory
    {
        private readonly MSSQLContext context;
        private static int ID = 50;
        private static Random rnd = new Random();
        public static int ItemId = rnd.Next(); 
        public static int ZeroCountItemId = rnd.Next(); 

        private static int GetId() {
             
            return ID++;
        }

        public MSSQLContext getContext()
        {
            return context;
        }

        public DataContextFactory()
        {
            
            var optionBuilder = new DbContextOptionsBuilder<MSSQLContext>();
            optionBuilder.UseInMemoryDatabase("TestDb");
            context = new MSSQLContext(optionBuilder.Options);
           
            context.Items.AddRange(
                new Item
                {
                    ID = ItemId,
                    ItemDescription = "",
                    AmountAll = 2,
                    AmountAvailable = 1,
                    Name = "Имя",
                    Picture = "",
                    Price = 1,
                    SubCathegoryID = 0
                },

                 new Item
                 {
                     ID = ZeroCountItemId,
                     ItemDescription = "",
                     AmountAll = 0,
                     AmountAvailable = 0,
                     Name = "Имя2",
                     Picture = "",
                     Price = 1,
                     SubCathegoryID = 0
                 }
                 ,
                  new Item
                  {
                      ID = GetId(),
                      ItemDescription = "",
                      AmountAll = 2,
                      AmountAvailable = 1,
                      Name = "Имя3",
                      Picture = "",
                      Price = 1,
                      SubCathegoryID = 0
                  }
              );

            context.Bookings.AddRange(
                new Booking { 
                     ID = GetId(),
                     Amount = 1,
                     BookingDate = DateTime.Now,
                     BookingNumber ="4",
                     BookingStatus = "ff",
                     ClientID = GetId(),
                     ItemID = GetId()
                },
                new Booking
                {
                    ID = GetId(),
                    Amount = 1,
                    BookingDate = DateTime.Now,
                    BookingNumber = "4",
                    BookingStatus = "ff",
                    ClientID = GetId(),
                    ItemID = GetId()
                },
                new Booking
                {
                    ID = GetId(),
                    Amount = 1,
                    BookingDate = DateTime.Now,
                    BookingNumber = "4",
                    BookingStatus = "ff",
                    ClientID = GetId(),
                    ItemID = GetId()
                }
                ); 
            
            context.Clients.AddRange(
                new Client { 
                     Email = "First",
                     ID = GetId(),
                     Name = " f"
                },
                new Client
                {
                    Email = "Second",
                    ID = GetId(),
                    Name = " f"
                },
                new Client
                {
                    Email = "Third",
                    ID = GetId(),
                    Name = " f"
                }
                );
            
            context.SaveChanges();
          
        }

        public static void Destroy(MSSQLContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }

        //public Item goodItem = new Item
        //{
        //    ID = 1,
        //    ItemDescription = "",
        //    AmountAll = 2,
        //    AmountAvailable = 1,
        //    Name = "Имя",
        //    Picture = "",
        //    Price = 1,
        //    SubCathegoryID = 0
        //};

        //public Item badItem = new Item
        //{
        //    ID = -1,
        //    ItemDescription = "",
        //    AmountAll = -1,
        //    AmountAvailable = -1,
        //    Name = "",
        //    Picture = "",
        //    Price = -1,
        //    SubCathegoryID = 0
        //};
        //public Item badItemId = new Item
        //{
        //    ID = -1,
        //    ItemDescription = "",
        //    AmountAll = 0,
        //    AmountAvailable = 0,
        //    Name = "Rat",
        //    Picture = "",
        //    Price = 0,
        //    SubCathegoryID = 0
        //};
        //public Item badItemName = new Item
        //{
        //    ID = -1,
        //    ItemDescription = "",
        //    AmountAll = 0,
        //    AmountAvailable = -1,
        //    Name = "",
        //    Picture = "",
        //    Price = 0,
        //    SubCathegoryID = 0
        //};
        //public Item badItemPrice = new Item
        //{
        //    ID = 1,
        //    ItemDescription = "",
        //    AmountAll = 0,
        //    AmountAvailable = 0,
        //    Name = "",
        //    Picture = "",
        //    Price = -1,
        //    SubCathegoryID = 0
        //};
        //public Item badItemSubCategory = new Item
        //{
        //    ID = 1,
        //    ItemDescription = "",
        //    AmountAll = 0,
        //    AmountAvailable = 0,
        //    Name = "",
        //    Picture = "",
        //    Price = 0,
        //    SubCathegoryID = -1
        //};

        //public Item badItemAmountAvailable = new Item
        //{
        //    ID = 1,
        //    ItemDescription = "",
        //    AmountAll = 0,
        //    AmountAvailable = -1,
        //    Name = "",
        //    Picture = "",
        //    Price = 0,
        //    SubCathegoryID = 0
        //};
    }
}
