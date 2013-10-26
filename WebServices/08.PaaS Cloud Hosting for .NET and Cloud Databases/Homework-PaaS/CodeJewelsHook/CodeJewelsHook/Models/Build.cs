namespace CodeJewelsHook.Models
{
    public class Build
    {
        public int Id { get; set; }

        public Commit Commit { get; set; }

        public Branch Branch { get; set; }

        public string Status { get; set; }

        public string Url { get; set; }
    }
}