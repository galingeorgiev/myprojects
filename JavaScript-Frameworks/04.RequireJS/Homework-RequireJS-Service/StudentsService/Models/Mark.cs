using System.Runtime.Serialization;
namespace StudentsService.Models
{
    [DataContract(Name = "marks")]
    public class Mark
    {
        [DataMember(Name="subject")]
        public string Subject { get; set; }

        [DataMember(Name="score")]
        public int Score { get; set; }

        public Mark(string subject, int score)
        {
            this.Subject = subject;
            this.Score = score;
        }
    }
}