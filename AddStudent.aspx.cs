using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab8
{
    public partial class AddStudent : System.Web.UI.Page
    {
        List<Student> students = new List<Student>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["students"] == null)
            {
                // Defining a table row for no student output
                CellOne.ColumnSpan = 3;
                CellOne.Text = "No Students Yet!";
                CellOne.Style.Add("text-align", "center");
                CellOne.Style.Add("color", "red");
                CellOne.Style.Add("font-weight", "500");
                CellOne.Style.Add("background-color", "#f5f5f5");

                CellTwo.Visible = false;

                CellThree.Visible = false;
            }
            else
            {
                CellOne.Visible = false;
                CellTwo.Visible = false;
                CellThree.Visible = false;


                students = Session["students"] as List<Student>;
    
                if (!IsPostBack)
                {
                    populateStudentsList();
                }
            }
        }
        protected void cmdAdd_Click(object sender, EventArgs e)
        {
            // checking dropdown list
            if (!IsValid) return;

                if (studentTypeList.SelectedValue == "fullTime")
                {
                    Student s = new FulltimeStudent(studentName.Text);
                    students.Add(s);
                }
                if (studentTypeList.SelectedValue == "partTime")
                {
                    Student s = new ParttimeStudent(studentName.Text);
                    students.Add(s);
                }
                if (studentTypeList.SelectedValue == "coop")
                {
                    Student s = new CoopStudent(studentName.Text);
                    students.Add(s);
                }
            studentTypeList.SelectedValue = "unselected";
                studentName.Text = "";
                Session["students"] = students;

            if (students.Count != 0)
            {
                populateStudentsList();
            }
        }

        private void populateStudentsList()
        {
            // generate table with list of students
            CellOne.Visible = false;
            students = Session["students"] as List<Student>;

            // iterate through list of students from session variable
            foreach (Student student in students)
            {
                TableRow row = new TableRow();
                studentsTable.Rows.Add(row);

                TableCell cell = new TableCell();
                // cell one
                row.Cells.Add(cell);
                cell.Text = student.Id.ToString();

                // cell two
                cell = new TableCell();
                row.Cells.Add(cell);
                cell.Text = student.Name;

                // cell three
                cell = new TableCell();
                row.Cells.Add(cell);
                cell.Text = student.GetType().ToString().Remove(0, 5).Replace("Student", "");
            }
        }
    }
}