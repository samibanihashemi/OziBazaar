using OziBazaar.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OziBazaar.DAL;
using System.Linq.Expressions;
using LinqKit;

namespace OziBazaar.Web.Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        private OziBazaarEntities dbContext = new OziBazaarEntities();

        public ProductView GetProduct(int productId)
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
                throw;
            }
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
                adv.Price = 1000;
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

        public UserProfile GetUser(string userName)
        {
            try
            {
                UserProfile userProfileModel =
                    (from userProfile in dbContext.UserProfiles
                     where userProfile.UserName == userName
                     select userProfile).FirstOrDefault();
                return userProfileModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ActivateUser(string userName, string emailAddress)
        {
            try
            {
                UserProfile userProfileModel = GetUser(userName);
                if (userProfileModel != null && userProfileModel.EmailAddress == emailAddress)
                {
                    userProfileModel.Activated = true;
                    dbContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public List<WishListViewModel> GetWishList(string userName)
        {
            try
            {
                List<WishListViewModel> wishListViewModels =
                    (from userProfile in dbContext.UserProfiles
                     where userProfile.UserName == userName
                     join wishList in dbContext.WishLists
                         on userProfile.UserId equals wishList.UserID
                     join advertisement in dbContext.Advertisements
                         on wishList.AdvertizementID equals advertisement.AdvertisementID
                     join product in dbContext.Products
                         on advertisement.ProductID equals product.ProductID
                     join productGroup in dbContext.ProductGroups
                         on product.ProductGroupID equals productGroup.ProductGroupID
                     select new WishListViewModel
                     {
                         WishListId = wishList.WishListID,
                         AdvertisementId = wishList.AdvertizementID,
                         ProductId = advertisement.ProductID,
                         ProductDescription = product.Description,
                         ProductGroupDescription = productGroup.Description,
                         Price = advertisement.Price,
                         StartDate = advertisement.StartDate,
                         EndDate = advertisement.EndDate
                     }).ToList<WishListViewModel>();
                return wishListViewModels;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ProductGroup> GetProductGroupList()
        {
            List<ProductGroup> productGroups;

            productGroups = dbContext.ProductGroups.ToList<ProductGroup>();
            return productGroups;
        }

        public List<SearchViewModel> SearchProduct(string tag)
        {
            List<SearchViewModel> searchResult =
            (from advertisement in dbContext.Advertisements
             join product in dbContext.Products
             on advertisement.ProductID equals product.ProductID
             join productProperty in dbContext.ProductProperties
             on product.ProductID equals productProperty.ProductID
             where advertisement.IsActive == true && productProperty.Value == tag
             select new SearchViewModel
                {
                    ProductId = product.ProductID,
                    ProductDescription = product.Description,
                    Price = advertisement.Price,
                    StartDate = advertisement.StartDate,
                    EndDate = advertisement.EndDate
                }
            ).Distinct().ToList();
            return searchResult;
        }
    }
}