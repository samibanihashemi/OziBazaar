using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OziBazaar.Web.Infrastructure.Graphic;
using OziBazaar.Web.Models;

namespace OziBazaar.Web.Controllers
{
    public class HelperController : Controller
    {
        public ActionResult GenerateCaptcha()
        {
            System.Drawing.FontFamily family = new System.Drawing.FontFamily("Arial");
            CaptchaImage img = new CaptchaImage(150, 50, family);
            string text = img.CreateRandomText(4) + " " + img.CreateRandomText(3);
            img.SetText(text);
            img.GenerateImage();
            img.Image.Save(Server.MapPath("~") + 
                "\\" +
                ConfigurationManager.AppSettings["CaptchaFolder"] + "\\" +
                this.Session.SessionID.ToString() + ".png", System.Drawing.Imaging.ImageFormat.Png);
            Session["Captcha"] = new CaptchaViewModel
            {
                CaptchaText = text
            };
            return Json(this.Session.SessionID.ToString() + ".png?t=" + DateTime.Now.Ticks, JsonRequestBehavior.AllowGet);
        }
	}
}