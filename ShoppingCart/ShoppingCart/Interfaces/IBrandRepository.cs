using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Interfaces
{
    interface IBrandRepository : IDisposable
    {
        IEnumerable<brand> GetBrands();
        brand GetBrandById(int brandId);
        void InsertBrand(brand brand);
        void DeleteBrandById(int brandId);
        void UpdateBrand(brand brand);
        void Save();
    }
}
