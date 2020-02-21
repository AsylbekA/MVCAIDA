using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCAIDA.Models
{
    public class ProductModel
    {
        public int ProductID { get; set; }
        [DisplayName("Product Name")]
        public string Name { get; set; }
        public string Type { get; set; }
        public string Region { get; set; }
        public string Organization { get; set; }
        public string Since { get; set; }
        public string End { get; set; }
        public string Status { get; set; }
    }

        public class ProductDBContext : DbContext
        {
            public DbSet<ProductModel> ProductModels { get; set; }
        }
    
}