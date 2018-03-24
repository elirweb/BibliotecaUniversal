using System.Collections.Generic;
using System.Web.Http;

namespace Api.Controllers
{
    public class ValuesController : ApiController
    {

        [Authorize(Roles = "admin")]
        public string Get()
        {
            
            return User.Identity.Name;
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
