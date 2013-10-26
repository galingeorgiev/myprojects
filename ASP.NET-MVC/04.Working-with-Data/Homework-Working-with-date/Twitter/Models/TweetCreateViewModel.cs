using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Twitter.Models
{
    public class TweetCreateViewModel
    {
        public TwitterUser User { get; set; }

        [Required]
        [StringLength(140, MinimumLength = 1)]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        [Required]
        public string Tags { get; set; }
    }
}