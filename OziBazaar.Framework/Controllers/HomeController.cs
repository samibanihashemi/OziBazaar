using OziBazaar.Framework.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OziBazaar.Framework.Models;
using OziBazaar.Framework.Infrastructure.Repository;
namespace OziBazaar.Framework.Controllers
{
    public class HomeController : Controller
    {
        // inject by unity later on
        private readonly IRenderEngine renderEngine = new XslRenderEngine();
        public HomeController()
        {

        }
        public HomeController(IRenderEngine renderEngine) : this()
        {
            this.renderEngine = renderEngine;
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
            var productview = ProductRepositoryMock.GetProduct(Id);
            ViewBag.ProductInfo=  renderEngine.Render(productview);
            return View();
        }
        public ActionResult AddProduct(int category)
        {
            var productAdd = ProductRepositoryMock.AddProduct(category);
            ViewBag.ProductInfo = renderEngine.Render(productAdd);
            return View();
        }
        public ActionResult CreateProduct()
        {
            var keys = Request.Form.AllKeys;
           // Product prod = new Product();
            //List<ProductFeature> features = new List<ProductFeature>();
            //foreach (var key in keys)
            //{
            //    //features.Add(new ProductFeature{ke})
            //}
            return RedirectToAction("Index");
        }
        public  JsonResult GetDependent(string type)
        {
            List<string> types = new List<string>();
            if (type.ToLower() == "toyota")
            {
                types.Add("Camary");
                types.Add("Corola");
                types.Add("yari");
            }
            else  if (type.ToLower() == "mazda")
                {
                    types.Add("mazda2");
                    types.Add("mazda 3");
                    types.Add("mazda 6");
                }
            else if (type.ToLower() == "iphone")
            {
                types.Add("iphone 3");
                types.Add("iphone 4");
                types.Add("iphone 5");
            }
            else if (type.ToLower() == "samsung")
            {
                types.Add("Galxy S3");
                types.Add("Glaxy S4");
                types.Add("Galaxy Note");
            }
            return Json(types,JsonRequestBehavior.AllowGet);

        }
    }
}