
using ProductApiRESTful.Data;
using ProductApiRESTful.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProductApiRESTful.Services
{
    public class ProductService
    {
        private readonly ApplicationDbContext dbContext;

        public ProductService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public IEnumerable<Products> GetProducts() { return dbContext._products.ToList(); }

        public Products GetProductByID(int id)
        {
            return dbContext._products.FirstOrDefault(p => p.Id == id);
        }

        public void AddProduct(AddProductdto product)
        {
            var AddPro = new Products()
            {
                Name = product.Name,
                Price = product.Price
            };
            dbContext._products.Add(AddPro);
            dbContext.SaveChanges();
        }

        public void UpdateProducts(UpdateProduct product)
        { 
            var ExistingProduct = GetProductByID(product.Id);

            if(ExistingProduct != null)
            {
                ExistingProduct.Price = product.Price;
                ExistingProduct.Name = product.Name;
                dbContext.SaveChanges();
            }
        }

        public void DeleteProduct(Products product)
        {
            var delProduct = GetProductByID(product.Id);
            if(delProduct != null)
            {
                dbContext._products.Remove(delProduct);
                dbContext.SaveChanges();
            }
        }
    }
}
