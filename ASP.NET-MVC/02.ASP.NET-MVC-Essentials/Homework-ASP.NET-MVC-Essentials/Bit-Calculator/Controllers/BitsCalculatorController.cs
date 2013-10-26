using Bit_Calculator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bit_Calculator.Controllers
{
    public class BitsCalculatorController : Controller
    {
        [HttpGet]
        public ActionResult ShowBits(int quantity, string type, int kilo)
        {
            ViewBag.SelectedType = type;
            ViewBag.SelectedKilo = kilo;
            ViewBag.Quantity = quantity;
            double baseValue = this.BaseValue(kilo, type);
            var units = this.GetValues(kilo, quantity, baseValue);
            return View(units);
        }

        [HttpGet]
        public ActionResult Show()
        {
            var units = this.GetValues(1000, 1, 0.125);
            return View("ShowBits", units);
        }

        [NonAction]
        private List<UnitVM> GetValues(int baseValue, int quantity, double typeBase)
        {
            var listOfUnits = new List<UnitVM>() 
            {
                new UnitVM(){ Name = "Bit", Value = quantity / (Math.Pow(baseValue, 0)/typeBase) * 8},
                new UnitVM(){ Name = "Byte", Value = quantity / (Math.Pow(baseValue, 0)/typeBase)},
                new UnitVM(){ Name = "Kilobit", Value = quantity / (Math.Pow(baseValue, 1)/typeBase) * 8},
                new UnitVM(){ Name = "Kilobyte", Value = quantity / (Math.Pow(baseValue, 1)/typeBase)},
                new UnitVM(){ Name = "Megabit", Value = quantity / (Math.Pow(baseValue, 2)/typeBase) * 8},
                new UnitVM(){ Name = "Megabyte", Value = quantity / (Math.Pow(baseValue, 2)/typeBase)},
                new UnitVM(){ Name = "Gigabit", Value = quantity / (Math.Pow(baseValue, 3)/typeBase) * 8},
                new UnitVM(){ Name = "Gigabyte", Value = quantity / (Math.Pow(baseValue, 3)/typeBase)},
                new UnitVM(){ Name = "Terabit", Value = quantity / (Math.Pow(baseValue, 4)/typeBase) * 8},
                new UnitVM(){ Name = "Terabyte", Value = quantity / (Math.Pow(baseValue, 4)/typeBase)},
                new UnitVM(){ Name = "Petabit", Value =  quantity / (Math.Pow(baseValue, 5)/typeBase) * 8},
                new UnitVM(){ Name = "Petabyte", Value = quantity / (Math.Pow(baseValue, 5)/typeBase)},
                new UnitVM(){ Name = "Exabit", Value = quantity / (Math.Pow(baseValue, 6)/typeBase) * 8},
                new UnitVM(){ Name = "Exabyte", Value = quantity / (Math.Pow(baseValue, 6)/typeBase)},
                new UnitVM(){ Name = "Zettabit", Value = quantity / (Math.Pow(baseValue, 7)/typeBase) * 8},
                new UnitVM(){ Name = "Zettabyte", Value = quantity / (Math.Pow(baseValue, 7)/typeBase)},
                new UnitVM(){ Name = "Yottabit", Value = quantity / (Math.Pow(baseValue, 8)/typeBase) * 8},
                new UnitVM(){ Name = "Yottabyte", Value = quantity / (Math.Pow(baseValue, 8)/typeBase)},
            };

            return listOfUnits;
        }

        [NonAction]
        private double BaseValue(int baseValue, string typeOfUnit)
        {
            var listOfUnits = new List<UnitVM>() 
            {
                new UnitVM(){ Name = "Bit", Value = (Math.Pow(baseValue, 0)/8)},
                new UnitVM(){ Name = "Byte", Value =  (Math.Pow(baseValue, 0))},
                new UnitVM(){ Name = "Kilobit", Value =  (Math.Pow(baseValue, 1)/8)},
                new UnitVM(){ Name = "Kilobyte", Value = (Math.Pow(baseValue, 1))},
                new UnitVM(){ Name = "Megabit", Value = (Math.Pow(baseValue, 2)/8)},
                new UnitVM(){ Name = "Megabyte", Value = (Math.Pow(baseValue, 2))},
                new UnitVM(){ Name = "Gigabit", Value = (Math.Pow(baseValue, 3)/8)},
                new UnitVM(){ Name = "Gigabyte", Value = (Math.Pow(baseValue, 3))},
                new UnitVM(){ Name = "Terabit", Value = (Math.Pow(baseValue, 4)/8)},
                new UnitVM(){ Name = "Terabyte", Value = (Math.Pow(baseValue, 4))},
                new UnitVM(){ Name = "Petabit", Value =  (Math.Pow(baseValue, 5)/8)},
                new UnitVM(){ Name = "Petabyte", Value = (Math.Pow(baseValue, 5))},
                new UnitVM(){ Name = "Exabit", Value = (Math.Pow(baseValue, 6)/8)},
                new UnitVM(){ Name = "Exabyte", Value = (Math.Pow(baseValue, 6))},
                new UnitVM(){ Name = "Zettabit", Value = (Math.Pow(baseValue, 7)/8)},
                new UnitVM(){ Name = "Zettabyte", Value = (Math.Pow(baseValue, 7))},
                new UnitVM(){ Name = "Yottabit", Value = (Math.Pow(baseValue, 8)/8)},
                new UnitVM(){ Name = "Yottabyte", Value = (Math.Pow(baseValue, 8))},
            };

            double value = listOfUnits.FirstOrDefault(u => u.Name == typeOfUnit).Value;
            return value;
        }
    }
}