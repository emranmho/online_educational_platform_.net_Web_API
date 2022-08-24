using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class StudentRepo : IRepo<Student, int, bool>
    {
        OnlineEduEntities db;
        public StudentRepo(OnlineEduEntities db)
        {
            this.db = db;
        }

        public bool Create(Student obj)
        {
            db.Students.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            db.Students.Remove(Get(id));
            return db.SaveChanges() > 0;
        }

        public Student Get(int id)
        {
            return db.Students.Find(id);
        }

        public List<Student> Get()
        {
            return db.Students.ToList();
        }

        public bool Update(Student obj)
        {
            var exist = db.Students.FirstOrDefault(x => x.Id == obj.Id);
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
