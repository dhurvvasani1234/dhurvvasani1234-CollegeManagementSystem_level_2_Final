using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab8
{
    public class ParttimeStudent : Student
    {
        public static int MaxNumOfCourses { get; set; }

        public ParttimeStudent(string name) : base(name)
        {

        }

        public override void RegisterCourses(List<Course> selectedCourses)
        {
            // checking course's amount
            if (selectedCourses.Count > ParttimeStudent.MaxNumOfCourses)
            {
                throw new Exception($"Your selection exceeds the maximum number of course: {ParttimeStudent.MaxNumOfCourses}");
            }
            // after validation we can run base method
            base.RegisterCourses(selectedCourses);
            return;
        }

        public override string ToString()
        {
            return ($"{Id} - {Name} (Part time)");
        }
    }
}