using MyLaptopSystem.Models;
using System;
using System.Linq.Expressions;

namespace LaptopSystem.Web.Models
{
    public class LaptopBasicViewModel
    {
        public int Id { get; set; }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        public static Expression<Func<Laptop, LaptopBasicViewModel>> FromLaptop
        {
            get
            {
                return laptop => new LaptopBasicViewModel()
                {
                    Id = laptop.Id,
                    ImageUrl = laptop.ImageUrl,
                    Manufacturer = laptop.Manufacturer.Name,
                    Model = laptop.Model,
                    Price = laptop.Price
                };
            }
        }
    }
}