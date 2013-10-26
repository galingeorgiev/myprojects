namespace JustForum.Controllers
{
    using JustForum.Contexts;
    using JustForum.DTOs;
    using JustForum.Migrations;
    using JustForum.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Web.Http;

    public class UsersController : BaseApiController
    {
        private const int MinUsernameLength = 6;
        private const int MaxUsernameLength = 30;
        private const string ValidUsernameCharacters =
            "qwertyuioplkjhgfdsazxcvbnmQWERTYUIOPLKJHGFDSAZXCVBNM1234567890_.";
        private const string ValidNicknameCharacters =
            "qwertyuioplkjhgfdsazxcvbnmQWERTYUIOPLKJHGFDSAZXCVBNM1234567890_. -";

        private const string SessionKeyChars =
            "qwertyuioplkjhgfdsazxcvbnmQWERTYUIOPLKJHGFDSAZXCVBNM";
        private static readonly Random rand = new Random();

        private const int SessionKeyLength = 50;

        private const int Sha1Length = 40;

        public UsersController()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ForumContext, Configuration>());
        }

        // POST api/users/register
        [HttpPost]
        [ActionName("register")]
        public HttpResponseMessage PostRegisterUser([FromBody]UserDto userDto)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
                () =>
                {
                    if (userDto == null)
                    {
                        throw new ArgumentException("Cannot register an empty user.");
                    }

                    this.ValidateUsername(userDto.Username);
                    this.ValidateNickname(userDto.Nickname);
                    this.ValidateAuthCode(userDto.AuthCode);

                    var db = new ForumContext();

                    var user = db.Users.Where(u =>
                        u.Username.ToLower() == userDto.Username.ToLower() || u.Nickname.ToLower() == userDto.Nickname.ToLower())
                        .FirstOrDefault();

                    if (user != null)
                    {
                        throw new ApplicationException("User exist.");
                    }

                    user = new User()
                    {
                        Nickname = userDto.Nickname,
                        Username = userDto.Username,
                        AuthCode = userDto.AuthCode
                    };

                    db.Users.Add(user);
                    db.SaveChanges();

                    string sessionKey = this.GenerateSessionKey(user.Id);
                    user.SessionKey = sessionKey;
                    db.SaveChanges();

                    var userLogedIn = new UserLogedDto()
                    {
                        Nickname = user.Nickname,
                        SessionKey = sessionKey
                    };

                    var response = this.Request.CreateResponse(HttpStatusCode.Created,
                                            userLogedIn);

                    return response;
                });

            return responseMsg;
        }

        // POST api/users/login
        [HttpPost]
        [ActionName("login")]
        public HttpResponseMessage PostLoginUser([FromBody]UserDto userDto)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
                () =>
                {
                    if (userDto == null)
                    {
                        throw new ArgumentException("Cannot login an empty user.");
                    }

                    this.ValidateUsername(userDto.Username);
                    this.ValidateAuthCode(userDto.AuthCode);

                    var db = new ForumContext();

                    var user = db.Users.Where(u =>
                        u.AuthCode == userDto.AuthCode && u.Username.ToLower() == userDto.Username.ToLower())
                        .FirstOrDefault();

                    if (user == null)
                    {
                        throw new ApplicationException("User does exist.");
                    }

                    string sessionKey = this.GenerateSessionKey(user.Id);
                    user.SessionKey = sessionKey;
                    db.SaveChanges();

                    var userLogedIn = new UserLogedDto()
                    {
                        Nickname = user.Nickname,
                        SessionKey = sessionKey
                    };

                    var response = this.Request.CreateResponse(HttpStatusCode.Created,
                                            userLogedIn);

                    return response;
                });

            return responseMsg;
        }

        // PUT api/users/logout
        [HttpPut]
        [ActionName("logout")]
        public void LogoutUser([FromBody]UserLogedDto userLogedDto)
        {
            if (userLogedDto == null)
            {
                throw new ArgumentException("Cannot logout an empty user.");
            }

            var db = new ForumContext();

            var user = db.Users.Where(u => u.SessionKey == userLogedDto.SessionKey).FirstOrDefault();

            if (user == null)
            {
                throw new ApplicationException("Invalid session key.");
            }

            user.SessionKey = null;
            db.SaveChanges();
        }

        private string GenerateSessionKey(int userId)
        {
            StringBuilder skeyBuilder = new StringBuilder(SessionKeyLength);
            skeyBuilder.Append(userId);
            while (skeyBuilder.Length < SessionKeyLength)
            {
                var index = rand.Next(SessionKeyChars.Length);
                skeyBuilder.Append(SessionKeyChars[index]);
            }

            return skeyBuilder.ToString();
        }

        private void ValidateAuthCode(string authCode)
        {
            if (authCode == null || authCode.Length != Sha1Length)
            {
                throw new ArgumentOutOfRangeException("Password should be encrypted");
            }
        }

        private void ValidateNickname(string nickname)
        {
            if (nickname == null)
            {
                throw new ArgumentNullException("Nickname cannot be null");
            }
            else if (nickname.Length < MinUsernameLength)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Nickname must be at least {0} characters long",
                    MinUsernameLength));
            }
            else if (nickname.Length > MaxUsernameLength)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Nickname must be less than {0} characters long",
                    MaxUsernameLength));
            }
            else if (nickname.Any(ch => !ValidNicknameCharacters.Contains(ch)))
            {
                throw new ArgumentOutOfRangeException(
                    "Nickname must contain only Latin letters, digits .,_");
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
                    "Username must contain only Latin letters, digits .,_");
            }
        }
    }
}
