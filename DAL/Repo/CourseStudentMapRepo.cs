using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class CourseStudentMapRepo : IRepo<CourseStudentMap, int, bool>
    {
        private OnlineEduEntities db;

        public CourseStudentMapRepo(OnlineEduEntities db)
        {
            this.db = db;
        }

        public bool Create(CourseStudentMap obj)
        {
            db.CourseStudentMaps.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<CourseStudentMap> Get()
        {
            return db.CourseStudentMaps.ToList();
        }

        public CourseStudentMap Get(int id)
        {
            return db.CourseStudentMaps.Find(id);
        }

        public bool Update(CourseStudentMap obj)
        {
            throw new NotImplementedException();
        }
    }
}
