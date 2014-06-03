using OziBazaar.Framework.RenderEngine;
using OziBazaar.Web.Infrastructure.Repository;
using OziBazaar.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OziBazaar.Web.Controllers
{
    public class ProductController : Controller
    {
        
        private readonly IRenderEngine renderEngine;
        private readonly IProductRepository productRepository;

        public ProductController(IRenderEngine renderEngine, IProductRepository productRepository) 
        {
            this.renderEngine = renderEngine;
            this.productRepository = productRepository;
        }
        //
        // GET: /Product/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewProduct(int Id)
        {
            var productview = productRepository.GetProduct(Id);
            ViewBag.ProductInfo = renderEngine.Render(productview);
            return View();
        }
        public ActionResult EditProduct(int Id)
        {
            var productview = productRepository.EditProduct(Id);
            ViewBag.ProductInfo = renderEngine.Render(productview);
            return View();
        }
        public ActionResult AddProduct(int category)
        {
            var productAdd = productRepository.AddProduct(category);
            ViewBag.ProductInfo = renderEngine.Render(productAdd);
            return RedirectToAction("AdList","Ad");
        }
        public ActionResult CreateProduct()
        {
            var keys = Request.Form.AllKeys;
            List<ProductFeature> features = new List<ProductFeature>();
            foreach (var key in keys)
            {
                features.Add(new ProductFeature { Key = key, Value = Request[key] });
            }
            ProductModel prod = new ProductModel() { Features = features };
            productRepository.AddProduct(prod);
            return RedirectToAction("Index");
        }
        public  ActionResult UpdateProduct()
        {
            var keys = Request.Form.AllKeys;
            List<ProductFeature> features = new List<ProductFeature>();
            foreach (var key in keys)
            {
                features.Add(new ProductFeature { Key = key, Value = Request[key] });
            }
            ProductModel prod = new ProductModel() { Features = features };
            productRepository.UpdateProduct(prod);
            return RedirectToAction("Index");
        }

	}
}