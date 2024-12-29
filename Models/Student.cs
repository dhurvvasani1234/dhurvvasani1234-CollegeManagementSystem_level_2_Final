using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab8
{
    public class Student
    {
        public int Id { get; }
        public string Name { get; }
        public List<Course> RegisteredCourses { get; }

        // base constructor
        protected Student(string name)
        {
            Random accountNumberNew = new Random();
            Id = accountNumberNew.Next(100000, 999999);
            Name = name;
            RegisteredCourses = new List<Course>();
        }

        // Removes all elements in the RegisteredCourse and adds the selectedCourses to the RegisteredCourse
        public virtual void RegisterCourses(List<Course> selectedCourses)
        {
            RegisteredCourses.Clear();
            RegisteredCourses.AddRange(selectedCourses);
        }

        // This method returns the calculated total hours of all registered courses by the student
        public int TotalWeeklyHours()
        {
            int totalHours = 0;
            foreach (Course regCourse in RegisteredCourses)
            {
                //Course c = Helper.GetCourseByCode(regCourse.WeeklyHours);
                totalHours = totalHours + regCourse.WeeklyHours;
            }
            return totalHours;
        }
    }
  
}