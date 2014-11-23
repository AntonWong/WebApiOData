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
            builder.EntitySet<Supplier>("Suppliers");
            // New code:
            builder.Namespace = "ProductService";
            builder.EntityType<Product>()
                .Action("Rate")
                .Parameter<int>("Rating");
           
            config.MapODataServiceRoute("ODataRoute", null, builder.GetEdmModel());
        }
    }
}