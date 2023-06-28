using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;
using IMS.UseCases.Products.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Plugins.InMemory
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> _products;

        public ProductRepository() 
        {
            _products = new List<Product>()
            {
                new Product() { ProductId = 1, ProductName = "Custom PC-CR1000", Quantity = 4, Price= 1199 },
                new Product() { ProductId = 2, ProductName = "Custom PC-CR2000", Quantity = 2, Price = 1299 },
                new Product() { ProductId = 3, ProductName = "Custom PC-CR3000", Quantity = 7, Price = 1599 },
                new Product() { ProductId = 4, ProductName = "Custom PC-CR4000", Quantity = 3, Price = 1699 },
                new Product() { ProductId = 5, ProductName = "Custom PC-CR5000", Quantity = 6, Price= 1799 },
                new Product() { ProductId = 6, ProductName = "Custom PC-CR6000", Quantity = 3, Price= 1299 }
            };
        
        }

        public async Task<IEnumerable<Product>> GetProductsByNameAsync(string name)
        {
            if (string.IsNullOrEmpty(name)) return await Task.FromResult(_products);
            
            return _products.Where(x => x.ProductName.Contains(name, StringComparison.OrdinalIgnoreCase));
        }

        public Task AddProductAsync(Product product)
        {
            if (_products.Any(x => x.ProductName.Equals(product.ProductName, StringComparison.OrdinalIgnoreCase)))
                return Task.CompletedTask;

            var maxId = _products.Max(x => x.ProductId);
            product.ProductId = maxId +1;

            _products.Add(product);

            return Task.CompletedTask;
        }

        
    }
}
