using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCTemplate.Startup))]
namespace MVCTemplate
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}
