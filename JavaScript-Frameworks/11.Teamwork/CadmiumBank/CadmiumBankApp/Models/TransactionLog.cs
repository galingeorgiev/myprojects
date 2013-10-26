namespace CadmiumBankApp.Models
{
    using System;

    public class TransactionLog
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }

        public virtual Currency Currency { get; set; }

        public DateTime Timestamp { get; set; }

        public virtual Account FromAccount { get; set; }

        public string ToIban { get; set; }

        public string Description { get; set; }
    }
}