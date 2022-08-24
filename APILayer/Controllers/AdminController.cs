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
    
    public class AdminController : ApiController
    {
        [ValidLogin]
        [Route("api/admin")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = AdminServices.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

       // [AllowAnonymous]
        [Route("api/admin/{id}")]
        
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = AdminServices.GetByIdAdmin(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/admin/update")]
        [HttpPost]
        public HttpResponseMessage Update(AdminModel st,TokenModel obj)
        {
            var data = AdminServices.UpdateAdmin(st,obj);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        //teacher

        [Route("api/admin/getteacher")]
        [HttpGet]
        public HttpResponseMessage GetTeacher()
        {
            var data = TeacherServices.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/admin/createteacher")]
        [HttpPost]
        public HttpResponseMessage CreateTeacher(TeacherModel t)
        {
            var data = AdminServices.CreateTeacher(t);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/admin/updateteacher")]
        [HttpPost]
        public HttpResponseMessage UpdateTeacher(TeacherModel st)
        {
            var data = AdminServices.UpdateTeacher(st);
            return Request.CreateResponse(HttpStatusCode.OK, data);

        }

        [Route("api/admin/deleteteacher/{id}")]
        [HttpGet]
        public HttpResponseMessage DeleteTeacher(int id)
        {
            var data = AdminServices.DeleteTeacher(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        //Student

       
        [Route("api/admin/getstudent")]        
        [HttpGet]
        public HttpResponseMessage GetStudent()
        {
            var data = AdminServices.GetStudent();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/admin/createstudent")]
        [HttpPost]
        public HttpResponseMessage CreateStudent(StudentModel st)
        {
            var data = AdminServices.CreateStudent(st);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/admin/updatestudent")]
        [HttpPost]
        public HttpResponseMessage UpdateStudent(StudentModel st)
        {
            var data = AdminServices.UpdateStudent(st);
            return Request.CreateResponse(HttpStatusCode.OK, data);

        }

        [Route("api/admin/deletestudent/{id}")]
        [HttpGet]
        public HttpResponseMessage DeleteStudent(int id)
        {
            var data = AdminServices.DeleteStudent(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        //cours------------------------------------------------------

        [Route("api/admin/getcourslist")]
        [HttpGet]
        public HttpResponseMessage CourseList()
        {
            var data = AdminServices.CourseList();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/admin/addcours")]
        [HttpPost]
        public HttpResponseMessage AddCours(CoursModel co)
        {
            var data = AdminServices.AddCours(co);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/admin/updatecours")]
        [HttpPost]
        public HttpResponseMessage UpdateCours(CoursModel co)
        {
            var data = AdminServices.UpdateCours(co);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/admin/deletecours/{id}")]
        [HttpPost]
        public HttpResponseMessage DeleteCours(int id)
        {
            var data = AdminServices.DeleteCours(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/admin/suspandcours/{id}")]
        [HttpPost]
        public HttpResponseMessage SuspandCours(int id)
        {
            var data = AdminServices.SuspandCours(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        //[Route("api/admin/courseapprovallist")]
        //[HttpGet]
        //public HttpResponseMessage CourseApprovalList()
        //{
        //    var data = AdminServices.CourseApprovalList();
        //    return Request.CreateResponse(HttpStatusCode.OK, data);
        //}

        //[Route("api/admin/approvalcours/{id}")]
        //[HttpPost]
        //public HttpResponseMessage ApprovalCours(int id)
        //{
        //    var data = AdminServices.ApprovalCourse(id);
        //    return Request.CreateResponse(HttpStatusCode.OK, data);
        //}
    }
}
