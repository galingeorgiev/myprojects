using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Word.Model
{
    public class Continent
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Country> Countries { get; set; }

        public Continent()
        {
            this.Countries = new HashSet<Country>();
        }
    }
}
