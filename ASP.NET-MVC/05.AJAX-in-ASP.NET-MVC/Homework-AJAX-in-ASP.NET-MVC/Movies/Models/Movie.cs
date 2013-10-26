using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Movies.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Display(Name="Title")]
        [StringLength(200, MinimumLength = 1, ErrorMessage = "Movie title should be between 1 and 200 chars.")]
        public string Title { get; set; }

        [Display(Name = "Year")]
        [Range(1900, 2013, ErrorMessage = "Movie year should be after 1900 year.")]
        public int Year { get; set; }

        public Actor LeadingMaleRole { get; set; }

        public Actor LeadingFemaleRole { get; set; }

        [Display(Name="Studio name")]
        public string StudioName { get; set; }

        [Display(Name = "Studio address")]
        public string StudioAddress { get; set; }
    }
}