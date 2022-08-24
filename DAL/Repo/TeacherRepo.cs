using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class TeacherRepo : IRepo<Teacher, int, bool>
    {
        private OnlineEduEntities db;

        public TeacherRepo(OnlineEduEntities db)
        {
            this.db = db;
        }

        public bool Create(Teacher obj)
        {
            db.Teachers.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            db.Teachers.Remove(Get(id));
            return db.SaveChanges() > 0;
        }

        public List<Teacher> Get()
        {
            return db.Teachers.ToList();
        }

        public Teacher Get(int id)
        {
            return db.Teachers.Find(id);
        }

        public bool Update(Teacher obj)
        {
            var exist = db.Teachers.FirstOrDefault(x => x.Id == obj.Id);
            if (exist != null)
            {
                db.Entry(exist).CurrentValues.SetValues(obj);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
