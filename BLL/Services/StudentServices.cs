using BLL.BOs;
using DAL;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class StudentServices
    {
        public static List<StudentModel> Get()
        {
            var data = DataAccessFactory.GetStudentDataAccess().Get();
            var sdata = new List<StudentModel>();
            foreach (var item in data)
            {
                sdata.Add(new StudentModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Address = item.Address,
                    Phone = item.Phone,
                    DateOfBirth = item.DateOfBirth,
                    Email = item.Email,
                    Password = item.Password,
                    Type = item.Type,
                });
            }
            return sdata;
        }

        public static StudentModel GetById(int id)
        {
            var data = DataAccessFactory.GetStudentDataAccess().Get(id);
            var s = new StudentModel()
            {
                Id = data.Id,
                Name = data.Name,
                Address = data.Address,
                Phone = data.Phone,
                DateOfBirth = data.DateOfBirth,
                Email = data.Email,
                Password = data.Password
            };
            return s;
        }

        public static bool Create(StudentModel obj)
        {
            var st = new Student()
            {
                Id = obj.Id,
                Name = obj.Name,
                Address = obj.Address,
                Phone = obj.Phone,
                DateOfBirth = obj.DateOfBirth,
                Email = obj.Email,
                Password = obj.Password,
                Type = "student"
            };
            return DataAccessFactory.GetStudentDataAccess().Create(st);
        }

        public static bool Update(StudentModel obj)
        {
            var st = new Student()
            {
                Id = obj.Id,
                Name = obj.Name,
                Address = obj.Address,
                Phone = obj.Phone,
                DateOfBirth = obj.DateOfBirth,
                Email = obj.Email,
                Password = obj.Password,
                Type = "student"
            };
            return DataAccessFactory.GetStudentDataAccess().Update(st);
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.GetStudentDataAccess().Delete(id);
        }
        public static List<CoursModel> CourseList(TokenModel tk)
        {
            var dtk = DataAccessFactory.GetTokenDataAccess().Get(tk.AutoToken);
            var coursmap = DataAccessFactory.GetCoursStudentMapDataAccess().Get();
            var cours = DataAccessFactory.GetCoursDataAccess().Get();
            var finalCourseShow = (from c in cours
                                   where c.Status == 1 && c.Teacher_Id != null &&
                                   !(from s in coursmap where s.StudentId == dtk.UserId select s.CourseId).Contains(c.Id)
                                   select c);
            var sdata = new List<CoursModel>();
            foreach (var item in finalCourseShow)
            {
                sdata.Add(new CoursModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Cost = item.Cost,
                    Capacity = item.Capacity,
                    Enroll = item.Enroll, 
                    Status = item.Status,
                    Teacher_Id = item.Teacher_Id,
                });
            }
            return sdata;

        }
        public static List<CoursModel> MyCoursList(TokenModel tk)
        {
            var dtk = DataAccessFactory.GetTokenDataAccess().Get(tk.AutoToken);
            var coursmap = DataAccessFactory.GetCoursStudentMapDataAccess().Get().ToList();//.Where(c => c.StudentId == dtk.UserId).ToList();
            var cours = DataAccessFactory.GetCoursDataAccess().Get();

            //var finalShow = (from x in coursmap where x.StudentId == tk.UserId select x.CourseId).ToList();
            var f = (from c in cours where (from x in coursmap where x.CourseId == tk.UserId select x.CourseId).Contains(c.Id) select c);

            //var data = new List<CourseStudentMapModel>();
            var data1 = new List<CoursModel>();
            //foreach (var c in coursmap)
            //{
            //    data.Add(new CourseStudentMapModel()
            //    {
            //        Id = c.Id,
            //        CourseId = c.CourseId,
            //        StudentId = c.StudentId  
            //    });
            //}           
            foreach (var item in f)
            {
                data1.Add(new CoursModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Cost = item.Cost,
                    Capacity = item.Capacity,
                    Enroll = item.Enroll,
                    Description = item.Description,
                    Status = item.Status,
                    Teacher_Id = item.Teacher_Id,
                    // TeacherName=item.Cours.Teacher.Name
                });
            }
            return data1;
        }
        public static bool EnrollCours(CoursIDTokenModel obj)
        {
            var data = DataAccessFactory.GetCoursDataAccess().Get(obj.Id);
            var dtk = DataAccessFactory.GetTokenDataAccess().Get(obj.AutoToken);
            if(data.Capacity != data.Enroll)
            {
                var data2 = new CourseStudentMap()
                {
                    StudentId = dtk.UserId,
                    CourseId = obj.Id,             
                };
                DataAccessFactory.GetCoursStudentMapDataAccess().Create(data2);

                data.Enroll++;
            }
            return DataAccessFactory.GetCoursDataAccess().Update(data);
        }

    }
}
