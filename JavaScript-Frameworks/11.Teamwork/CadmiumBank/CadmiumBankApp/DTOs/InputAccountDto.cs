namespace CadmiumBankApp.DTOs
{
    using CadmiumBankApp.Models;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class InputAccountDto
    {
        [DataMember(Name = "interestRate")]
        public decimal? InterestRate { get; set; }

        [DataMember(Name = "balance")]
        public decimal? Balance { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "typeId")]
        public int? TypeId { get; set; }

        [DataMember(Name = "currencyId")]
        public int? CurrencyId { get; set; }
    }
}