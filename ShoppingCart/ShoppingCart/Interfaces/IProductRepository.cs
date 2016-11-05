using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart;

interface IProductRepository : IDisposable
{
    IEnumerable<product> GetProducts();
    product GetProductById(int productId);
    void InsertProduct(product product);
    void DeleteProductById(int productId);
    void UpdateProduct(product product);
    void Save();
    List<string> SearchProduct(string name);
}