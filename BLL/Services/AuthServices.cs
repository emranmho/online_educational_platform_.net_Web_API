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
    public class AuthServices
    {

        public static TokenModel Authenticate(string email, string pass)
        {
            var user = DataAccessFactory.GetAuthDataAccess().Authenticate(email, pass);
            TokenModel tokenModel = null;

            var key = TokenGenerate();
            Token token = new Token();
            if (user != null)
            {

                if (user.type.Equals("student"))
                {
                    var s = DataAccessFactory.GetStudentDataAccess().Get().SingleOrDefault(x => x.Email.Equals(user.Email));


                    token.AutoToken = key;
                    token.CreatedAt = DateTime.Now;
                    token.UserId = s.Id;
                    token.Type = user.type;
                    var created_token = DataAccessFactory.GetTokenDataAccess().Create(token);
                    tokenModel = new TokenModel()
                    {
                        Id = created_token.Id,
                        AutoToken = created_token.AutoToken,
                        CreatedAt = DateTime.Now,
                        UserId = created_token.UserId,
                        Type = created_token.Type,
                        ExpiredAt = null
                    };
                }
                else if (user.type.Equals("admin"))
                {
                    var a = DataAccessFactory.GetAdminDataAccess().Get().SingleOrDefault(x => x.Email.Equals(user.Email));


                    token.AutoToken = key;
                    token.CreatedAt = DateTime.Now;
                    token.UserId = a.Id;
                    token.Type = user.type;
                    var created_token = DataAccessFactory.GetTokenDataAccess().Create(token);
                    tokenModel = new TokenModel()
                    {
                        Id = created_token.Id,
                        AutoToken = created_token.AutoToken,
                        CreatedAt = DateTime.Now,
                        UserId = created_token.UserId,
                        Type = created_token.Type,
                        ExpiredAt = null
                    };
                }
                else if (user.type.Equals("teacher"))
                {
                    var t = DataAccessFactory.GetTeacherDataAccess().Get().SingleOrDefault(x => x.Email.Equals(user.Email));


                    token.AutoToken = key;
                    token.CreatedAt = DateTime.Now;
                    token.UserId = t.Id;
                    token.Type = user.type;
                    var created_token = DataAccessFactory.GetTokenDataAccess().Create(token);
                    tokenModel = new TokenModel()
                    {
                        Id = created_token.Id,
                        AutoToken = created_token.AutoToken,
                        CreatedAt = DateTime.Now,
                        ExpiredAt = null
                    };
                }


                //var key = TokenGenerate();
                //Token token = new Token();
                //token.AutoToken = key;
                //token.CreatedAt = DateTime.Now;
                //token.UserId = user.Id;
                //token.Type = user.type;
                //var created_token = DataAccessFactory.GetTokenDataAccess().Create(token);
                //tokenModel = new TokenModel()
                //{
                //    Id = created_token.Id,
                //    AutoToken = created_token.AutoToken,
                //    CreatedAt = DateTime.Now,
                //    ExpiredAt = DateTime.Now,
                //};
            }
            return tokenModel;
        }

        public static string TokenGenerate()
        {
            Random random = new Random();
            String str = "abcdefghijklmnopqrstuvwxyz";
            int size = 30;
            String ran = "";
            for (int i = 0; i < size; i++)
            {
                int x = random.Next(26);
                ran = ran + str[x];
            }
            return ran;
        }

        public static bool TokenValidity(string token)
        {
            var tok = DataAccessFactory.GetTokenDataAccess().Get(token);
            if (tok != null && tok.ExpiredAt == null)
            {
                return true;
            }
            return false;
        }

        public static bool Logout(TokenModel token)
        {
            var dtk = DataAccessFactory.GetTokenDataAccess().Get(token.AutoToken);
            dtk.ExpiredAt = DateTime.Now;
            return DataAccessFactory.GetTokenDataAccess().Update(dtk);
        }
    }
}
