using DAL.EF;
using DAL.Interfaces;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        static OnlineEduEntities db = new OnlineEduEntities();

        public static IRepo<Student, int, bool> GetStudentDataAccess()
        {
            return new StudentRepo(db);
        }
        public static IRepo<Teacher, int, bool> GetTeacherDataAccess()
        {
            return new TeacherRepo(db);
        }
        public static IRepo<Cours, int, bool> GetCoursDataAccess()
        {
            return new CoursRepo(db);
        }
        public static IRepo<Admin, int, bool> GetAdminDataAccess()
        {
            return new AdminRepo(db);
        }
        public static IRepo<CourseStudentMap, int, bool> GetCoursStudentMapDataAccess()
        {
            return new CourseStudentMapRepo(db);
        }
        public static IRepo<LoginMatch, string, bool> GetLoginMatchDataAccess()
        {
            return new LoginMatchRepo(db);
        }
        public static IAuth<LoginMatch> GetAuthDataAccess()
        {
            return new LoginMatchRepo(db);
        }
        public static IRepo<Token, string, Token> GetTokenDataAccess()
        {
            return new TokenRepo(db);
        }
    }
}
