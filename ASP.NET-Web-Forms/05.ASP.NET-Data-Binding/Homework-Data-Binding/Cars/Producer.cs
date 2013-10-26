using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car
{
    public class Producer
    {
        public string Name { get; set; }

        public IEnumerable<Model> Models { get; set; }
    }
}
