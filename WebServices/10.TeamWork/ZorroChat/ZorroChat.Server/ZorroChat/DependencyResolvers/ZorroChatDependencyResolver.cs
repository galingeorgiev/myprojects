using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace ZorroChat.DependencyResolvers
{
    public class ZorroChatDependencyResolver : IDependencyResolver
    {
        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            return null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new List<object>();
        }

        public void Dispose()
        {
        }
    }
}