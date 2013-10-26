using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Twitter.Models
{
    public class TweetViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        public TwitterUser User { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        public HashSet<string> Tags { get; set; }

        public TweetViewModel()
        {
            this.Tags = new HashSet<string>();
        }
    }
}