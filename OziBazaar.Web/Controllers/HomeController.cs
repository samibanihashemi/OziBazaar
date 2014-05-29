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
        // inject by unity later on
        private readonly IRenderEngine renderEngine;
        private readonly IProductRepository productRepository;
      
        public HomeController(IRenderEngine renderEngine,IProductRepository productRepository) 
        {
            this.renderEngine = renderEngine;
            this.productRepository = productRepository;
        }

        public ActionResult Index()
        {
            return View();
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
        public ActionResult ViewProduct(int Id)
        {
            var productview = productRepository.GetProduct(Id);
            ViewBag.ProductInfo=  renderEngine.Render(productview);
            return View();
        }
        public ActionResult AddProduct(int category)
        {
            var productAdd = productRepository.AddProduct(category);
            ViewBag.ProductInfo = renderEngine.Render(productAdd);
            return View();
        }
        public ActionResult CreateProduct()
        {
            var keys = Request.Form.AllKeys;
            List<ProductFeature> features = new List<ProductFeature>();
            foreach (var key in keys)
            {
                features.Add(new ProductFeature { Key = key, Value = Request[key] });
            }
            Product prod = new Product() { Features=features};
            productRepository.AddProduct(prod);
            return RedirectToAction("Index");
        }

        public ActionResult AdList()
        {
            var lst=productRepository.GetAdvertisementsList();
            return View(lst);
        }
    }
}