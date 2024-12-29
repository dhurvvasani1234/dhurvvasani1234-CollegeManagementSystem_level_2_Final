using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab8
{
    public class Course
    {
        public string Code { get; }
        public string Title { get; }
        public int WeeklyHours { get; set; }

        // constructor to initialize Code & Title
        public Course(string code, string title)
        {
            Code = code;
            Title = title;
        }
    }
}