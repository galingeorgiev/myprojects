using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JustCodeJewels.DTOs
{
    public class PostDto
    {
        public int PostId { get; set; }

        public string SourceCode { get; set; }

        public bool Vote { get; set; }

        public string AuthorMail { get; set; }

        public string Category { get; set; }
    }
}