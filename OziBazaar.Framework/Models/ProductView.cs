using OziBazaar.Framework.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace OziBazaar.Framework.Models
{
    public class ProductView : IXMLRenderable
    {
        private readonly string renderTemplate = "OziBazaar.Framework.Framework.DefaultProduct.xslt";
        public ProductView()
        {
            Features = new List<ProductFeatureView>();
        }
        public ProductView(string template):this()
        {
            renderTemplate = template;
        }
        public List<ProductFeatureView> Features { get; set; }

        public XDocument Render()
        {
            List<XElement> features = new List<XElement>();

            foreach (var feature in Features)
            {
                features.Add(new XElement("Feature", new XAttribute("Name", feature.FeatureName), new XAttribute("Value", feature.FeatureValue)));

            }
            XDocument inputXml = new XDocument(new XElement("Features", features));
            return inputXml;
        }


        public string Xsl
        {
            get { return renderTemplate ; }
        }
    }
}