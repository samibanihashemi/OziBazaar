using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OziBazaar.DAL;
using OziBazaar.Web.Infrastructure.Repository;

namespace OziBazaar.Web.Controllers
{
    public class NavController : Controller
    {
        private readonly IProductRepository productRepository;

        public NavController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;

        }

        public PartialViewResult ProductGroupMenu()
        {
            List<ProductGroup> productGroups =
                productRepository.GetProductGroupList();
            return PartialView(productGroups);
        }
	}
}