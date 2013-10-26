namespace CadmiumBankApp.Controllers
{
    using AttributeRouting.Web.Http;
    using CadmiumBankApp.Data;
    using CadmiumBankApp.DTOs;
    using CadmiumBankApp.Models;
    using System;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Web.Http;

    public class AccountsController : BaseApiController
    {
        private const string IbanChars = "QWERTYUIOPLKJHGFDSAZXCVBNM1234567890";
        private const int IbanLength = 22;

        // POST api/accounts
        [HttpPost]
        public HttpResponseMessage CreateAccount([FromBody]InputAccountDto value)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
                () =>
                {
                    var db = new BankContext();
                    var user = this.ValidateAndGetLoggedUser(db);

                    var currency = db.Currencies.FirstOrDefault(c => c.Id == value.CurrencyId);
                    if (currency == null)
                    {
                        throw new ArgumentException("No such currency.");
                    }

                    var accountType = db.AccountTypes.FirstOrDefault(at => at.Id == value.TypeId);
                    if (accountType == null)
                    {
                        throw new ArgumentException("No such account type.");
                    }

                    if (ModelState.IsValid)
                    {
                        string iban = this.GenerateIban();
                        decimal interestRate = value.InterestRate ?? 7.8M;

                        var account = new Account
                        {
                            Iban = iban,
                            InterestRate = interestRate,
                            Balance = value.Balance.Value,
                            Description = value.Description,
                            Currency = currency,
                            Type = accountType,
                            User = user
                        };

                        db.Accounts.Add(account);
                        user.Accounts.Add(account);
                        db.SaveChanges();

                        var createdAccountDto = new OutputAccountDto()
                        {
                            Id = account.Id,
                            Iban = account.Iban,
                            InterestRate = account.InterestRate,
                            Balance = account.Balance,
                            Description = account.Description,
                            Currency = account.Currency,
                            Type = account.Type
                        };

                        var response = Request.CreateResponse(HttpStatusCode.Created, createdAccountDto);
                        return response;
                    }
                    else
                    {
                        throw new ApplicationException("Invalid model state.");
                    }
                });

            return responseMsg;
        }

        // GET api/accounts [sessionKey in header]
        [HttpGet]
        public IQueryable<OutputAccountDto> Get()
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
                () =>
                {
                    var db = new BankContext();
                    var user = this.ValidateAndGetLoggedUser(db);

                    var accounts =
                        from account in user.Accounts
                        select new OutputAccountDto
                        {
                            Id = account.Id,
                            Iban = account.Iban,
                            InterestRate = account.InterestRate,
                            Balance = account.Balance,
                            Description = account.Description,
                            Type = account.Type,
                            Currency = account.Currency
                        };

                    return accounts.AsQueryable();
                });

            return responseMsg;
        }

        // GET api/accounts/6
        [HttpGet]
        [GET("api/accounts/{id}")]
        public OutputAccountDto GetById(int id)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
                () =>
                {
                    var db = new BankContext();
                    var user = this.ValidateAndGetLoggedUser(db);

                    var account = user.Accounts.FirstOrDefault(a => a.Id == id);
                    if (account == null)
                    {
                        throw new ArgumentException("No such account.");
                    }

                    return new OutputAccountDto
                    {
                        Id = account.Id,
                        Iban = account.Iban,
                        InterestRate = account.InterestRate,
                        Balance = account.Balance,
                        Description = account.Description,
                        Type = account.Type,
                        Currency = account.Currency
                    };
                });

            return responseMsg;
        }

        // GET api/accounts?userId=6
        [HttpGet]
        public IQueryable<OutputAccountDto> GetByUserIdAdmin(int userId)
        {
            return this.PerformOperationAndHandleExceptions(
                () =>
                {
                    var db = new BankContext();
                    var loggedUser = this.ValidateAndGetLoggedUser(db);

                    var user = db.Users.FirstOrDefault(u => u.Id == userId);
                    if (user == null)
                    {
                        throw new ArgumentException("No such user.");
                    }

                    var accounts =
                        from account in user.Accounts
                        select new OutputAccountDto
                        {
                            Id = account.Id,
                            Iban = account.Iban,
                            InterestRate = account.InterestRate,
                            Balance = account.Balance,
                            Description = account.Description,
                            Type = account.Type,
                            Currency = account.Currency
                        };

                    return accounts.AsQueryable();
                });
        }

        // PUT api/accounts/6
        [HttpPut]
        public HttpResponseMessage UpdateAccount(int id, InputAccountDto value)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
            () =>
            {
                var db = new BankContext();
                var user = this.ValidateAndGetLoggedUser(db);

                if (!ModelState.IsValid)
                {
                    throw new InvalidOperationException("Invalid model state.");
                }

                var accountToUpdate = db.Accounts.FirstOrDefault(a => a.Id == id);
                if (accountToUpdate == null)
                {
                    throw new ArgumentException(
                        string.Format("Account with id = {0} doesn't exist.", id));
                }

                //if (accountToUpdate.User.Id != user.Id)
                //{
                //    throw new InvalidOperationException(
                //        string.Format(
                //        "Current user has id = {0} but the account belongs to user with id = {1}.",
                //        user.Id,
                //        accountToUpdate.User.Id));
                //}

                decimal interestRate = value.InterestRate ?? 0.0M;

                Currency currency = null;
                if (value.CurrencyId.HasValue)
                {
                    currency = db.Currencies.FirstOrDefault(c => c.Id == value.CurrencyId);
                    if (currency == null)
                    {
                        throw new ArgumentException("No such currency.");
                    }
                }

                AccountType type = null;
                if (value.TypeId.HasValue)
                {
                    type = db.AccountTypes.FirstOrDefault(at => at.Id == value.TypeId);
                    if (type == null)
                    {
                        throw new ArgumentException("No such account type.");
                    }
                }

                accountToUpdate.UpdateWith(new Account
                {
                    InterestRate = interestRate,
                    Description = value.Description,
                    Currency = currency,
                    Type = type
                });

                db.Entry(accountToUpdate).State = EntityState.Modified;
                db.SaveChanges();

                var response = new HttpResponseMessage(HttpStatusCode.NoContent);
                return response;
            });

            return responseMsg;
        }

        // PUT api/accounts/transfer
        [HttpPut]
        public HttpResponseMessage MakeTransfer(InputTransactionLogDto transaction)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
            () =>
            {
                var db = new BankContext();
                var user = this.ValidateAndGetLoggedUser(db);

                var fromAccount = db.Accounts.FirstOrDefault(a => a.Iban == transaction.FromAccountIban);
                if (fromAccount == null)
                {
                    throw new ArgumentException(
                        string.Format("Account with id = {0} doesn't exist.", transaction.FromAccountIban));
                }

                if (fromAccount.User.Id != user.Id)
                {
                    throw new InvalidOperationException(
                        string.Format(
                        "Current user has id = {0} but the account belongs to user with id = {1}.",
                        user.Id,
                        fromAccount.User.Id));
                }

                Currency currency = null;
                if (transaction.CurrencyId.HasValue)
                {
                    currency = db.Currencies.FirstOrDefault(c => c.Id == transaction.CurrencyId.Value);
                    if (currency == null)
                    {
                        throw new ArgumentException("No such currency.");
                    }
                }
                else
                {
                    currency = fromAccount.Currency;
                }

                Account toAccount = null;
                string toIban = null;
                string description = null;
                if (transaction.ToAccountIban != "")
                {
                    toAccount = db.Accounts.FirstOrDefault(a => a.Iban == transaction.ToAccountIban);
                    if (toAccount == null)
                    {
                        throw new ArgumentException("No such destination account.");
                    }

                    if (toAccount.User.Id != user.Id)
                    {
                        throw new InvalidOperationException(
                            string.Format(
                            "Current user has id = {0} but the destination account belongs to user with id = {1}.",
                            user.Id,
                            toAccount.User.Id));
                    }
                    description = "Transfer between user's accounts.";
                    toIban = toAccount.Iban;

                    toAccount.Balance += transaction.Amount;
                    db.Entry(toAccount).State = EntityState.Modified;
                }

                fromAccount.Balance -= transaction.Amount;
                db.Entry(fromAccount).State = EntityState.Modified;

                db.SaveChanges();

                if (toAccount == null)
                {
                    description = "Transfer to an external account.";
                    toIban = transaction.toIban;
                }

                db.TransactionLogs.Add(new TransactionLog
                {
                    Amount = transaction.Amount,
                    Currency = currency,
                    Timestamp = DateTime.Now,
                    FromAccount = fromAccount,
                    ToIban = toIban,
                    Description = description
                });

                db.SaveChanges();

                var response = new HttpResponseMessage(HttpStatusCode.NoContent);
                return response;
            });

            return responseMsg;
        }

        // GET api/accounts/6/transactionlogs
        [HttpGet]
        [ActionName("transactionlogs")]

        public IQueryable<OutputTransactionLogDto> GetTransactionLogsByAccountId(int id)
        {
            return this.PerformOperationAndHandleExceptions(
                () =>
                {
                    var db = new BankContext();

                    var user = this.ValidateAndGetLoggedUser(db);

                    var account = db.Accounts.Include(a => a.TransactionLogs).FirstOrDefault(a => a.Id == id);
                    if (account == null)
                    {
                        throw new ArgumentException("No such account.");
                    }

                    var transactionLogs =
                        from log in account.TransactionLogs
                        select new OutputTransactionLogDto
                        {
                            Id = log.Id,
                            Amount = log.Amount,
                            Currency = log.Currency.Name,
                            Timestamp = log.Timestamp,
                            FromIban = log.FromAccount.Iban,
                            ToIban = log.ToIban,
                            Description = log.Description
                        };

                    return transactionLogs.AsQueryable();
                });
        }

        #region Private Methods
        private string GenerateIban()
        {
            StringBuilder ibanBuilder = new StringBuilder(IbanLength);
            ibanBuilder.Append("BG");

            int controlDigit1 = randomNumberGenerator.Next(10);
            int controlDigit2 = randomNumberGenerator.Next(10);
            ibanBuilder.Append(controlDigit1);
            ibanBuilder.Append(controlDigit2);

            while (ibanBuilder.Length < IbanLength)
            {
                var index = randomNumberGenerator.Next(IbanChars.Length);
                ibanBuilder.Append(IbanChars[index]);
            }

            return ibanBuilder.ToString();
        }

        #endregion
    }
}
