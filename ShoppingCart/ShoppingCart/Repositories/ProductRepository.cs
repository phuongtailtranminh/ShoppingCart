using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ShoppingCart.Interfaces;

namespace ShoppingCart.Repositories
{
    public class ProductRepository : IProductRepository, IDisposable
    {
        private ShoppingCartDb context;
        public ProductRepository(ShoppingCartDb context)
        {
            this.context = context;
        }

        public void DeleteProductById(int ProductId)
        {
            product product = context.products.Find(ProductId);
            context.products.Remove(product);
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public product GetProductById(int productId)
        {
            return context.products.Find(productId);
        }

        public IEnumerable<product> GetProducts()
        {
            return context.products;
        }

        public void InsertProduct(product product)
        {
            context.products.Add(product);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateProduct(product product)
        {
            context.Entry(product).State = EntityState.Modified;
        }
        public List<string> Search(string name)
        {
            return context.products.Where(i => i.NAME.StartsWith(name,
                StringComparison.OrdinalIgnoreCase)).Select(i => i.NAME).ToList();
        }

        public List<string> SearchProduct(string name)
        {
            throw new NotImplementedException();
        }
    }
}