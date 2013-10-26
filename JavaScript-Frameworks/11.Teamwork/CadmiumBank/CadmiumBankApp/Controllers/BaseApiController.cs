namespace CadmiumBankApp.Controllers
{
    using CadmiumBankApp.Data;
    using CadmiumBankApp.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Validation;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Web.Http;

    public class BaseApiController : ApiController
    {
        protected static readonly Random randomNumberGenerator = new Random();
        protected const int SessionKeyLength = 50;

        protected T PerformOperationAndHandleExceptions<T>(Func<T> operation)
        {
            try
            {
                return operation();
            }
            catch (DbEntityValidationException dbEx)
            {
                StringBuilder messageBuilder = new StringBuilder();
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        messageBuilder.AppendFormat("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }

                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, messageBuilder.ToString());
                throw new HttpResponseException(errResponse);
            }
            catch (Exception ex)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
                throw new HttpResponseException(errResponse);
            }
        }

        protected string GetHeaderValue(string key)
        {
            IEnumerable<string> values;

            if (Request.Headers.TryGetValues(key, out values))
            {
                return values.FirstOrDefault();
            }

            return null;
        }

        protected User ValidateAndGetLoggedUser(BankContext context)
        {
            var sessionKey = this.GetHeaderValue("X-SessionKey");
            if (sessionKey == null)
            {
                throw new ArgumentNullException("X-SessionKey", "No session key provided in the request header!");
            }

            if (sessionKey.Length != SessionKeyLength)
            {
                throw new ApplicationException("Session key doesn't have the required length.");
            }

            var user = context.Users.FirstOrDefault(u => u.SessionKey == sessionKey);

            if (user == null)
            {
                throw new ApplicationException("User not logged in.");
            }

            return user;
        }
    }
}