using OziBazaar.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OziBazaar.Web.Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        public  ProductView GetProduct(int productId)
        {

            List<ProductFeatureView> productview = new List<ProductFeatureView>();
            productview.Add(new ProductFeatureView { ProductId = 1, FeatureName = "Name", FeatureValue = "Mazda" });
            productview.Add(new ProductFeatureView { ProductId = 1, FeatureName = "Model", FeatureValue = "Sedan" });
            productview.Add(new ProductFeatureView { ProductId = 1, FeatureName = "KiloMeter", FeatureValue = "120,000" });
            productview.Add(new ProductFeatureView { ProductId = 1, FeatureName = "Rego", FeatureValue = "06/2015" });
            productview.Add(new ProductFeatureView { ProductId = 1, FeatureName = "Tyre", FeatureValue = "in very good Status" });
            productview.Add(new ProductFeatureView { ProductId = 1, FeatureName = "Price", FeatureValue = "1000" });
            productview.Add(new ProductFeatureView { ProductId = 1, FeatureName = "Color", FeatureValue = "Red" });
            productview.Add(new ProductFeatureView { ProductId = 1, FeatureName = "Year", FeatureValue = "2010" });
            productview.Add(new ProductFeatureView { ProductId = 1, FeatureName = "Image", FeatureValue = "/Content/Image/mazda1.jpg" });
            productview.Add(new ProductFeatureView { ProductId = 1, FeatureName = "Image", FeatureValue = "/Content/Image/mazda2.jpg" });

            productview.Add(new ProductFeatureView { ProductId = 2, FeatureName = "Name", FeatureValue = "Mobile" });
            productview.Add(new ProductFeatureView { ProductId = 2, FeatureName = "Model", FeatureValue = "Galaxy S2" });
            productview.Add(new ProductFeatureView { ProductId = 2, FeatureName = "Color", FeatureValue = "black" });
            productview.Add(new ProductFeatureView { ProductId = 2, FeatureName = "Battery Life", FeatureValue = "24 hours" });
            productview.Add(new ProductFeatureView { ProductId = 2, FeatureName = "Image", FeatureValue = "/Content/Image/mobile1.jpg" });
            productview.Add(new ProductFeatureView { ProductId = 2, FeatureName = "Image", FeatureValue = "/Content/Image/mobile2.jpg" });

            return new ProductView { Features = productview.Where(x => x.ProductId == productId).ToList() };
        }

        public  ProductAddView AddProduct(int CategoryId)
        {
            ProductAddView product = new ProductAddView();
            if (CategoryId == 1)// car
            {
                product.Features.Add(new ProductFeatureAdd { ProductId = 3, FeatureName = "Model", EditorType = "DropDown", ValueType = "string", IsMandatory = true, ValueEnum = new List<string> { "Toyota", "Mazda", "Ford", "BMW" } });
                product.Features.Add(new ProductFeatureAdd { ProductId = 3, FeatureName = "Type", EditorType = "DropDown", ValueType = "string", IsMandatory = true, ValueEnum = new List<string> { }, DependsOn = "Model" });
                product.Features.Add(new ProductFeatureAdd { ProductId = 3, FeatureName = "Name", EditorType = "TextBox", ValueType = "string", IsMandatory = true });
                product.Features.Add(new ProductFeatureAdd { ProductId = 3, FeatureName = "Description", EditorType = "TextArea", ValueType = "string", IsMandatory = true });
                product.Features.Add(new ProductFeatureAdd { ProductId = 3, FeatureName = "Color", EditorType = "DropDown", ValueType = "string", IsMandatory = true, ValueEnum = new List<string> { "Red", "Green", "Yellow" } });
                product.Features.Add(new ProductFeatureAdd { ProductId = 3, FeatureName = "Aumatic", EditorType = "CheckBox", ValueType = "bool", IsMandatory = true });
                product.Features.Add(new ProductFeatureAdd { ProductId = 3, FeatureName = "Fuel", EditorType = "RadioButton", ValueType = "string", ValueEnum = new List<string> { "Petrol", "Disel", "LPG" } });
                product.Features.Add(new ProductFeatureAdd { ProductId = 3, FeatureName = "KilioMetere", EditorType = "TextBox", ValueType = "string" });
                product.Features.Add(new ProductFeatureAdd { ProductId = 3, FeatureName = "FeulConsumption", EditorType = "TextBox", ValueType = "string", IsMandatory = true });
            }
            if (CategoryId == 2)//Mobile
            {
                product.Features.Add(new ProductFeatureAdd { ProductId = 4, FeatureName = "Name", EditorType = "TextBox", ValueType = "string", IsMandatory = true });
                product.Features.Add(new ProductFeatureAdd { ProductId = 4, FeatureName = "Description", EditorType = "TextBox", ValueType = "string", IsMandatory = true });
                product.Features.Add(new ProductFeatureAdd { ProductId = 4, FeatureName = "Color", EditorType = "DropDown", ValueType = "string", IsMandatory = true, ValueEnum = new List<string> { "Black", "White", "Red" } });
                product.Features.Add(new ProductFeatureAdd { ProductId = 4, FeatureName = "Model", EditorType = "DropDown", ValueType = "string", IsMandatory = true, ValueEnum = new List<string> { "Iphone", "Samsung", "HTC" } });
                product.Features.Add(new ProductFeatureAdd { ProductId = 4, FeatureName = "Type", EditorType = "DropDown", ValueType = "string", IsMandatory = true, DependsOn = "Model" });
                product.Features.Add(new ProductFeatureAdd { ProductId = 4, FeatureName = "Battery Life", EditorType = "TextBox", ValueType = "string", IsMandatory = true });
                product.Features.Add(new ProductFeatureAdd { ProductId = 3, FeatureName = "HeadSet", EditorType = "CheckBox", ValueType = "bool", IsMandatory = true });
            }

            return product;
        }


        public IEnumerable<Ad> GetAdvertisementsList()
        {
            List<Ad> ads = new List<Ad>();
            ads.Add(new Ad() { ProductId = 1, Id = 1, Title = "Good Car" });
            ads.Add(new Ad() { ProductId = 2, Id = 2, Title = "Good Mobile" });
            return ads;
        }
        public IEnumerable<Category> GetAllCategories()
        {
            List<Category> categories = new List<Category>();
            categories.Add(new Category() { Id = 1, Name = "Car" });
            categories.Add(new Category() { Id = 2, Name = "Mobile" });

            return categories;
        }

    }
}