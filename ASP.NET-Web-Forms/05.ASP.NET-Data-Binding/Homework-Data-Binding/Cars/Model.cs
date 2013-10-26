using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car
{
    public class Model
    {
        public string Name { get; set; }

        public IEnumerable<Extra> Extras { get; set; }

        public EngineType EngineType { get; set; }
    }
}
