using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BOs
{
    public class CourseStudentMapModel
    {
        public int Id { get; set; }
        public Nullable<int> CourseId { get; set; }
        public Nullable<int> StudentId { get; set; }

        public virtual Cours Cours { get; set; }
        public virtual Student Student { get; set; }
    }
}
