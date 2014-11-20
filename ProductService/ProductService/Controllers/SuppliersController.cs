using ProductService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.OData;

namespace ProductService.Controllers
{
    public class SuppliersController : ODataController
    {
        ProductServiceContext db = new ProductServiceContext();

        [EnableQuery]
        //http://localhost:21900/Suppliers?$filter=Key%20eq%20%27CTSO%27
        public IQueryable<Supplier> Get()
        {
            return db.Suppliers;
        }

        // GET http://localhost:21900/Suppliers%28%27CTSO%27%29/Products
        [EnableQuery]
        public IQueryable<Product> GetProducts([FromODataUri] string key)
        {
            return db.Suppliers.Where(m => m.Key.Equals(key)).SelectMany(m => m.Products);
        }

        // Other controller methods not shown.
    }
}