namespace CadmiumBankApp.Controllers
{
    using CadmiumBankApp.Data;
    using CadmiumBankApp.Models;
    using System.Linq;
    using System.Web.Http;

    public class RolesController : BaseApiController
    {
        // GET api/roles
        [HttpGet]
        public IQueryable<Role> GetAll()
        {
            return this.PerformOperationAndHandleExceptions(
                () =>
                {
                    var db = new BankContext();
                    var user = this.ValidateAndGetLoggedUser(db);

                    return db.Roles.AsQueryable();
                });
        }
    }
}
