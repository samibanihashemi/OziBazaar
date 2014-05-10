using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml.Xsl;
using OziBazaar.Framework.Models;
namespace OziBazaar.Framework.Framework
{
    public class ViewEngine
    {
        public static  string Render(ProductView product)
        {
             
            List<XElement> features = new List<XElement>();
         
            foreach (var feature in product.Features)
            {
                features.Add(new XElement("Feature", new XAttribute("Name", feature.FeatureName), new XAttribute("Value", feature.FeatureValue)));
              
            }
            XDocument inputXml =   new XDocument( new XElement("Features",features));

            return GenerateHTML(inputXml, "OziBazaar.Framework.Framework.DefaultProduct.xslt");
        }
        public static string Render(ProductAddView product)
        {

            List<XElement> features = new List<XElement>();

            foreach (var feature in product.Features)
            {
                var enumValue = string.Empty;
                if (feature.ValueEnum == null)
                    feature.ValueEnum = new List<string>();

                List<object> attributeList = new List<object>();
                attributeList.Add( new XAttribute("Name", feature.FeatureName));
                attributeList.Add(new XAttribute("EditorType", feature.EditorType));
                if (feature.ValueEnum != null)
                    attributeList.Add(SerializeList(feature.ValueEnum));
                if(!string.IsNullOrEmpty( feature.DependsOn ))
                    attributeList.Add(new XAttribute("DependsOn", feature.DependsOn));
                
                features.Add(new XElement("Feature", attributeList));

            }
            XDocument inputXml = new XDocument(new XElement("Features", features));
            return GenerateHTML(inputXml, "OziBazaar.Framework.Framework.AddProduct.xslt");
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
        private static string GenerateHTML(XDocument inputXml, string embededFileName)
        {
            
            XsltSettings xsltSettings = new XsltSettings(false, true);
            XslCompiledTransform xslt = new XslCompiledTransform();

            string resourceName = string.Format(embededFileName);
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                {
                    string message = string.Format("Embedded resource {0} not found", resourceName);
                    throw new ApplicationException(message);
                }
                xslt.Load(XmlReader.Create(stream), xsltSettings, new XmlUrlResolver());
            }

            //transform
            StringBuilder htmlContent = new StringBuilder();
            XmlWriter outputXmlWriter = XmlWriter.Create(htmlContent, new XmlWriterSettings { ConformanceLevel = ConformanceLevel.Auto });
            xslt.Transform(inputXml.CreateReader(), outputXmlWriter);

            return htmlContent.ToString();
        }
        //private string ConvertEnumToString(List)
    }
}