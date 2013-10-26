using MyLaptopSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace LaptopSystem.Web.Models
{
    public class LaptopDetailsViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public double Monitor { get; set; }

        [Required]
        public int HardDisk { get; set; }

        [Required]
        public int Ram { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public decimal Price { get; set; }

        public double Weight { get; set; }

        public string AdditionalParts { get; set; }

        public string Description { get; set; }

        [Required]
        public string Manufacturer { get; set; }

        public int Votes { get; set; }

        public ICollection<CommentViewModel> Comments { get; set; }

        public static Expression<Func<Laptop, LaptopDetailsViewModel>> FromLaptop
        {
            get
            {
                return laptop => new LaptopDetailsViewModel()
                {
                    Id = laptop.Id,
                    AdditionalParts = laptop.AdditionalParts,
                    Description = laptop.Description,
                    HardDisk = laptop.HardDisk,
                    ImageUrl = laptop.ImageUrl,
                    Manufacturer = laptop.Manufacturer.Name,
                    Model = laptop.Model,
                    Monitor = laptop.Monitor,
                    Price = laptop.Price,
                    Ram = laptop.Ram,
                    Weight = laptop.Weight,
                    Votes = laptop.Votes.Count(),
                    Comments = laptop.Comments.AsQueryable().Select(CommentViewModel.FromComment).ToList()
                };
            }
        }
    }
}