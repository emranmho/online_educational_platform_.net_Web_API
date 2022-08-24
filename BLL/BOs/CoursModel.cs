using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BOs
{
    public class CoursModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public double Cost { get; set; }
        public int Enroll { get; set; }


        //public string TeacherName { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<int> Teacher_Id { get; set; }

    }
}
