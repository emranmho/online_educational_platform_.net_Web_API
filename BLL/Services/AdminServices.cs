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
    public class AdminServices
    {
        public static List<AdminModel> Get()
        {
            var data = DataAccessFactory.GetAdminDataAccess().Get();
            var sdata = new List<AdminModel>();
            foreach (var item in data)
            {
                sdata.Add(new AdminModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Address = item.Address,
                    Phone = item.Phone,
                    DateOfBirth = item.DateOfBirth,
                    Email = item.Email,
                    Password = item.Password,
                    Type=item.Type,
                });
            }
            return sdata;
        }
        public static AdminModel GetByIdAdmin(int id)
        {
            var data = DataAccessFactory.GetAdminDataAccess().Get(id);
            var ad = new AdminModel()
            {
                Id = data.Id,
                Name = data.Name,
                Address = data.Address,
                Phone = data.Phone,
                DateOfBirth = data.DateOfBirth,
                Email = data.Email,
                Password = data.Password
            };
            return ad;
        }
        public static bool UpdateAdmin(AdminModel obj,TokenModel tk)
        {
            var dtk = DataAccessFactory.GetTokenDataAccess().Get(tk.AutoToken);
            var a = new Admin()
            {
                Id=dtk.UserId,
                Name = obj.Name,
                Address = obj.Address,
                Phone = obj.Phone,
                DateOfBirth = obj.DateOfBirth,
                Email=obj.Email,
                Password=obj.Password,
                Type = obj.Type,
            };

            return DataAccessFactory.GetAdminDataAccess().Update(a);
        }


        //teacher get, create, update, delete by admin
       public static bool CreateTeacher(TeacherModel obj)
        {
            var te = new Teacher()
            {
                Id = obj.Id,
                Name = obj.Name,
                Address = obj.Address,
                Phone = obj.Phone,
                Bio = obj.Bio,
                ExpartArea = obj.ExpartArea,
                AccountStatus = 1,
                Email = obj.Email,
                Password = obj.Password,
                Type = "teacher"
            };
            return DataAccessFactory.GetTeacherDataAccess().Create(te);
        }
        public static Teacher GetById(int id)
        {
            return DataAccessFactory.GetTeacherDataAccess().Get(id);
        }
        public static bool UpdateTeacher(TeacherModel obj)
        {
           var te = new Teacher()
           {
                Id = obj.Id,
                Name = obj.Name,
                Address = obj.Address,
                Phone = obj.Phone,
                Bio = obj.Bio,
                ExpartArea = obj.ExpartArea,
                AccountStatus = 1,
                Email = obj.Email,
                Password = obj.Password,
                Type = "teacher"
           };
            return DataAccessFactory.GetTeacherDataAccess().Update(te);
        }

        public static bool DeleteTeacher(int id)
        {
            return DataAccessFactory.GetTeacherDataAccess().Delete(id);
        }


        //---------------------------------------------------------


        //cours get, create, update, delete, Course approve,suspand by admin
        public static List<CoursModel> CourseList()
        {
            var data = DataAccessFactory.GetCoursDataAccess().Get();
            var sdata = new List<CoursModel>();
            foreach (var item in data)
            {
                sdata.Add(new CoursModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Capacity = item.Capacity,
                    Cost = item.Cost,
                    Enroll = item.Enroll,
                    Status = item.Status,
                    Teacher_Id = item.Teacher_Id,
                });
            }
            return sdata;
        }
        public static bool AddCours(CoursModel obj)
        {            
            var c = new Cours()
            {
                Id = obj.Id,
                Name = obj.Name,
                Description = obj.Description,
                Capacity = obj.Capacity,
                Cost = obj.Cost,
                Enroll = 0,
                Status = 1,
                Teacher_Id = obj.Teacher_Id
            };
            return DataAccessFactory.GetCoursDataAccess().Create(c);
        }

        public static bool UpdateCours(CoursModel obj)
        {
            var c = new Cours()
            {
                Id = obj.Id,
                Name = obj.Name,
                Description = obj.Description,
                Capacity = obj.Capacity,
                Cost = obj.Cost,
                Enroll = 0,
                Status = 1,
                Teacher_Id = obj.Teacher_Id
            };           
            return DataAccessFactory.GetCoursDataAccess().Update(c);
            
        }
        public static bool DeleteCours(int id)
        {
            return DataAccessFactory.GetCoursDataAccess().Delete(id);
        }
        public static bool SuspandCours(int id)
        {
            var data = DataAccessFactory.GetCoursDataAccess().Get(id);
            if (data.Status == 1)
            {
                data.Status = -1;
                return DataAccessFactory.GetCoursDataAccess().Update(data);
            }
            else if (data.Status == -1)
            {
                data.Status = 1;
                return DataAccessFactory.GetCoursDataAccess().Update(data);
            }
            return false;
        }
        //public static List<CoursModel> CourseApprovalList()
        //{
        //    var data = DataAccessFactory.GetCoursDataAccess().Get().Where(x => x.Status == 0);
        //    var sdata = new List<CoursModel>();
        //    foreach (var item in data)
        //    {
        //        sdata.Add(new CoursModel()
        //        {
        //            Id = item.Id,
        //            Name = item.Name,
        //            Description = item.Description,
        //            Capacity = item.Capacity,
        //            Cost = item.Cost,
        //            Enroll = item.Enroll,
        //            Status = item.Status,
        //            Teacher_Id = item.Teacher_Id,
        //        });
        //    }
        //    return sdata;
        //}
        //public static bool ApprovalCourse(int id)
        //{
        //    var data = DataAccessFactory.GetCoursDataAccess().Get(id);
        //    data.Status = 1;
        //    return DataAccessFactory.GetCoursDataAccess().Update(data);
        //}


        //---------------------------------------------------------
        //student get, create, update, delete by admin
        public static List<StudentModel> GetStudent()
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
        public static Student GetByIdStudent(int id)
        {
            return DataAccessFactory.GetStudentDataAccess().Get(id);
        }

        public static bool CreateStudent(StudentModel obj)
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

        public static bool UpdateStudent(StudentModel obj)
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
        public static bool DeleteStudent(int id)
        {
            return DataAccessFactory.GetStudentDataAccess().Delete(id);
        }
    }
}
