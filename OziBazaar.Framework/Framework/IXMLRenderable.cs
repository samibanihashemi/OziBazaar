using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OziBazaar.Framework.Framework
{
    public interface IXMLRenderable
    {
        XDocument Render();
        string Xsl { get; }
    }
}
