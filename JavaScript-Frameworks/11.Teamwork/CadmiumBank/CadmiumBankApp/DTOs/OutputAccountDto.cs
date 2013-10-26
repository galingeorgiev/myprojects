namespace CadmiumBankApp.DTOs
{
    using CadmiumBankApp.Models;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class OutputAccountDto
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "iban")]
        public string Iban { get; set; }

        [DataMember(Name = "interestRate")]
        public decimal InterestRate { get; set; }

        [DataMember(Name = "balance")]
        public decimal Balance { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "type")]
        public AccountType Type { get; set; }

        [DataMember(Name = "currency")]
        public Currency Currency { get; set; }
    }
}