using System;
using System.Linq;
using AlejandroElectronics.Models;
using Microsoft.EntityFrameworkCore;

namespace AlejandroElectronics
{
    internal class DbInitializer
    {
        internal static void Initialize(AlejandroTestContext context)
        {
            // tHIS CREATES THE DATABASE
            context.Database.EnsureCreated();


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
            }
        }
    }
}