using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Word.Model
{
    public class Country
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Population { get; set; }

        public virtual Continent Continent { get; set; }

        public byte[] Flag { get; set; }

        public virtual ICollection<Town> Towns { get; set; }

        public Country()
        {
            this.Towns = new HashSet<Town>();
        }
    }
}
