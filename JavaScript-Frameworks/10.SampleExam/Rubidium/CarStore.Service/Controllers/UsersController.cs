using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.ValueProviders;
using CarRentalSystem.API.Headears;
using CarStore.Model;
using CarStore.Service.Models;

namespace CarStore.Service.Controllers
{
    public class UsersController : BaseApiController
    {
        private const int SessionKeyLength = 50;
        private readonly Random rand = new Random();
        private const string SessionKeyChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        private const int Sha1CodeLength = 40;
        private const string ValidUsernameChars = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM_1234567890";
        private const string ValidNicknameChars = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM_1234567890 -";
        private const int MinUsernameNicknameChars = 6;
        private const int MaxUsernameNicknameChars = 30;

        public UsersController()
            : base(new CarStoreSystemContextFactory())
        {
        }

        public UsersController(IDbContextFactory<DbContext> contextFactory)
            : base(contextFactory)
        {
        }

        [HttpPost, ActionName("register")]
        public HttpResponseMessage PostRegisterUser(UserModel model)
        {
            return this.PerformOperationAndHandleExceptions(() =>
            {
                ValidateNickname(model.Nickname);
                ValidateUsername(model.Username);
                ValidateAuthCode(model.AuthCode);
                var usernameToLower = model.Username.ToLower();
                var context = this.ContextFactory.Create();
                using (context)
                {
                    var usersDbSet = context.Set<User>();
                    var entity = usersDbSet
                        .FirstOrDefault(usr => usr.Username == usernameToLower);
                    if (entity != null)
                    {
                        string responseMessage = "Username already taken";
                        HttpResponseMessage errResponse = this.Request.CreateErrorResponse(HttpStatusCode.Conflict, responseMessage);
                        throw new HttpResponseException(errResponse);
                    }

                    entity = new User()
                    {
                        Nickname = model.Nickname,
                        Username = model.Username.ToLower(),
                        AuthCode = model.AuthCode,
                        Amount = 100,
                    };

                    var role = context.Set<Role>().FirstOrDefault(r => r.Permission == "registered");
                    entity.Role = role;
                    entity.SessionKey = this.GenerateSessionKey(entity.Id);
                    usersDbSet.Add(entity);
                    context.SaveChanges();

                    var responseModel = new LoginResponseModel()
                    {
                        Nickname = entity.Nickname,
                        SessionKey = entity.SessionKey,
                        Amount = entity.Amount ?? 0
                    };

                    var response = this.Request.CreateResponse(HttpStatusCode.Created, responseModel);
                    return response;
                }
            });
        }

        [HttpPost, ActionName("login")]
        public HttpResponseMessage PostLoginUser(UserModel model)
        {
            return this.PerformOperationAndHandleExceptions(() =>
            {
                ValidateAuthCode(model.AuthCode);
                var context = this.ContextFactory.Create();
                using (context)
                {
                    var usernameToLower = model.Username.ToLower();
                    var modetlAutchCode = model.AuthCode;
                    var usersDbSet = context.Set<User>();
                    var entity = usersDbSet.SingleOrDefault(usr => usr.Username == usernameToLower && usr.AuthCode == modetlAutchCode);
                    if (entity == null)
                    {
                        var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid username or password");
                        throw new HttpResponseException(errResponse);
                    }

                    entity.SessionKey = this.GenerateSessionKey(entity.Id);


                    context.SaveChanges();

                    //catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                    //{
                    //    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    //    {
                    //        foreach (var validationError in validationErrors.ValidationErrors)
                    //        {
                    //            Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    //        }
                    //    }
                    //}

                    var responseModel = new LoginResponseModel()
                    {
                        Nickname = entity.Nickname,
                        SessionKey = entity.SessionKey,
                        Amount = entity.Amount ?? 0
                    };

                    var response = this.Request.CreateResponse(HttpStatusCode.Accepted, responseModel);
                    return response;
                }
            });
        }


        [HttpGet]
        [ActionName("myCars")]
        public IEnumerable<RentedCarsUser> GetRentedCars([ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            ValidateSessionKey(sessionKey);
            var response =
            this.PerformOperationAndHandleExceptions(() =>
            {
                var context = this.ContextFactory.Create();
                var usersDbSet = context.Set<User>();
                var user = usersDbSet.FirstOrDefault(u => u.SessionKey == sessionKey);

                if (user == null)
                {
                    var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid user authentication");
                    throw new HttpResponseException(errResponse);
                }

                var models =
                    (from userEntity in usersDbSet
                     select new UserFullModel()
                     {
                         Id = userEntity.Id,
                         Username = userEntity.Username,
                         Nickname = userEntity.Nickname,
                         AuthCode = userEntity.AuthCode,
                         SessionKey = userEntity.SessionKey,
                         Permission = userEntity.Role.Permission,
                         Amount = userEntity.Amount,
                         Cars = userEntity.Cars.AsQueryable().Select(CarModel.FromCar)
                     });

                var rentedCarModels = from car in user.Cars
                                      select new RentedCarsUser()
                                      {
                                          Id = car.CarId,
                                          DropOffDate = car.DropOffDate.Value,
                                          Make = car.Make,
                                          Model = car.Model,
                                          PickUpDate = car.PickUpDate.Value,
                                          PictureUrl = car.PictureUrl
                                      };

                return rentedCarModels;

            });
            return response;
        }

        [HttpPut]
        [ActionName("logout")]
        public HttpResponseMessage LogoutUser([ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            return this.PerformOperationAndHandleExceptions(() =>
            {
                ValidateSessionKey(sessionKey);
                var context = this.ContextFactory.Create();
                using (context)
                {
                    var usersDbSet = context.Set<User>();
                    var user = usersDbSet.FirstOrDefault(u => u.SessionKey == sessionKey);
                    if (user == null)
                    {
                        var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid user authentication");
                        throw new HttpResponseException(errResponse);
                    }

                    user.SessionKey = null;
                    context.SaveChanges();

                    var response = this.Request.CreateResponse(HttpStatusCode.NoContent);
                    return response;
                }
            });
        }

        [HttpPut]
        [ActionName("edit")]
        public HttpResponseMessage PutEditUser(int id, UserFullModel model,
          [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            return this.PerformOperationAndHandleExceptions(() =>
            {
                var context = this.ContextFactory.Create();
                var admin = this.LoginUser(sessionKey, context);

                var user = context.Set<User>().Find(id);
                if (user == null)
                {
                    var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.Conflict, "The user does not exist");
                    throw new HttpResponseException(errResponse);
                }
                if (admin.Role.Permission != "admin")
                {
                    var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, "You have no permissions to do change cars");
                    throw new HttpResponseException(errResponse);
                }
                if (model.Amount != null && model.Amount != user.Amount)
                {
                    user.Amount = model.Amount;
                }
                if (model.Nickname != null && model.Nickname != user.Nickname)
                {
                    user.Nickname = model.Nickname;
                }
                if (model.Permission != null && model.Permission != user.Role.Permission)
                {
                    var permission = context.Set<Role>().FirstOrDefault(r => r.Permission == model.Permission);
                    if (permission == null)
                    {
                        var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.Conflict, "Such permissions do not exists, they are admin registered and anonymous");
                        throw new HttpResponseException(errResponse);
                    }

                    user.Role = permission;
                }
                if (model.SessionKey != null && model.SessionKey != user.SessionKey)
                {
                    user.SessionKey = model.SessionKey;
                }
                if (model.AuthCode != null && model.AuthCode != user.AuthCode)
                {
                    user.AuthCode = model.AuthCode;
                }
                if (model.Username != null && model.Username != user.Username)
                {
                    user.Username = model.Username;
                }

                context.SaveChanges();
                var response = this.Request.CreateResponse(HttpStatusCode.NoContent);
                return response;
            });
        }

        public IQueryable<UserFullModel> GetAll([ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            return this.PerformOperationAndHandleExceptions(() =>
            {
                ValidateSessionKey(sessionKey);
                var context = this.ContextFactory.Create();

                var usersDbSet = context.Set<User>();
                var user = usersDbSet.FirstOrDefault(u => u.SessionKey == sessionKey);
                if (user == null || user.Role.Permission != "admin")
                {
                    var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid user authentication");
                    throw new HttpResponseException(errResponse);
                }

                var models =
                    (from userEntity in usersDbSet
                     select new UserFullModel()
                     {
                         Id = userEntity.Id,
                         Username = userEntity.Username,
                         Nickname = userEntity.Nickname,
                         AuthCode = userEntity.AuthCode,
                         SessionKey = userEntity.SessionKey,
                         Permission = userEntity.Role.Permission,
                         Amount = userEntity.Amount,
                         Cars = userEntity.Cars.AsQueryable().Select(CarModel.FromCar)
                     });

                return models;
            });
        }

        public UserFullModel GetById(int id, [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            return this.PerformOperationAndHandleExceptions(() =>
            {
                ValidateSessionKey(sessionKey);
                var context = this.ContextFactory.Create();
                using (context)
                {
                    var usersDbSet = context.Set<User>();
                    var searchedUser = usersDbSet.FirstOrDefault(u => u.Id == id);
                    var user = usersDbSet.FirstOrDefault(u => u.SessionKey == sessionKey);
                    if (user == null || user.Role.Permission != "admin")
                    {
                        var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid user authentication");
                        throw new HttpResponseException(errResponse);
                    }

                    if (searchedUser == null)
                    {
                        var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.NotFound, "No such user");
                        throw new HttpResponseException(errResponse);
                    }

                    var models =
                        new UserFullModel()
                        {
                            Id = searchedUser.Id,
                            Nickname = searchedUser.Nickname,
                            AuthCode = searchedUser.AuthCode,
                            SessionKey = searchedUser.SessionKey,
                            Permission = searchedUser.Role.Permission,
                            Amount = searchedUser.Amount,
                            Cars = searchedUser.Cars.AsQueryable().Select(CarModel.FromCar)
                        };

                    return models;
                }
            });
        }

        public HttpResponseMessage Delete(int id, [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            return this.PerformOperationAndHandleExceptions(() =>
            {
                ValidateSessionKey(sessionKey);
                var context = this.ContextFactory.Create();
                using (context)
                {
                    var usersDbSet = context.Set<User>();
                    var searchedUser = usersDbSet.FirstOrDefault(u => u.Id == id);
                    var user = usersDbSet.FirstOrDefault(u => u.SessionKey == sessionKey);
                    if (user == null || user.Role.Permission != "admin")
                    {
                        var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid user authentication");
                        throw new HttpResponseException(errResponse);
                    }

                    if (searchedUser == null)
                    {
                        var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.NotFound, "No such user");
                        throw new HttpResponseException(errResponse);
                    }

                    usersDbSet.Remove(searchedUser);
                    context.SaveChanges();
                    var response = this.Request.CreateResponse(HttpStatusCode.NoContent);
                    return response;
                }
            });
        }

        private string GenerateSessionKey(int userId)
        {
            StringBuilder keyChars = new StringBuilder(50);
            keyChars.Append(userId.ToString());
            while (keyChars.Length < SessionKeyLength)
            {
                int randomCharNum;
                lock (rand)
                {
                    randomCharNum = rand.Next(SessionKeyChars.Length);
                }
                char randomKeyChar = SessionKeyChars[randomCharNum];
                keyChars.Append(randomKeyChar);
            }
            string sessionKey = keyChars.ToString();
            return sessionKey;
        }

        private void ValidateUsername(string username)
        {
            if (username == null || username.Length < MinUsernameNicknameChars || username.Length > MaxUsernameNicknameChars)
            {
                throw new ArgumentException(string.Format("Username should be between {0} and {1} symbols long", MinUsernameNicknameChars, MaxUsernameNicknameChars));
            }
            else if (username.Any(ch => !ValidUsernameChars.Contains(ch)))
            {
                throw new ArgumentException("Username contains invalid characters");
            }
        }

        private void ValidateNickname(string nickname)
        {
            if (nickname == null || nickname.Length < MinUsernameNicknameChars || nickname.Length > MaxUsernameNicknameChars)
            {
                throw new ArgumentException(string.Format("Nickname should be between {0} and {1} symbols long", MinUsernameNicknameChars, MaxUsernameNicknameChars));
            }
            else if (nickname.Any(ch => !ValidNicknameChars.Contains(ch)))
            {
                throw new ArgumentException("Nickname contains invalid characters", "INV_NICK_CHARS");
            }
        }

        private void ValidateAuthCode(string authCode)
        {
            if (authCode.Length != Sha1CodeLength)
            {
                throw new ArgumentException("Invalid Password");
            }
        }

        private static void ValidateSessionKey(string sessionKey)
        {
            if (sessionKey.Length != SessionKeyLength || sessionKey.Any(ch => !SessionKeyChars.Contains(ch)))
            {
                throw new ArgumentException("Invalid user authentication");
            }
        }

    }
}
