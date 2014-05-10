using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OziBazaar.Framework.Model
{
    public  class Ad
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
    }
    public class AdStatistic
    {
        public int AdId { get; set; }
        public int TotalHit { get; set; }
        public int TotalUnqiueHit { get; set; }
        
    }
    public class Product
    {
        public int Id { get; set; }
       
    }
    public class Feature
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class ProductFeature
    {
        public int ProductId { get; set; }
        public int FeatureId { get; set; }
        public string Value { get; set; }
    }
    public class ProductView
    {
        public List<ProductFeatureView> Features { get; set; }
    }
    public class ProductAddView
    {
        public ProductAddView()
        {
            Features = new List<ProductFeatureAdd>();
        }
        public List<ProductFeatureAdd> Features { get; set; }
    }
    public class ProductFeatureView
    {
        public int ProductId { get; set; }
        public string FeatureName { get; set; }
        public string FeatureValue { get; set; }
        public string ViewType { get; set; }
        public int DisplayOrder { get; set; }
    }
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