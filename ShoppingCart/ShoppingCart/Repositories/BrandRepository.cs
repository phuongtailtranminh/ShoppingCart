using ShoppingCart.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ShoppingCart.Repositories
{
    public class BrandRepository : IBrandRepository, IDisposable
    {
        private ShoppingCartDb context;
        public BrandRepository(ShoppingCartDb context)
        {
            this.context = context;
        }

        public void DeleteBrandById(int brandId)
        {
            brand brand = context.brands.Find(brandId);
            context.brands.Remove(brand);
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

        public brand GetBrandById(int brandId)
        {
            return context.brands.Find(brandId);
        }

        public IEnumerable<brand> GetBrands()
        {
            return context.brands;
        }

        public void InsertBrand(brand brand)
        {
            context.brands.Add(brand);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateBrand(brand brand)
        {
            context.Entry(brand).State = EntityState.Modified;
        }
    }
}