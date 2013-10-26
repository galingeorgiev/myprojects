namespace CadmiumBankApp.Controllers
{
    using CadmiumBankApp.Data;
    using CadmiumBankApp.Models;
    using System.Linq;
    using System.Web.Http;

    public class AccountTypesController : BaseApiController
    {
        // GET api/accounttypes
        [HttpGet]
        public IQueryable<AccountType> GetAll()
        {
            return this.PerformOperationAndHandleExceptions(
                () =>
                {
                    var db = new BankContext();
                    var user = this.ValidateAndGetLoggedUser(db);

                    return db.AccountTypes.AsQueryable();
                });
        }
    }
}
