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
    public class TeacherServices
    {
        public static List<TeacherModel> Get()
        {
            var data = DataAccessFactory.GetTeacherDataAccess().Get();
            var sdata = new List<TeacherModel>();
            foreach (var item in data)
            {
                sdata.Add(new TeacherModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Address = item.Address,
                    Phone = item.Phone,
                    Bio = item.Bio,
                    ExpartArea = item.ExpartArea,
                    AccountStatus = item.AccountStatus,
                    Email = item.Email,
                    Password = item.Password,
                    Type = item.Type,

                });
            }
            return sdata;
        }

        public static TeacherModel GetById(int id)
        {
            var data = DataAccessFactory.GetTeacherDataAccess().Get(id);
            var te = new TeacherModel()
            {
                Id = data.Id,
                Name = data.Name,
                Address = data.Address,
                Phone = data.Phone,
                Bio = data.Bio,
                ExpartArea = data.ExpartArea,
                Email = data.Email,
                AccountStatus = data.AccountStatus,
                Password = data.Password,
                Type = data.Type
            };
            return te;
        }

        public static bool Create(TeacherModel obj)
        {
            var te = new Teacher()
            {
                Id = obj.Id,
                Name = obj.Name,
                Address = obj.Address,
                Phone = obj.Phone,
                Bio = obj.Bio,
                ExpartArea = obj.ExpartArea,
                AccountStatus = 0,
                Email = obj.Email,
                Password = obj.Password,
                Type = "teacher"
            };
            return DataAccessFactory.GetTeacherDataAccess().Create(te);
        }

        public static bool Update(TeacherModel obj)
        {
            //var dtk = DataAccessFactory.GetTokenDataAccess().Get(tk.AutoToken);
            var te = new Teacher()
            {
                Id = obj.Id,
                Name = obj.Name,
                Address = obj.Address,
                Phone = obj.Phone,
                Bio = obj.Bio,
                ExpartArea = obj.ExpartArea,
                AccountStatus = 0,
                Email = obj.Email,
                Password = obj.Password,
                Type = "teacher"
            };
            return DataAccessFactory.GetTeacherDataAccess().Update(te);
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.GetTeacherDataAccess().Delete(id);
        }

        public static List<CoursModel> AvailableCourseList()
        {
            var data = DataAccessFactory.GetCoursDataAccess().Get().Where(c => c.Teacher_Id == null && c.Status == 1);
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
        public static List<CoursModel> MyCourseList(TokenModel tk)
        {
            var dtk = DataAccessFactory.GetTokenDataAccess().Get(tk.AutoToken);
            var data = DataAccessFactory.GetCoursDataAccess().Get().Where(c => c.Teacher_Id == dtk.UserId && c.Status == 1);
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
        public static List<CoursModel> PendingCoursList(TokenModel tk)
        {
            var dtk = DataAccessFactory.GetTokenDataAccess().Get(tk.AutoToken);
            var data = DataAccessFactory.GetCoursDataAccess().Get().Where(c => c.Teacher_Id == dtk.UserId && c.Status == -1);
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

        public static bool AddCours(CoursWithTokenModel obj)
        {
            var dtk = DataAccessFactory.GetTokenDataAccess().Get(obj.AutoToken);
            var c = new Cours()
            {
                Id = obj.Id,
                Name = obj.Name,
                Description = obj.Description,
                Capacity = obj.Capacity,
                Cost = obj.Cost,
                Enroll = 0,
                Status = -1,
                Teacher_Id = dtk.UserId
            };
            return DataAccessFactory.GetCoursDataAccess().Create(c);
        }

        public static bool UpdateCours(CoursWithTokenModel obj)
        {
            var dtk = DataAccessFactory.GetTokenDataAccess().Get(obj.AutoToken);
            var c = new Cours()
            {
                Id = obj.Id,
                Name = obj.Name,
                Description = obj.Description,
                Capacity = obj.Capacity,
                Cost = obj.Cost,
                Enroll = 0,
                Status = -1,
                Teacher_Id = dtk.UserId
            };            
            return DataAccessFactory.GetCoursDataAccess().Update(c);
        }
        public static bool DeleteCours(int id)
        {
           return DataAccessFactory.GetCoursDataAccess().Delete(id);
        }

        public static bool EnrollCours(CoursIDTokenModel obj)
        {
            var data = DataAccessFactory.GetCoursDataAccess().Get(obj.Id);
            var dtk = DataAccessFactory.GetTokenDataAccess().Get(obj.AutoToken);
            data.Status = 0;
            data.Teacher_Id = dtk.UserId;
            return DataAccessFactory.GetCoursDataAccess().Update(data);
        }
    }
}
