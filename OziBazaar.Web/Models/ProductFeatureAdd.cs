using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OziBazaar.Web.Models
{
    public class ProductFeatureAdd
    {
        public int ProductId { get; set; }
        public string FeatureName { get; set; }
        public string EditorType { get; set; }
        public string ValueType { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsMandatory { get; set; }
        public string DependsOn { get; set; }
        public List<string> ValueEnum { get; set; }
    }
}