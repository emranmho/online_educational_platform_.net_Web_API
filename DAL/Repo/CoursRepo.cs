using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class CoursRepo : IRepo<Cours, int, bool>
    {
        private OnlineEduEntities db;

        public CoursRepo(OnlineEduEntities db)
        {
            this.db = db;
        }

        public bool Create(Cours obj)
        {
            db.Courses.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            db.Courses.Remove(Get(id));
            return db.SaveChanges() > 0;
        }

        public List<Cours> Get()
        {
            return db.Courses.ToList();
        }

        public Cours Get(int id)
        {
            return db.Courses.Find(id);
        }

        public bool Update(Cours obj)
        {
            var exist = db.Courses.SingleOrDefault(x => x.Id == obj.Id);
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
