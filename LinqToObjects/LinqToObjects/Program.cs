using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqToObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Product 1", Description = "Product 1 Description", Category = "Category 1", UnitPrice = 1.99m, InStock = true, Created = new DateTime(2019,1,1)  },
                new Product { Id = 2, Name = "Product 2", Description = "Product 2 Description", Category = "Category 1", UnitPrice = 2.99m, InStock = false, Created = new DateTime(2019,1,2)  },
                new Product { Id = 3, Name = "Product 3", Description = "Product 3 Description", Category = "Category 1", UnitPrice = 3.99m, InStock = true, Created = new DateTime(2019,1,3)  },
                new Product { Id = 4, Name = "Product 4", Description = "Product 4 Description", Category = "Category 2", UnitPrice = 4.99m, InStock = true, Created = new DateTime(2019,1,4)  },
                new Product { Id = 5, Name = "Product 5", Description = "Product 5 Description", Category = "Category 2", UnitPrice = 5.99m, InStock = false, Created = new DateTime(2019,1,5)  },
                new Product { Id = 6, Name = "Product 6", Description = "Product 6 Description", Category = "Category 2", UnitPrice = 6.99m, InStock = false, Created = new DateTime(2019,1,6)  },
                new Product { Id = 7, Name = "Product 7", Description = "Product 7 Description", Category = "Category 3", UnitPrice = 7.99m, InStock = true, Created = new DateTime(2019,1,7)  },
                new Product { Id = 8, Name = "Product 8", Description = "Product 8 Description", Category = "Category 3", UnitPrice = 8.99m, InStock = true, Created = new DateTime(2019,1,8)  },
                new Product { Id = 9, Name = "Product 9", Description = "Product 9 Description", Category = "Category 3", UnitPrice = 9.99m, InStock = true, Created = new DateTime(2019,1,9)  },
                new Product { Id = 10, Name = "Product 10", Description = "Product 10 Description", Category = "Category 4", UnitPrice = 10.99m, InStock = false, Created = new DateTime(2019,1,10)  }
            };

            var myProducts = (from product in products
                              where product.UnitPrice > 5 &&
                                    product.InStock
                              orderby product.Id
                              select new ProductInfo
                              {
                                  ProductName = product.Name,
                                  ProductPrice = product.UnitPrice
                              }).ToList();

            var firstProduct = products
                .Where(p => p.UnitPrice > 5)
                .FirstOrDefault();

            myProducts.ForEach(p => Console.WriteLine($"{p.ProductName} - {p.ProductPrice}"));

            //foreach (var product in myProducts)
            //{
                //Console.WriteLine($"{product.ProductName} - {product.ProductPrice}");
            //}

            //Console.WriteLine(firstProduct.Name);

            Console.ReadLine();
        }
    }
}
