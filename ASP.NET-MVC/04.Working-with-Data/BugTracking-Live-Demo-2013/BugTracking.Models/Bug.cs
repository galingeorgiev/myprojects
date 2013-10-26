using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracking.Models
{
    public class Bug
    {
        public int Id { get; set; }

        [Required(ErrorMessage="Poleto e zaduljitelno")]
        [StringLength(50,MinimumLength=10,ErrorMessage="Stringyt trqbva da e mejdu {1} i {2} simvola")]
        public string Title { get; set; }
                
        [StringContains("Steps to reproduce:", ErrorMessage="Your description should contains \"Steps to reproduce:\"")]
        public string Description { get; set; }

        [Display(Name="Created on")]
        public DateTime CreatedOn { get; set; }

        public Priority Priority { get; set; }

        // 1.23
        [RegularExpression(@"^\d\.\d{2}$", ErrorMessage="versiqta trqbva da e 1.23")]
        public string Version { get; set; }

        [Display(Name="Category")]
        public int CategoryId { get; set; }

        public virtual BugsCategory Category { get; set; }

        public virtual ApplicationUser Creator { get; set; }
    }
}
