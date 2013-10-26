namespace FindNewsArticles
{
    using Newtonsoft.Json;
    using System.Runtime.Serialization;

    public class Article
    {
        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "url")]
        [JsonProperty("source_url")]
        public string Url { get; set; }

        public override string ToString()
        {
            return string.Format("Title: {0}; \nURL: {1}", this.Title, this.Url);
        }
    }
}
