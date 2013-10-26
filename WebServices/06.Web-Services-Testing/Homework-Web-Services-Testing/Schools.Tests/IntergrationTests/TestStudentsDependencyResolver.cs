namespace Schools.Tests.IntergrationTests
{
    using Schools.Controllers;
    using Schools.Models;
    using Schools.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Web.Http.Dependencies;

    class TestStudentsDependencyResolver<T> : IDependencyResolver where T : class
    {
        private IRepository<T> repository;

        public IRepository<T> Repository
        {
            get
            {
                return this.repository;
            }
            set
            {
                this.repository = value;
            }
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(StudentsController))
            {
                return new StudentsController(this.Repository as IRepository<Student>);
            }
            else if (serviceType == typeof(StudentsController))
            {
            }
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
