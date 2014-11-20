using ProductService.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.OData.Query;
using System.Web.OData.Routing;

namespace ProductService.Controllers
{
    public class ProductsController : ODataController
    {
        ProductServiceContext db = new ProductServiceContext();
        private bool ProductExists(int key)
        {
            return db.Products.Any(p => p.ID == key);
        }
        
        [ODataRoute]
        [EnableQuery(PageSize = 1000, AllowedQueryOptions = AllowedQueryOptions.All)]
        public IQueryable<Product> Get()
        {
            return db.Products;
        }

        // GET /Products(1)/Supplier
        [EnableQuery]
        public SingleResult<Supplier> GetSupplier([FromODataUri] int key)
        {
            var result = db.Products.Where(m => m.ID == key).Select(m => m.Supplier);
            return SingleResult.Create(result);
        }
        //// GET /Suppliers(1)/Products
        //[EnableQuery]
        //public IQueryable<Product> GetProducts([FromODataUri] int key)
        //{
        //   return db.Suppliers.Where(m => m.Key.Equals(key)).SelectMany(m => m.Products);
            
        //}

        [EnableQuery]
        public SingleResult<Product> Get([FromODataUri] int key)
        {
            IQueryable<Product> result = db.Products.Where(p => p.ID == key);
            return SingleResult.Create(result);
        }

        public async Task<IHttpActionResult> Post(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Products.Add(product);
            await db.SaveChangesAsync();
            return Created(product);
        }
        /// <summary>
        /// Updating an Entity
        /// </summary>
        /// <param name="key"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Product> product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = await db.Products.FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            product.Patch(entity);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Updated(entity);
        }
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Product update)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (key != update.ID)
            {
                return BadRequest();
            }
            db.Entry(update).State = EntityState.Modified;
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Updated(update);
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}