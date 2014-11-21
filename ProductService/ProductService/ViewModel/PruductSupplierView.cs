using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductService.ViewModel
{
    public class PruductSupplierView
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public SupplierView Supplier { get; set; }



    }
}