using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab8
{
    public partial class RegisterCourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack == false)
            {
                List<Student> regStudentList = (List<Student>)Session["students"];

                // retrieve students from students dropdown list
                int index = 0;

                if (regStudentList != null)
                {
                    foreach (Student student in regStudentList)
                    {
                        selectedCoursesMsg.Visible = true;
                        // add current student to the checkboxes list
                        registeredStudentsList.Items.Add(student.ToString());
                        index++;

                        // update checbox's value to student's ID
                        registeredStudentsList.Items[index].Value = student.Id.ToString();
                    }
                }

                

                // getting all available courses in checkboxes list
                index = 0;

                // loop through available courses and populate checkboxes list
                foreach (Course course in Helper.GetAvailableCourses())
                {
                    coursesCheckboxList.Items.Add(new ListItem($"{course.Code} {course.Title} - {course.WeeklyHours} hours/week"));
                    coursesCheckboxList.Items[index].Value = course.Code;
                    index++;
                }
            }
        }
        protected void SaveCourses_Click(object sender, EventArgs e)
        {
            // extract registered students from session
            List<Student> registeredList = (List<Student>)Session["students"];
            int totalHours = 0;
            selectedCoursesMsg.Visible = true;

            // loop through courses checkboxes list
            int i = 0;
            List<Course> selectedCourses = new List<Course>();

            foreach (ListItem listItem in coursesCheckboxList.Items)
            {
                if (listItem.Selected == true)
                {
                    // retrieve course information from checkbox id
                    Course c = Helper.GetCourseByCode(listItem.Value);

                    // add current course to selected courses list
                    selectedCourses.Add(c);

                    // update hours from selected course weekly hours
                    totalHours += selectedCourses[i].WeeklyHours;
                    i++;
                }
            }

            // loop through registeredList and find student
            foreach (Student student in registeredList)
            {
                // if current student matches a registered student
                if (student.Id == int.Parse(registeredStudentsList.SelectedItem.Value))
                {
                    try
                    {
                        // call base class method to register courses
                        student.RegisterCourses(selectedCourses);
                        coursesErrorMsg.Visible = false;
                        Session["students"] = registeredList;
                        // update text
                        selectedCoursesMsg.Text = ($"Selected student has registred {student.RegisteredCourses.Count} courses, {totalHours} hours weekly");
                    }
                    catch (Exception msg)
                    {
                        selectedCoursesMsg.Visible = false;
                        coursesErrorMsg.Visible = true;
                        // handle exception
                        coursesErrorMsg.Text = msg.Message;
                    }
                }
            }
        }

        protected void selection_changed(object sender, EventArgs e)
        {
            coursesErrorMsg.Visible = false;

            // if selected item is not a default value
            if (registeredStudentsList.SelectedItem.Value != "unselected")
            {
                List<Student> regStudentList = (List<Student>)Session["students"];
                int totalHours = 0;
                selectedCoursesMsg.Visible = true;

                // loop through registeredList and find student
                int index = 0;
                foreach (Student s in regStudentList)
                {
                    if (s.Id == int.Parse(registeredStudentsList.SelectedItem.Value))
                    {
                        break;
                    }
                    index++;
                }

                // loop through courses checkboxeslist
                foreach (ListItem listItem in coursesCheckboxList.Items)
                {
                    // initially uncheck checbox
                    listItem.Selected = false;

                    foreach (Course c in regStudentList[index].RegisteredCourses)
                    {
                        // update checkbox is course matches in registered courses list
                        if (listItem.Value == c.Code.ToString())
                        {
                            totalHours += c.WeeklyHours;
                            // update checkbox selected value
                            listItem.Selected = true;
                            break;
                        }
                    }
                }

                // update message
                selectedCoursesMsg.Text = ($"Selected student has registred {regStudentList[index].RegisteredCourses.Count} courses, {totalHours} hours weekly");
            }
            else
            {
                // else if selected item is a default value, uncheck all checkboxes
                selectedCoursesMsg.Visible = false;
                foreach (ListItem lstItem in coursesCheckboxList.Items)
                {
                    lstItem.Selected = false;
                }
            }
        }

    }
}