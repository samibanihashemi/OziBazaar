using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OziBazaar.Web.Areas.API.Controllers
{
    public class CategoryDataController : ApiController
    {

        // GET api/<controller>/toyota
        public IEnumerable<string> Get(string type)
        {
            List<string> types = new List<string>();
            if (type.ToLower() == "toyota")
            {
                types.Add("Camary");
                types.Add("Corola");
                types.Add("yari");
            }
            else if (type.ToLower() == "mazda")
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
            return types;
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}