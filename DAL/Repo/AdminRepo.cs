using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class AdminRepo : IRepo<Admin, int, bool>
    {
        private OnlineEduEntities db;

        public AdminRepo(OnlineEduEntities db)
        {
            this.db = db;
        }

        public bool Create(Admin obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Admin> Get()
        {
            return db.Admins.ToList();
        }

        public Admin Get(int id)
        {
            return db.Admins.Find(id);
        }

        public bool Update(Admin obj)
        {
            var exist = db.Admins.SingleOrDefault(x => x.Id == obj.Id);
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
