using OziBazaar.Framework.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace OziBazaar.Framework.Models
{
    public class ProductAddView : IXMLRenderable
    {
        private readonly string renderTemplate = "OziBazaar.Framework.Framework.AddProduct.xslt";
        public ProductAddView()
        {
            Features = new List<ProductFeatureAdd>();
        }
        public ProductAddView(string template):this()
        {
            renderTemplate = template;
        }
        public List<ProductFeatureAdd> Features { get; set; }

        public System.Xml.Linq.XDocument Render()
        {
            List<XElement> features = new List<XElement>();

            foreach (var feature in Features)
            {
                var enumValue = string.Empty;
                if (feature.ValueEnum == null)
                    feature.ValueEnum = new List<string>();

                List<object> attributeList = new List<object>();
                attributeList.Add(new XAttribute("Name", feature.FeatureName));
                attributeList.Add(new XAttribute("EditorType", feature.EditorType));
                if (feature.ValueEnum != null)
                    attributeList.Add(SerializeList(feature.ValueEnum));
                if (!string.IsNullOrEmpty(feature.DependsOn))
                    attributeList.Add(new XAttribute("DependsOn", feature.DependsOn));

                features.Add(new XElement("Feature", attributeList));

            }
            XDocument inputXml = new XDocument(new XElement("Features", features));
            return inputXml;

        }
        static XElement SerializeList(List<string> lst)
        {
            string name = "Value";

            XElement root = new XElement("EnumValue");
            int cnt = 0;
            foreach (var item in lst)
            {
                root.Add(new XElement(name, item.ToString()));
                cnt++;
            }
            return root;

        }


        public string Xsl
        {
            get { return renderTemplate; }
        }
    }
}