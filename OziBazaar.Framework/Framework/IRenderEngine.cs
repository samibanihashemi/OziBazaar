using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OziBazaar.Framework.Framework
{
    public interface IRenderEngine
    {
        string Render(IXMLRenderable component);
    }
}
