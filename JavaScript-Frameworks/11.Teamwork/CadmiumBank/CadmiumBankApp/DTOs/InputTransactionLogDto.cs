namespace CadmiumBankApp.DTOs
{
    using CadmiumBankApp.Models;
    using System;
    using System.Runtime.Serialization;

    [DataContract(Name="transactionLog")]
    public class InputTransactionLogDto
    {
        [DataMember(Name = "amount")]
        public decimal Amount { get; set; }

        [DataMember(Name = "currencyId")]
        public int? CurrencyId { get; set; }

        [DataMember(Name = "fromAccount")]
        public string FromAccountIban { get; set; }

        [DataMember(Name = "toAccount")]
        public string ToAccountIban { get; set; }

        [DataMember(Name = "toIban")]
        public string toIban { get; set; }
    }
}