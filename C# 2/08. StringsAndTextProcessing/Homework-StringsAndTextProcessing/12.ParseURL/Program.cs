using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        string url = "http://www.devbg.org/forum/index.php ";
        var uri = new Uri(url);

        var protocol = uri.Scheme;
        var server = uri.Host;
        var resource = uri.PathAndQuery;

        Console.WriteLine("[protocol] = \"{0}\"", protocol);
        Console.WriteLine("[server] = \"{0}\"", server);
        Console.WriteLine("[resource] = \"{0}\"", resource);
    }
}
