using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagment
{
    class Course
    {
        private int courseNum;
        private string courseName;
        private double courseCredits;
        private double courseGpa;
        public Course(string name, int num, double credits, double gpa)
        {
            this.courseName = name;
            this.courseNum = num;
            this.courseCredits = credits;
            this.courseGpa = gpa;
        }

        public int getcourseNum()
        {
            return this.courseNum;
        }

        public string getcourseName()
        {
            return this.courseName;
        }

        public double getcourseCredits()
        {
            return this.courseCredits;
        }

        public double getcourseGpa()
        {
            return this.courseGpa;
        }
    }
}
