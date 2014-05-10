using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OziBazaar.Framework.Models
{
    public class ProductAddView
    {
        public ProductAddView()
        {
            Features = new List<ProductFeatureAdd>();
        }
        public List<ProductFeatureAdd> Features { get; set; }
    }
}