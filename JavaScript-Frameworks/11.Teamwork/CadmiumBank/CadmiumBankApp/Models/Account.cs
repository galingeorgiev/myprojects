namespace CadmiumBankApp.Models
{
    using System.Collections.Generic;

    public class Account
    {
        public int Id { get; set; }

        public string Iban { get; set; }

        public decimal InterestRate { get; set; }

        public decimal Balance { get; set; }

        public string Description { get; set; }

        public virtual Currency Currency { get; set; }

        public virtual AccountType Type { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<TransactionLog> TransactionLogs { get; set; }

        public Account()
        {
            this.TransactionLogs = new HashSet<TransactionLog>();
        }

        public void UpdateWith(Account value)
        {
            if (value.InterestRate != 0.0M)
            {
                this.InterestRate = value.InterestRate;
            }

            if (!string.IsNullOrWhiteSpace(value.Description))
            {
                this.Description = value.Description;
            }

            if (value.Currency != null)
            {
                this.Currency = value.Currency;
            }

            if (value.Type != null)
            {
                this.Type = value.Type;
            }
        }
    }
}
