using APILayer.Auth;
using BLL.BOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APILayer.Controllers
{
    public class StudentController : ApiController
    {
        [ValidLogin]
        [Route("api/student")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = StudentServices.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);

        }
        [Route("api/student/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = StudentServices.GetById(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/createstudent")]
        [HttpPost]
        public HttpResponseMessage Create(StudentModel st)
        {
            var data = StudentServices.Create(st);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/student/update")]
        [HttpPost]
        public HttpResponseMessage Update(StudentModel st)
        {
            var data = StudentServices.Update(st);
            return Request.CreateResponse(HttpStatusCode.OK, data);

        }
        [Route("api/student/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            var data = StudentServices.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }


        [Route("api/student/courselist")]
        [HttpGet]
        public HttpResponseMessage GetCourseList(TokenModel tk)
        {
            var data = StudentServices.CourseList(tk);
            return Request.CreateResponse(HttpStatusCode.OK, data);

        }

        [Route("api/student/mycourselist")]
        [HttpPost]
        public HttpResponseMessage GetMyCoursList(TokenModel tk)
        {
            var data = StudentServices.MyCoursList(tk);
            return Request.CreateResponse(HttpStatusCode.OK, data);

        }
        [Route("api/student/enrollcourse")]
        [HttpPost]
        public HttpResponseMessage EnrollACourse(CoursIDTokenModel tk)
        {
            var data = StudentServices.EnrollCours(tk);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
