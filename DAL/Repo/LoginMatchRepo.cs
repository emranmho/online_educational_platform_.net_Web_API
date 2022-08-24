using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class LoginMatchRepo : IRepo<LoginMatch, string, bool>, IAuth<LoginMatch>
    {
        private OnlineEduEntities db;

        public LoginMatchRepo(OnlineEduEntities db)
        {
            this.db = db;
        }

        public LoginMatch Authenticate(string email, string password)
        {
            return db.LoginMatches.FirstOrDefault(x => x.Email.Equals(email)
                                                  && x.Password.Equals(password));
        }

        public bool Create(LoginMatch obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<LoginMatch> Get()
        {
            throw new NotImplementedException();
        }

        public LoginMatch Get(string id)
        {
            throw new NotImplementedException();
        }

        public bool Update(LoginMatch obj)
        {
            throw new NotImplementedException();
        }
    }
}
