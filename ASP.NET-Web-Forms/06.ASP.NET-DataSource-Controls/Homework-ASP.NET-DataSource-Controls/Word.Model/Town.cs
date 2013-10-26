using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Word.Model
{
    public class Town
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Population { get; set; }

        public virtual Country Country { get; set; }
    }
}
