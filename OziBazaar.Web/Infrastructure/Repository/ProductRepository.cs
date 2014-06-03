using OziBazaar.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OziBazaar.DAL;

namespace OziBazaar.Web.Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        private OziBazaarEntities dbContext = new OziBazaarEntities();

        public  ProductView GetProduct(int productId)
        {
            try
            {
                List<ProductFeatureView> productFeatureViews =
                    (from productProperty in dbContext.ProductProperties
                     where productProperty.ProductID == productId
                     join productGroupProperty in dbContext.ProductGroupProperties
                         on productProperty.ProductGroupPropertyID equals productGroupProperty.ProductGroupPropertyID
                     join property in dbContext.Properties
                         on productGroupProperty.PropertyID equals property.PropertyID
                     join productGroup in dbContext.ProductGroups
                         on productGroupProperty.ProductGroupID equals productGroup.ProductGroupID
                     select new ProductFeatureView
                     {
                         DisplayOrder = (int)productGroupProperty.TabOrder,
                         FeatureName = property.KeyName,
                         FeatureValue = productProperty.Value,
                         ProductId = productProperty.ProductID,
                         ViewType = productGroup.ViewTemplate
                     }).ToList<ProductFeatureView>();
                return new ProductView { Features = productFeatureViews };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            /*
            List<ProductFeatureView> productview = new List<ProductFeatureView>();
            productview.Add(new ProductFeatureView { ProductId = 1, FeatureName = "Name", FeatureValue = "Mazda33" });
            productview.Add(new ProductFeatureView { ProductId = 1, FeatureName = "Model", FeatureValue = "Sedan" });
            productview.Add(new ProductFeatureView { ProductId = 1, FeatureName = "Kilo Meter", FeatureValue = "120,000" });
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
             */ 
        }

        public ProductAddView AddProduct(int CategoryId)
        {
            try
            {
            var productFeatureDetails =
                    (from property in dbContext.Properties
                     join productGroupProperty in dbContext.ProductGroupProperties
                         on property.PropertyID equals productGroupProperty.PropertyID
                     where productGroupProperty.ProductGroupID == CategoryId
                     select new 
                     {
                         PropertyId = productGroupProperty.ProductGroupPropertyID,
                         FeatureName = property.KeyName,
                         EditorType = property.ControlType,
                         ValueType = property.DataType,
                         IsMandatory = property.IsMandatory.Value,
                         DisplayOrder = (int)productGroupProperty.TabOrder,
                         ValueEnum = productGroupProperty.InitialValue,
                       
                     }).ToList();
               var  productFeatureAdds =productFeatureDetails.Select(x=>new ProductFeatureAdd
                     {
                         PropertyId = x.PropertyId,
                         FeatureName = x.FeatureName,
                         EditorType = x.EditorType,
                         ValueType = x.ValueType,
                         IsMandatory = x.IsMandatory,
                         DisplayOrder = (int)x.DisplayOrder,
                         ValueEnum = (x.EditorType.ToLower() == "dropdown" &&
                                      !(string.IsNullOrEmpty(x.ValueEnum))) ?
                                      x.ValueEnum.Split(';').ToList<string>() :
                                      null
                     }
                    ).ToList();
                return new ProductAddView { Features = productFeatureAdds };

            }
            catch (Exception ex)
            {
                throw ex;
            }
            

            /*
            ProductAddView product = new ProductAddView();
            if (CategoryId == 1)// car
            {
                product.Features.Add(new ProductFeatureAdd { ProductId = 3, PropertyId = 3, FeatureName = "Model", EditorType = "DropDown", ValueType = "string", IsMandatory = true, ValueEnum = new List<string> { "Toyota", "Mazda", "Ford", "BMW" } });
                product.Features.Add(new ProductFeatureAdd { ProductId = 3, PropertyId = 5, FeatureName = "Type", EditorType = "DropDown", ValueType = "string", IsMandatory = true, ValueEnum = new List<string> { }, DependsOn = "Model" });
                product.Features.Add(new ProductFeatureAdd { ProductId = 3, PropertyId = 1, FeatureName = "Name", EditorType = "TextBox", ValueType = "string", IsMandatory = true });
                product.Features.Add(new ProductFeatureAdd { ProductId = 3, PropertyId = 4, FeatureName = "Description", EditorType = "TextArea", ValueType = "string", IsMandatory = true });
                product.Features.Add(new ProductFeatureAdd { ProductId = 3, PropertyId = 2, FeatureName = "Color", EditorType = "DropDown", ValueType = "string", IsMandatory = true, ValueEnum = new List<string> { "Red", "Green", "Yellow" } });
                product.Features.Add(new ProductFeatureAdd { ProductId = 3, PropertyId = 8, FeatureName = "Aumatic", EditorType = "CheckBox", ValueType = "bool", IsMandatory = true });
                product.Features.Add(new ProductFeatureAdd { ProductId = 3, PropertyId = 9, FeatureName = "Fuel", EditorType = "RadioButton", ValueType = "string", ValueEnum = new List<string> { "Petrol", "Disel", "LPG" } });
                product.Features.Add(new ProductFeatureAdd { ProductId = 3, PropertyId = 10, FeatureName = "Kilio Metere", EditorType = "TextBox", ValueType = "string" });
                product.Features.Add(new ProductFeatureAdd { ProductId = 3, PropertyId = 11, FeatureName = "Feul Consumption", EditorType = "TextBox", ValueType = "string", IsMandatory = true });
            }
            if (CategoryId == 2)//Mobile
            {
                product.Features.Add(new ProductFeatureAdd { ProductId = 4, PropertyId = 1, FeatureName = "Name", EditorType = "TextBox", ValueType = "string", IsMandatory = true });
                product.Features.Add(new ProductFeatureAdd { ProductId = 4, PropertyId = 4, FeatureName = "Description", EditorType = "TextBox", ValueType = "string", IsMandatory = true });
                product.Features.Add(new ProductFeatureAdd { ProductId = 4, PropertyId = 2, FeatureName = "Color", EditorType = "DropDown", ValueType = "string", IsMandatory = true, ValueEnum = new List<string> { "Black", "White", "Red" } });
                product.Features.Add(new ProductFeatureAdd { ProductId = 4, PropertyId = 3, FeatureName = "Model", EditorType = "DropDown", ValueType = "string", IsMandatory = true, ValueEnum = new List<string> { "Iphone", "Samsung", "HTC" } });
                product.Features.Add(new ProductFeatureAdd { ProductId = 4, PropertyId = 5, FeatureName = "Type", EditorType = "DropDown", ValueType = "string", IsMandatory = true, DependsOn = "Model" });
                product.Features.Add(new ProductFeatureAdd { ProductId = 4, PropertyId = 6, FeatureName = "Battery Life", EditorType = "TextBox", ValueType = "string", IsMandatory = true });
                product.Features.Add(new ProductFeatureAdd { ProductId = 4, PropertyId = 7, FeatureName = "HeadSet", EditorType = "CheckBox", ValueType = "bool", IsMandatory = true });
            }

            return product;
             */
        }

        public IEnumerable<Ad> GetAdvertisementsList()
        {
            try
            {
                List<Ad> ads = (from advertisement in dbContext.Advertisements
                                select new Ad
                                {
                                    Id = advertisement.AdvertisementID,
                                    ProductId = advertisement.ProductID,
                                    Title = advertisement.Title,
                                    StartDate = advertisement.StartDate,
                                    EndDate = advertisement.EndDate,
                                    IsActive = advertisement.IsActive.Value,
                                    UserId = advertisement.OwnerID
                                }).ToList<Ad>();
                return ads;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            /*
            List<Ad> ads = new List<Ad>();
            ads.Add(new Ad() { ProductId = 1, Id = 1, Title = "Good Car" });
            ads.Add(new Ad() { ProductId = 2, Id = 2, Title = "Good Mobile" });
            return ads;
             */
        }
        public IEnumerable<Category> GetAllCategories()
        {
            try
            {
                List<Category> categories = (from productGroup in dbContext.ProductGroups
                                             select new Category
                                             {
                                                 Id = productGroup.ProductGroupID,
                                                 Name = productGroup.Description
                                             }).ToList<Category>();
                return categories;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            /*
            List<Category> categories = new List<Category>();
            categories.Add(new Category() { Id = 1, Name = "Car" });
            categories.Add(new Category() { Id = 2, Name = "Mobile" });

            return categories;
            */
        }

        public void AddProduct(ProductModel prod)
        {
            try
            {
                if (prod.Features == null || prod.Features.Count() == 0)
                    throw new ArgumentNullException();
                Advertisement adv = new Advertisement();
                adv.StartDate = DateTime.Now;
                adv.EndDate = DateTime.Now.AddMonths(1);

                Product product = new Product() { ProductGroupID=1,Description="tet"};
                foreach (ProductFeature productFeature in prod.Features.Where(x => x.Key != "__RequestVerificationToken"))
                {
                    product.ProductProperties.Add(new ProductProperty()
                    {
                        ProductGroupPropertyID =Int32.Parse( productFeature.Key),
                        Value = productFeature.Value
                    });
                }
                adv.Product = product;
                adv.OwnerID = 1;
                adv.Price = "1000";
                adv.Title = "product";

                dbContext.Advertisements.Add(adv);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private int GetProperty(string propertyName)
        {
            int propertyId = (from property in dbContext.Properties
                              where property.KeyName == propertyName
                              select property.PropertyID).FirstOrDefault();
            return propertyId;
      }

        public ProductEditView EditProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(ProductModel product)
        {
            throw new NotImplementedException();
        }
    }
}