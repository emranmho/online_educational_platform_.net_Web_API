using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class TokenRepo : IRepo<Token, string, Token>
    {
        private OnlineEduEntities db;

        public TokenRepo(OnlineEduEntities db)
        {
            this.db = db;
        }

        public Token Create(Token obj)
        {
            db.Tokens.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<Token> Get()
        {
            throw new NotImplementedException();
        }
        public Token Get(string token)
        {
            return db.Tokens.FirstOrDefault(t => t.AutoToken.Equals(token));
        }
        public bool Update(Token obj)
        {
            var exist = db.Tokens.FirstOrDefault(x => x.AutoToken.Equals(obj.AutoToken));
            if (exist != null)
            {
                db.Entry(exist).CurrentValues.SetValues(obj);
                return db.SaveChanges() > 0;
            }
            return false;
        }
    }
}
