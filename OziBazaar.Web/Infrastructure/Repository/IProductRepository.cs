using OziBazaar.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OziBazaar.DAL;

namespace OziBazaar.Web.Infrastructure.Repository
{
    public interface IProductRepository
    {
        ProductView           GetProduct(int productId);
        ProductAddView        AddProduct(int CategoryId);
        ProductEditView       EditProduct(int productId);       
        IEnumerable<Ad>       GetAdvertisementsList();
        IEnumerable<Category> GetAllCategories();
        void                  AddProduct(ProductModel product);
        void                  UpdateProduct(ProductModel product);
        List<WishListViewModel> GetWishList(string userName);
        List<ProductGroup> GetProductGroupList();
        List<SearchViewModel> SearchProduct(string[] tags);
    }
}
