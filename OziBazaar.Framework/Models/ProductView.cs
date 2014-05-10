using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OziBazaar.Framework.Models
{
    public class ProductView
    {
        public ProductView()
        {
            Features = new List<ProductFeatureView>();
        }
        public List<ProductFeatureView> Features { get; set; }
    }
}