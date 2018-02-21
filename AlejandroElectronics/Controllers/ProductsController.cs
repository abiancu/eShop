using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AlejandroElectronics.Controllers
{
    public class ProductsController : Controller
    {


        public IActionResult Index(int? Sku)
        {
            Models.ProductsViewModel model = new Models.ProductsViewModel();

            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AlejandroTest;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            var connection = new System.Data.SqlClient.SqlConnection(connectionString);

            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Products";
            var reader = command.ExecuteReader();
            var nameColumn = reader.GetOrdinal("Name");
            var priceColumn = reader.GetOrdinal("Price");
            var descriptionColumn = reader.GetOrdinal("Description");
            var imageUrlColumn = reader.GetOrdinal("ImageUrl");
            var SKUColumn = reader.GetOrdinal("Sku");
            List<Models.Product> products = new List<Models.Product>();
            while (reader.Read())
            {
                products.Add(new Models.Product
                {
                    Name =  reader.IsDBNull(nameColumn) ?"": reader.GetString(nameColumn),
                    Description = reader.IsDBNull(descriptionColumn) ? "" : reader.GetString(descriptionColumn),
                    ImageUrl = reader.IsDBNull(imageUrlColumn) ? "" : reader.GetString(imageUrlColumn),
                    Price =  reader.GetDecimal(priceColumn),
                    Sku = reader.GetInt32(SKUColumn)

                });
            }
            connection.Close();
            model.Products = products.ToArray();
            //model.Products = new Models.Product[]
            //{
            //    new Models.Product
            //    {
            //        Name = "Mac Air",
            //        Price = 299.99m,
            //        Sku = 300,
            //            Description = "Pretty cool laptop",
            //            ImageUrl = "/images/computer1.jpg"
            //    },
            //    new Models.Product
            //    {
            //         Name = "Surface",
            //        Price = 399.99m,
            //        Sku = 400,
            //Description = "Pretty cool laptop",
            //          ImageUrl = "/images/surface.jpg"

            //    },
            //    new Models.Product{

            //        Name = "Toshiba",
            //        Price = 899.99m,
            //        Sku = 500,
            //        Description = "It's Ok!",
            //        ImageUrl = "/images/toshiba.jpg"
            //    }
            //};
            if (Sku > 0)
            {
                model.Products = model.Products.Where(x => x.Sku == Sku).ToArray();
            }


            return View(model);

        }

        [HttpPost]
        public IActionResult Index(int? Sku, bool extra)
        {
            string productsName = Sku.HasValue ? Sku.Value.ToString() : "product name";
           // Request.Cookies.TryGetValue("Sku", out productsName);
            ViewData["productName"] = productsName;

            return RedirectToAction("Index", "Cart");
        }


       


    }
}