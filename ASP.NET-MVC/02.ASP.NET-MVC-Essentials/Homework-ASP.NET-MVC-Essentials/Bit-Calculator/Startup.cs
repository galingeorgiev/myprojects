using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bit_Calculator.Startup))]
namespace Bit_Calculator
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}
