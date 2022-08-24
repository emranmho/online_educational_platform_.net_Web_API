using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BOs
{
    public class TeacherModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Bio { get; set; }
        public string ExpartArea { get; set; }
        public int AccountStatus { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }
    }
}
