<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterCourse.aspx.cs" Inherits="Lab8.RegisterCourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="APP_Themes/SiteStyles.css" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous">

    <title>Course Registration</title>
</head>
<body>
    <main>
        <div>
            <h1>Registrations</h1>
            <hr />

            <form id="form2" runat="server">
                <!-- row - 1 -->
                <div class="row">
                    <div class="col-1 center-div">
                        <label for="studentReg" class="maintext">Student:</label>
                    </div>

                    <div class="col-9">
                        <asp:DropDownList ID="registeredStudentsList" CssClass="dropdown"
                            AutoPostBack="True"
                            OnSelectedIndexChanged="selection_changed" runat="server">
                            <asp:ListItem Value="unselected" Text="-Select-"></asp:ListItem>
                        </asp:DropDownList>

                        <asp:RequiredFieldValidator ID="rfvType" runat="server" CssClass="errorMsg errorSpan"
                            ErrorMessage="Must select one!"
                            ForeColor="Red" ControlToValidate="registeredStudentsList"
                            InitialValue="unselected" Display="Static"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <!-- row - 1 -->

                <!-- row - 2 -->
                <div class="row">
                    <div class="col-12">
                        <div class="errorMsg">
                            <asp:Label runat="server" ID="coursesErrorMsg" Display="Static" Visible="false" class="badge bg-danger" />
                        </div>
                        
                    </div>

                    <div class="col-12">
                        <div class="coursesMsg">
                            <asp:Label runat="server" ID="selectedCoursesMsg" Display="Static" Visible="false"  class="badge bg-primary"></asp:Label>
                        </div>
                    </div>

                    <div class="col-12">
                        <br />
                        <h5>Following courses are currently available for registration:</h5>
                    </div>

                    <div class="col-12">
                        <asp:CheckBoxList ID="coursesCheckboxList" runat="server" SelectionMode="Multiple" />
                    </div>

                </div>
                <!-- row - 2 -->

                        <br />
                    <asp:Button ID="saveStudent" Text="Save" runat="server" OnClick="SaveCourses_Click"  class="btn btn-primary" />
                    <br />

                <br />
                <asp:HyperLink ID="addStudentLink" NavigateUrl="AddStudent.aspx" runat="server">Add Student</asp:HyperLink>

            </form>
        </div>
    </main>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-ka7Sk0Gln4gmtz2MlQnikT1wXgYsOg+OMhuP+IlRH9sENBO0LRn5q+8nbTov4+1p" crossorigin="anonymous"></script>
</body>
</html>
