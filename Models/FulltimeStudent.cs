using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab8
{
    public class FulltimeStudent : Student
    {
        public static int MaxWeeklyHours { get; set; }
        public FulltimeStudent(string name) : base (name)
        {

        }

        public override void RegisterCourses(List<Course> selectedCourses)
        {
            // Checking hours
            int hours = 0;
            foreach (Course c in selectedCourses)
            {
                hours += c.WeeklyHours;
            }
            if (hours > FulltimeStudent.MaxWeeklyHours)
            {
                throw new Exception($"Your selection exeeds the maximum weekly hours: {FulltimeStudent.MaxWeeklyHours}");
            }
            // after validation we can run base method
            base.RegisterCourses(selectedCourses);
            return;
        }
        public override string ToString()
        {
            return ($"{Id} - {Name} (Full time)");
        }
    }
}