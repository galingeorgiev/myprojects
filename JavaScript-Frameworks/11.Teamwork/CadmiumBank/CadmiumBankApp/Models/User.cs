namespace CadmiumBankApp.Models
{
    using System.Collections.Generic;

    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string SessionKey { get; set; }

        public virtual Role Role { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }

        public User()
        {
            this.Accounts = new HashSet<Account>();
        }

        public void UpdateWith(User value)
        {
            if (!string.IsNullOrWhiteSpace(value.FirstName))
            {
                this.FirstName = value.FirstName;
            }

            if (!string.IsNullOrWhiteSpace(value.LastName))
            {
                this.LastName = value.LastName;
            }

            if (value.Role != null)
            {
                this.Role = value.Role;
            }
        }
    }
}