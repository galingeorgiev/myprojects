using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BugTracking.Startup))]
namespace BugTracking
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}
