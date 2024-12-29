using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab8
{
    public class CoopStudent : Student
    {
        public static int MaxWeeklyHours { get; set; }
        public static int MaxNumOfCourses { get; set; }

        public CoopStudent(string name) : base(name)
        {

        }

        public override void RegisterCourses(List<Course> selectedCourses)
        {
            //cheking courses amount
            if (selectedCourses.Count > CoopStudent.MaxNumOfCourses)
            {
                throw new Exception($"Your selection exceeds the maximum number of course: {CoopStudent.MaxNumOfCourses}");
            }
            int hours = 0;
            foreach (Course c in selectedCourses)
            {
                hours += c.WeeklyHours;
            }
            if (hours > CoopStudent.MaxWeeklyHours)
            {
                throw new Exception($"Your selection exeeds the maximum weekly hours: {CoopStudent.MaxWeeklyHours}");
            }
            // after validation we can run base method
            base.RegisterCourses(selectedCourses);
            return;
        }
        public override string ToString()
        {
            return ($"{Id} - {Name} (Coop)");
        }
    }
}