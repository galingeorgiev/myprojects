using RemoteData.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace RemoteData.Server.Controllers
{
    public class StudentController : ApiController
    {
        private readonly IStudentsRepository repository;
        private readonly string XmlFilePath = HttpContext.Current.Server.MapPath("~/Data/students.xml");

        public StudentController()
        {
            this.repository = new XMLStudentsRepository(XmlFilePath);
        }

        [ActionName("str")]
        public string GetStr()
        {
            return "<div style='border: 1px solid red;'>Yes, you can do it!</div>";
        }

        [HttpGet]
        [ActionName("all")]
        public HttpResponseMessage GetStudents()
        {
            var responseMessage = this.ExecuteOperation(() =>
            {
                return this.repository.GetStudents();
            });
            return responseMessage;
        }

        [HttpGet]
        [ActionName("details")]
        public HttpResponseMessage GetStudent(int id)
        {
            var responseMessage = this.ExecuteOperation(() =>
            {
                return this.repository.GetStudent(id);
            });
            return responseMessage;
        }

        [HttpPost]
        [ActionName("add")]
        public HttpResponseMessage AddStudent(Student st)
        {
            var responseMessage = this.ExecuteOperation(() =>
            {
                this.repository.AddStudent(st);
            });
            return responseMessage;
        }

        [HttpGet]
        [ActionName("delete")]
        public HttpResponseMessage DeleteStudent(int id)
        {
            var responseMessage = this.ExecuteOperation(() =>
            {
                this.repository.DeleteStudent(id);
            });
            return responseMessage;
        }
        
        private HttpResponseMessage ExecuteOperation(Action operation)
        {
            try
            {
                operation();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        private HttpResponseMessage ExecuteOperation<T>(Func<T> operation)
        {
            try
            {
                var result = operation();
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}