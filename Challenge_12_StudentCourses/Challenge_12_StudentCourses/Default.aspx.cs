using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Challenge_12_StudentCourses
{
    public partial class Default : System.Web.UI.Page
    {
        string result = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void assignment1Button_Click(object sender, EventArgs e)
        {
            /*
             * Create a List of Courses (add three example Courses ...
             * make up the details).  Each Course should have at least two
             * Students enrolled in them.  Use Object and Collection
             * Initializers.  Then, iterate through each Course and print
             * out the Course's details and the Students that are enrolled in
             * each Course.
             */

            List<Course> courses = new List<Course>()
            {
                new Course { CourseId = 1, Name = "Psychology 201", Students = new List<Student>
                {
                    //You do not have to use all three properties, as shown only two of three
                    //are used below:
                    new Student() { StudentId = 01, Name = "Jim Boy" },
                    new Student() { StudentId = 02, Name = "Carrie Korpy"}
                } },

                new Course { CourseId = 2, Name = "History 357", Students = new List<Student>
                {
                    new Student { StudentId = 02, Name = "Carrie Korpy" },
                    new Student { StudentId = 03, Name = "Connor O'Ghalleger" }
                } },

                new Course { CourseId = 3, Name = "Spanish 103", Students = new List<Student>
                {
                    new Student { StudentId = 04, Name = "Barbara Xan" },
                    new Student { StudentId = 05, Name = "Mags Noffer" }
                } }
            };

            foreach (var course in courses)
            {
                resultLabel.Text += String.Format("Course: {0} - {1}<br />", course.CourseId, course.Name);
                foreach (var student  in course.Students)
                {
                    resultLabel.Text += String.Format("Student: {0} - {1}<br />", student.StudentId, student.Name);
                }
            }
            


        }

        protected void assignment2Button_Click(object sender, EventArgs e)
        {
            /*
             * Create a Dictionary of Students (add three example Students
             * ... make up the details).  Use the StudentId as the 
             * key.  Each student must be enrolled in two Courses.  Use
             * Object and Collection Initializers.  Then, iterate through
             * each student and print out to the web page each Student's
             * info and the Courses the Student is enrolled in.
             */
            
            Course course1 = new Course() { CourseId = 1, Name = "Health 205" };
            Course course2 = new Course() { CourseId = 2, Name = "Sociology 303" };
            Course course3 = new Course() { CourseId = 3, Name = "Geology 222" };
            Course course4 = new Course() { CourseId = 4, Name = "Spacology 402" };

            Dictionary<int, Student> students = new Dictionary<int, Student>()
            {
                { 01, new Student { StudentId = 01, Name = "Gob Kennedy", Courses = new List<Course> {course1, course2 }}},
                { 02, new Student { StudentId = 02, Name = "Karen Nobleson", Courses = new List<Course> { course3, course2 }}},
                { 03, new Student { StudentId = 03, Name = "Bobby Mortonsen", Courses = new List<Course> { course1, course4}}}
            };
            

            /*
            Dictionary<int, Student> students = new Dictionary<int, Student>()
            {
                { 01, new Student { StudentId = 01, Name = "Gob Kennedy", Courses = new List<Course>
                {
                    new Course { CourseId = 1, Name = "Health 205"},
                    new Course { CourseId = 2, Name = "Sociology 303" }
                }
                } },
                { 02, new Student { StudentId = 02, Name = "Karen Nobleson", Courses = new List<Course>
                {
                    new Course { CourseId = 3, Name = "Geology 222"},
                    new Course { CourseId = 2, Name = "Sociology 303" }
                }
                } },
                { 03, new Student { StudentId = 03, Name = "Bobby Mortonsen", Courses = new List<Course>
                {
                    new Course { CourseId = 1, Name = "Health 205"},
                    new Course { CourseId = 4, Name = "Spacology 402" }
                }
                } }
            };
            */

            foreach (var student in students)
            {
                resultLabel.Text += String.Format("Student: {0} - {1}<br />", student.Key, student.Value.Name);
                foreach (var course in student.Value.Courses)
                {
                    resultLabel.Text += String.Format("Course: {0} - {1}<br />", course.CourseId, course.Name);
                }
                {

                }

            }

        }

        protected void assignment3Button_Click(object sender, EventArgs e)
        {
            /*
             * We need to keep track of each Student's grade (0 to 100) in a 
             * particular Course.  This means at a minimum, you'll need to add 
             * another class, and depending on your implementation, you will 
             * probably need to modify the existing classes to accommodate this 
             * new requirement.  Give each Student a grade in each Course they
             * are enrolled in (make up the data).  Then, for each student, 
             * print out each Course they are enrolled in and their grade.
             */

            //One Student:

            Student student = new Student();
            student.StudentId = 9;
            student.Name = "Nobody";
            student.Enrollments = new List<Enrollment>()
            {
                new Enrollment { Course = new Course { CourseId = 1, Name = "Herbology 301" }, Grade = 93 },
                new Enrollment { Course = new Course { CourseId = 2, Name = "Spacology 224 " }, Grade = 99 }
            };

            resultLabel.Text += String.Format("Student: {0} - {1}<br />", student.StudentId, student.Name);
            foreach (var enrollment in student.Enrollments)
            {
                resultLabel.Text += String.Format("Enrolled in: {0} - Grade: {1} <br />", enrollment.Course.Name, enrollment.Grade);
            }


            //Not working
            //List<Student> students = new List<Student>()
            //{
            //     new Student { StudentId = 01, Name = "Gumps no Jumps", Courses = new List<Course>
            //     {
            //         new Course { CourseId = 1, Name = "Herbology 301" }
            //     }, Enrollments = new List<Enrollment>
            //     {
            //         new Enrollment { Grade = 95 },
            //         new Enrollment { Grade = 44 } } }

            //};

            //foreach (var student in students)
            //{
            //    resultLabel.Text += String.Format("Student {0} - {1} - {2}<br />", student.StudentId, student.Name);
            //}


            //Not Working:
            //List<Student> students = new List<Student>()
            //{
            //    {  new Student { StudentId = 01, Name = "Gob Kennedy", Courses = new List<Course>
            //    {
            //        new Course { CourseId = 1, Name = "Health 205"},
            //        new Course { CourseId = 2, Name = "Sociology 303" }
            //    }, Enrollments = new List<Enrollment>
            //    {
            //        new Enrollment { Grade = 95 },
            //        new Enrollment { Grade = 80 }
            //    }

            //    } } };

            //foreach (var student in students)
            //{
            //    resultLabel.Text += String.Format("Student: {0} - {1}<br />", student.StudentId, student.Name);
            //    foreach (var course in student.Courses)
            //    {
            //        resultLabel.Text += String.Format("Course: {0} - {1}<br />", course.CourseId, course.Name);
            //        foreach (var grade in student.Enrollments)
            //        {
            //            resultLabel.Text += String.Format("- Grade: {0}<br />", grade.Grade);
            //        }
            //    }
            //    {

            //    }

            //}
        }
    }
}