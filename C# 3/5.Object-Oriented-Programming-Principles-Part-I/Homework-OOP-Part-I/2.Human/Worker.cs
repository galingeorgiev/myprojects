using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Human
{
    class Worker : Human
    {
        private double weekSalary;
        private double workHoursPerDay;

        public Worker(string firstName, string lastName, double weekSalary, double workHoursPerDay)
            : base(firstName, lastName)
        {
            this.weekSalary = weekSalary;
            this.workHoursPerDay = workHoursPerDay;
        }

        public double WeekSalary
        {
            get { return this.weekSalary; }
        }

        public double WorkHoursPerDay
        {
            get { return this.workHoursPerDay; }
        }

        public double MoneyPerHour()
        {
            double moneyPerHour = weekSalary / (workHoursPerDay * 5);
            return moneyPerHour;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} - {2:f2}",this.FirstName, this.LastName, this.MoneyPerHour());
        }
    }
}
