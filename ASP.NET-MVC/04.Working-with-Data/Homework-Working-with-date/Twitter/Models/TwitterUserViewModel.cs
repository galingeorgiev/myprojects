using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Twitter.Models
{
    public class TwitterUserViewModel
    {
        [Key]
        public int Id { get; set; }

        public string Username { get; set; }

        public HashSet<TweetViewModel> Tweets { get; set; }

        public TwitterUserViewModel()
        {
            this.Tweets = new HashSet<TweetViewModel>();
        }
    }
}