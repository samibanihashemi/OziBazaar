using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OziBazaar.Framework.RenderEngine
{
    public interface IRenderEngine
    {
        string Render(IXMLRenderable component);
    }
}
