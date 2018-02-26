using Challenge_12_StudentCourses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Challenge_12_StudentCourses
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public List<Course> Courses { get; set; }
        public List<Enrollment> Enrollments { get; set; }




    }

}