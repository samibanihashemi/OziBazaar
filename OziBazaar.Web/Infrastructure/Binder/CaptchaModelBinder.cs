using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OziBazaar.Web.Models;

namespace OziBazaar.Web.Infrastructure.Binder
{
    public class CaptchaModelBinder : IModelBinder
    {
        private const string sessionKey = "Captcha";
        
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            CaptchaViewModel captchaViewModel = (CaptchaViewModel)controllerContext.HttpContext.Session[sessionKey];
            if (captchaViewModel == null)
            {
                captchaViewModel = new CaptchaViewModel();
                controllerContext.HttpContext.Session[sessionKey] = captchaViewModel;
             }
            return captchaViewModel;
        }
    }
}
