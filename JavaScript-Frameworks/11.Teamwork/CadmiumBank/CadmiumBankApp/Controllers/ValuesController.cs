namespace CadmiumBankApp.Controllers
{
    using CadmiumBankApp.Data;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            using (var db = new BankContext())
            {
                return db.Roles.Select(x => x.Name).ToList();
            }
            //return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
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