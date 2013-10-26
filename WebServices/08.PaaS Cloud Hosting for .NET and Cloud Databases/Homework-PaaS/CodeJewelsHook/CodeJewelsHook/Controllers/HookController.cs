using CodeJewelsHook.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Http;
using Typesafe.Mailgun;

namespace CodeJewelsHook.Controllers
{
    // I delete my app key from web.config
    public class HookController : ApiController
    {
        // POST api/hook
        public void Post([FromBody] Dictionary<string, object> content)
        {
            if (ConfigurationManager.AppSettings["disableHook"] == "false")
            {
                var buildReport = JsonConvert.SerializeObject(content);

                var response = JsonConvert.DeserializeObject<RootObject>(buildReport);

                var mailgunKeyName = "MAILGUN_API_KEY";

                // Change app16729.mailgun.org with your
                var mailClient =
                    new MailgunClient("app16729.mailgun.org", ConfigurationManager.AppSettings[mailgunKeyName]);
                // Enter From and To
                mailClient.SendMail(new System.Net.Mail.MailMessage("From", "To")
                {
                    Subject = response.Application.Name,
                    Body = response.Build.Commit.Message
                });
            }
        }
    }
}