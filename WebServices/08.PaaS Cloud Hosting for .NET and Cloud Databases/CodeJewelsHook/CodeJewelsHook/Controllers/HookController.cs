using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Typesafe.Mailgun;

namespace CodeJewelsHook.Controllers
{
    public class HookController : ApiController
    {
        // GET api/hook
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/hook/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/hook
        public void Post([FromBody] Dictionary<string, object> content)
        {
            if (ConfigurationManager.AppSettings["disableHook"] == "false")
            {
                var buildReport = JsonConvert.SerializeObject(content);

                var mailgunKeyName = "MAILGUN_API_KEY";

                var mailClient = new MailgunClient("app16729.mailgun.org", ConfigurationManager.AppSettings[mailgunKeyName]);
                mailClient.SendMail(new System.Net.Mail.MailMessage("galin.georgiev@galingeorgiev.com", "galingeorgiev87@gmail.com")
                {
                    Subject = "Build Report",
                    Body = buildReport
                });
            }
        }

        // PUT api/hook/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/hook/5
        public void Delete(int id)
        {
        }
    }
}
