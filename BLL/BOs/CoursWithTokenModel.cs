﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BOs
{
    public class CoursWithTokenModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public double Cost { get; set; }
     

        public string AutoToken { get; set; }//token
        //public string TeacherName { get; set; }
        
        public Nullable<int> Teacher_Id { get; set; }
    }
}
