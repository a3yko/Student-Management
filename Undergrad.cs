using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagment
{
    class Undergrad : Person
    {
        List<Course> courses = new List<Course>();
        public Undergrad(string fname, string lname, int age, int gender, int stdID)
        {
            base.FirstName = fname;
            base.LastName = lname;
            base.Age = age;
            base.Gender = gender;
            base.StuID = stdID;
        }

        public override void addCourse(Course c)
        {
            this.courses.Add(c);
        }

        public override List<Course> getCourses()
        {
            return this.courses;
        }

        public override double getGpa()
        {
            double d = 0;
            double n = 0;
            for (int i = 0; i < this.courses.Count; i++) {
               n += (this.courses[i].getcourseGpa() * this.courses[i].getcourseCredits());
               d += this.courses[i].getcourseCredits();
                
            }

            return (n/d);
        }
    }
}
