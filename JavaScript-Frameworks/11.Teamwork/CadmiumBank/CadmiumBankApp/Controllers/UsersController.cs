namespace CadmiumBankApp.Controllers
{
    using AttributeRouting.Web.Http;
    using CadmiumBankApp.Data;
    using CadmiumBankApp.DTOs;
    using CadmiumBankApp.Models;
    using System;
    using System.Data;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Web.Http;

    public class UsersController : BaseApiController
    {
        private const int MinUsernameLength = 6;
        private const int MaxUsernameLength = 30;

        private const int MinFirstOrLastNameLength = 1;
        private const int MaxFirstOrLastNameLength = 50;

        private const string ValidUsernameCharacters = "qwertyuioplkjhgfdsazxcvbnmQWERTYUIOPLKJHGFDSAZXCVBNM1234567890_.";
        private const string ValidNameCharacters = "qwertyuioplkjhgfdsazxcvbnmQWERTYUIOPLKJHGFDSAZXCVBNM";
        private const string SessionKeyChars = "qwertyuioplkjhgfdsazxcvbnmQWERTYUIOPLKJHGFDSAZXCVBNM";

        private const int Sha1HashLength = 40;

        // POST api/users/register
        [HttpPost]
        [ActionName("register")]
        public HttpResponseMessage RegisterUser([FromBody]InputUserDto value)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
                () =>
                {
                    if (value == null)
                    {
                        throw new ArgumentException("Cannot register an empty user.");
                    }

                    this.ValidateUsername(value.Username);
                    this.ValidatePassword(value.Password);
                    this.ValidateFirstOrLastName(value.FirstName);
                    this.ValidateFirstOrLastName(value.LastName);

                    var db = new BankContext();

                    var user = db.Users.FirstOrDefault(u => u.Username == value.Username);

                    if (user != null)
                    {
                        throw new InvalidOperationException("User already exists.");
                    }

                    var role = db.Roles.FirstOrDefault(r => r.Name == "Private");

                    if (role == null)
                    {
                        throw new InvalidOperationException("No such role.");
                    }

                    user = new User()
                    {
                        Username = value.Username,
                        Password = value.Password,
                        FirstName = value.FirstName,
                        LastName = value.LastName,
                        Role = role
                    };

                    db.Users.Add(user);
                    db.SaveChanges();

                    string sessionKey = this.GenerateSessionKey(user.Id);
                    user.SessionKey = sessionKey;
                    db.SaveChanges();

                    var loggedUser = new LoggedUserDto()
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        SessionKey = sessionKey
                    };

                    var response = this.Request.CreateResponse(HttpStatusCode.Created, loggedUser);

                    return response;
                });

            return responseMsg;
        }

        // POST api/users/login
        [HttpPost]
        [ActionName("login")]
        public HttpResponseMessage LoginUser([FromBody]InputUserDto value)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
                () =>
                {
                    if (value == null)
                    {
                        throw new ArgumentException("Cannot login an empty user.");
                    }

                    this.ValidateUsername(value.Username);
                    this.ValidatePassword(value.Password);

                    var db = new BankContext();

                    var user = db.Users.FirstOrDefault(
                    u => u.Username == value.Username &&
                        u.Password == value.Password);

                    if (user == null)
                    {
                        throw new InvalidOperationException("Invalid username or password.");
                    }

                    if (user.SessionKey == null || user.SessionKey.Length != SessionKeyLength)
                    {
                        user.SessionKey = this.GenerateSessionKey(user.Id);
                        db.SaveChanges();
                    }

                    var loggedUser = new LoggedUserDto()
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Role = user.Role,
                        SessionKey = user.SessionKey
                    };

                    var response = this.Request.CreateResponse(HttpStatusCode.Accepted, loggedUser);

                    return response;
                });

            return responseMsg;
        }

        // POST api/users/logout
        [HttpPost]
        [ActionName("logout")]
        public HttpResponseMessage LogoutUser()
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
            () =>
            {
                var db = new BankContext();
                var user = this.ValidateAndGetLoggedUser(db);

                user.SessionKey = null;
                db.SaveChanges();

                var response = new HttpResponseMessage(HttpStatusCode.NoContent);
                return response;
            });

            return responseMsg;
        }

        // GET api/users/current
        [HttpGet]
        [GET("api/users/current")]
        public OutputUserDto GetCurrentUser()
        {
            return this.PerformOperationAndHandleExceptions(
                () =>
                {
                    var db = new BankContext();
                    var user = this.ValidateAndGetLoggedUser(db);

                    return new OutputUserDto
                    {
                        Id = user.Id,
                        Username = user.Username,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Role = user.Role
                    };
                });
        }

        // GET api/users
        [HttpGet]
        [GET("api/users")]
        public IQueryable<OutputUserDto> GetAllAdmin()
        {
            return this.PerformOperationAndHandleExceptions(
                () =>
                {
                    // TODO
                    var db = new BankContext();
                    // var loggedUser = this.ValidateAndGetLoggedUser(db);

                    var users =
                        from user in db.Users
                        select new OutputUserDto
                        {
                            Id = user.Id,
                            Username = user.Username,
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            Role = user.Role
                        };

                    return users;
                });
        }

        // GET api/users
        [HttpGet]
        [GET("api/users/{id}")]
        public OutputUserDto GetUserByIdAdmin(int id)
        {
            return this.PerformOperationAndHandleExceptions(
                () =>
                {
                    // TODO
                    var db = new BankContext();
                    // var loggedUser = this.ValidateAndGetLoggedUser(db);

                    var user = db.Users.FirstOrDefault(u => u.Id == id);
                    if (user == null)
                    {
                        throw new ArgumentException("No such user.");
                    }

                    return new OutputUserDto
                    {
                        Id = user.Id,
                        Username = user.Username,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Role = user.Role
                    };
                });
        }

        // PUT api/users/6/update
        [HttpPut]
        [GET("api/users/{id}/update")]
        [ActionName("update")]
        public HttpResponseMessage UpdateUserAdmin(int id, InputUserDto value)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
            () =>
            {
                var db = new BankContext();
                var loggedUser = this.ValidateAndGetLoggedUser(db);

                if (!ModelState.IsValid)
                {
                    throw new InvalidOperationException("Invalid model state.");
                }

                var userToUpdate = db.Users.FirstOrDefault(u => u.Id == id);

                if (userToUpdate == null)
                {
                    throw new ArgumentException(
                        string.Format("User with id = {0} doesn't exist.", id));
                }

                Role role = null;
                if (value.RoleId.HasValue)
                {
                    role = db.Roles.FirstOrDefault(r => r.Id == value.RoleId);
                    if (role == null)
                    {
                        throw new ArgumentException("No such role.");
                    }
                }

                userToUpdate.UpdateWith(new User
                {
                    FirstName = value.FirstName,
                    LastName = value.LastName,
                    Role = role
                });

                db.Entry(userToUpdate).State = EntityState.Modified;
                db.SaveChanges();

                var response = new HttpResponseMessage(HttpStatusCode.NoContent);
                return response;
            });

            return responseMsg;
        }

        // PUT api/users
        [HttpPut]
        public HttpResponseMessage UpdateUser(InputUserDto value)
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

                Role role = null;
                if (value.RoleId.HasValue)
                {
                    role = db.Roles.FirstOrDefault(r => r.Id == value.RoleId);
                    if (role == null)
                    {
                        throw new ArgumentException("No such role.");
                    }
                }

                user.UpdateWith(new User
                {
                    FirstName = value.FirstName,
                    LastName = value.LastName,
                    Role = role
                });

                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();

                var response = new HttpResponseMessage(HttpStatusCode.NoContent);
                return response;
            });

            return responseMsg;
        }

        #region Private Methods

        private string GenerateSessionKey(int userId)
        {
            StringBuilder sessionKeyBuilder = new StringBuilder(SessionKeyLength);
            sessionKeyBuilder.Append(userId);
            while (sessionKeyBuilder.Length < SessionKeyLength)
            {
                var index = randomNumberGenerator.Next(SessionKeyChars.Length);
                sessionKeyBuilder.Append(SessionKeyChars[index]);
            }

            return sessionKeyBuilder.ToString();
        }

        private void ValidatePassword(string password)
        {
            if (password == null || password.Length != Sha1HashLength)
            {
                throw new ArgumentOutOfRangeException("Password should be encrypted");
            }
        }

        private void ValidateFirstOrLastName(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("Nickname cannot be null");
            }
            else if (name.Length < MinFirstOrLastNameLength)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("First/Last name must be at least {0} characters long",
                    MinFirstOrLastNameLength));
            }
            else if (name.Length > MaxFirstOrLastNameLength)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("First/Last name must be less than {0} characters long",
                    MaxFirstOrLastNameLength));
            }
            else if (name.Any(ch => !ValidNameCharacters.Contains(ch)))
            {
                throw new ArgumentOutOfRangeException(
                    "First/Last name must contain only Latin letters");
            }
        }

        private void ValidateUsername(string username)
        {
            if (username == null)
            {
                throw new ArgumentNullException("Username cannot be null");
            }
            else if (username.Length < MinUsernameLength)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Username must be at least {0} characters long",
                    MinUsernameLength));
            }
            else if (username.Length > MaxUsernameLength)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Username must be less than {0} characters long",
                    MaxUsernameLength));
            }
            else if (username.Any(ch => !ValidUsernameCharacters.Contains(ch)))
            {
                throw new ArgumentOutOfRangeException(
                    "Username must contain only Latin letters, digits, underscore and dot");
            }
        }

        #endregion
    }
}
