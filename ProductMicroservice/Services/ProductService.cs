﻿using ProductMicroservice.Models;
using ProductMicroservice.Services.Interface;

namespace ProductMicroservice.Services
{
    public class ProductService : IProductService
    {
        private readonly DataContext _dbContext;

        public ProductService(DataContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Product> GetProductList()
        {
            return _dbContext.Products.ToList();
        }
        public Product GetProductById(int id)
        {
            return _dbContext.Products.Where(x => x.ProductId == id).First();
        }

        public Product AddProduct(Product product)
        {
            var result = _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
            return result.Entity;
        }

        public Product UpdateProduct(Product product)
        {
            var result = _dbContext.Products.Update(product);
            _dbContext.SaveChanges();
            return result.Entity;
        }
        public bool DeleteProduct(int Id)
        {
            var filteredData = _dbContext.Products.Where(x => x.ProductId == Id).First();
            var result = _dbContext.Remove(filteredData);
            _dbContext.SaveChanges();
            return result != null ? true : false;
        }
    }
}