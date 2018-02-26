using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Challenge_12_StudentCourses
{
    public class Enrollment
    {
        public int Grade { get; set; }
        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}