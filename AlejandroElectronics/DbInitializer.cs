using System;
using System.Linq;
using AlejandroElectronics.Models;
using Microsoft.EntityFrameworkCore;

namespace AlejandroElectronics
{
    internal class DbInitializer
    {
        internal static void Initialize(AlejandroTestContext context) //-- this Initialize is coming from Startup.cs
        {
            // tHIS CREATES THE DATABASE
            context.Database.Migrate();


            //IF IT DATABASE DOES NOT EXIST IT CREATES A TABLE WITH NEW VALUES 
            if (!context.Products.Any())
            {
                context.Products.Add(new Products
                {
                    Name = "Dell",
                    Price = 540.00m,
                    Sku = 670,
                    ImageUrl = "/images/Dell.jpg",
                    Description = "It's ok",
                    DateCreated = DateTime.Now

                });
                context.SaveChanges();

                context.Products.Add(new Products
                {
                    Name = "Acer",
                    Price = 200.00m,
                    Sku = 250,
                    ImageUrl = "/images/acer.jpg",
                    Description = "cool, cool",
                    DateCreated = DateTime.Now
                    
                });
                context.SaveChanges();

                context.Products.Add(new Products
                {
                    Name = "Toshiba",
                    Price = 360.00m,
                    Sku = 100,
                    ImageUrl = "/images/toshiba.jpg",
                    Description = "Nice, nice",
                    DateCreated = DateTime.Now
                });
                context.SaveChanges();

                context.Products.Add(new Products
                {
                    Name = "surface",
                    Price = 1200.00m,
                    Sku = 105,
                    ImageUrl = "/images/surface.jpg",
                    Description = "Pretty cool",
                    DateCreated = DateTime.Now
                });
                context.SaveChanges();

                context.Products.Add(new Products
                {
                    Name = "Mac Air",
                    Price = 899.99m,
                    Sku = 345,
                    ImageUrl = "/images/macair.jpg",
                    Description = "Bic-'Mac' ",
                    DateCreated = DateTime.Now
                });
                context.SaveChanges();

                context.Products.Add(new Products
                {
                    Name = "Alienware",
                    Price = 899.99m,
                    Sku = 567,
                    ImageUrl = "/images/alienware.jpg",
                    Description = "These seem cool",
                    DateCreated = DateTime.Now
                });
                context.SaveChanges();

                context.Products.Add(new Products
                {
                    Name = "Mac Desktop",
                    Price = 1004.45m,
                    Sku = 1000,
                    ImageUrl = "/images/MacDesktop.jpg",
                    Description = "Perfect tool to work at home",
                    DateCreated = DateTime.Now
                });

                context.Products.Add(new Products
                {
                    Name = "Mac Pro Desktop",
                    Price = 1300.76m,
                    Sku = 1002,
                    ImageUrl = "",
                    Description = "No chords, no mess. This machine will do it all.",
                    DateCreated = DateTime.Now
                });

                context.Products.Add(new Products
                {
                    Name = "Oldy",
                    Price = 1.00m,
                    Sku = 001,
                    ImageUrl = "/images/BackInTheDays.jpg",
                    Description = "developers back in the days",
                    DateCreated = DateTime.Now
                });
                context.SaveChanges();
            } // end of Products IF statement
            if (!context.Reviews.Any())
            {
                context.Reviews.Add(new Review
                {
                    Rating = 2,
                    Body = "Cool, cool",
                    IsApproved = true,
                    Product = context.Products.First()

                });
                context.SaveChanges();
            }
            if (!context.Reviews.Any())
            {
                context.Reviews.Add(new Review
                {
                    Rating = 5,
                    Body = "i really like this computer. It's awesome",
                    IsApproved = true,
                    Product = context.Products.First()

                });
                context.SaveChanges();
            }
            
        }


    }
}