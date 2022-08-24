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
    public class TeacherController : ApiController
    {
        [ValidLogin]
        [Route("api/teacher")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = TeacherServices.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);

        }

        
        [Route("api/teacher/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = TeacherServices.GetById(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/createteacher")]
        [HttpPost]
        public HttpResponseMessage Create(TeacherModel te)
        {
            var data = TeacherServices.Create(te);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        //[Route("api/teacher/delete/{id}")]
        //[HttpGet]
        //public HttpResponseMessage Delete(int id)
        //{
        //    var data = TeacherServices.Delete(id);
        //    return Request.CreateResponse(HttpStatusCode.OK, data);
        //}

        ////[Route("api/student/update")]
        ////[HttpGet]
        ////public HttpResponseMessage Update(StudentModel st)
        ////{
        ////    var data = StudentServices.Update(st);
        ////    return Request.CreateResponse(HttpStatusCode.OK, data);

        ////}



        [Route("api/teacher/availablecourselist")]
        [HttpGet]
        public HttpResponseMessage AvailableCourseList()
        {
            var data = TeacherServices.AvailableCourseList();
            return Request.CreateResponse(HttpStatusCode.OK, data);

        }

        [Route("api/teacher/mycourselist")]
        [HttpPost]
        public HttpResponseMessage MyCourseList(TokenModel tk)
        {
            var data = TeacherServices.MyCourseList(tk);
            return Request.CreateResponse(HttpStatusCode.OK, data);

        }

        [Route("api/teacher/pendingcourselist")]
        [HttpPost]
        public HttpResponseMessage PendingCoursList(TokenModel tk)
        {
            var data = TeacherServices.PendingCoursList(tk);
            return Request.CreateResponse(HttpStatusCode.OK, data);

        }

        [Route("api/teacher/adddcours")]
        [HttpPost]
        public HttpResponseMessage AddCours(CoursWithTokenModel co)
        {
            var data = TeacherServices.AddCours(co);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/teacher/updatecours")]
        [HttpPost]
        public HttpResponseMessage UpdateCours(CoursWithTokenModel co)
        {
            var data = TeacherServices.UpdateCours(co);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/teacher/deletecours/{id}")]
        [HttpGet]
        public HttpResponseMessage DeleteCours(int id)
        {
            var data = TeacherServices.DeleteCours(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/teacher/enrollecours")]
        [HttpPost]
        public HttpResponseMessage DeleteCours(CoursIDTokenModel obj)
        {
            var data = TeacherServices.EnrollCours(obj);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
