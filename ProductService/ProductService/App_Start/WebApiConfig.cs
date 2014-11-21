using ProductService.Models;
using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
namespace ProductService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // New code:
            ODataModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Product>("Products");
            // New code:
            builder.EntitySet<Supplier>("Suppliers");
            config.MapODataServiceRoute("ODataRoute", null, builder.GetEdmModel());
        }
    }
}