namespace CadmiumBankApp.DTOs
{
    using CadmiumBankApp.Models;
    using System;
    using System.Runtime.Serialization;

    [DataContract(Name = "transactionLog")]
    public class OutputTransactionLogDto
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "amount")]
        public decimal Amount { get; set; }

        [DataMember(Name = "currency")]
        public string Currency { get; set; }

        [DataMember(Name = "timestamp")]
        public DateTime Timestamp { get; set; }

        [DataMember(Name = "fromIban")]
        public string FromIban { get; set; }

        [DataMember(Name = "toIban")]
        public string ToIban { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }
    }
}