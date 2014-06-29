using OziBazaar.Framework.RenderEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OziBazaar.Web.Models;
using OziBazaar.Web.Infrastructure.Repository;
namespace OziBazaar.Web.Controllers
{
    public class HomeController : Controller
    {
       private readonly IProductRepository productRepository;

        public HomeController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;

        }

        public ActionResult Index(string search)
        {
            List<SearchViewModel> searchResult = null;
            if (!string.IsNullOrEmpty(search))
                searchResult = productRepository.SearchProduct(search.Split(' '));
            return View(searchResult);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}