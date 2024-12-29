<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddStudent.aspx.cs" Inherits="Lab8.AddStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="APP_Themes/SiteStyles.css" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous">

    <title>Students</title>
</head>
<body>
    <main>
        <div>
            <h1>Students</h1>
            <hr />

            <form id="form1" runat="server">
                <!-- row - 1 -->
                <div class="row">
                    <div class="col-2">
                        <label for="studentName" class="maintext">Student Name:</label>
                    </div>

                    <div class="col-8">
                        <asp:TextBox runat="server" ID="studentName" CssClass="input"></asp:TextBox>

                        <asp:RequiredFieldValidator
                            ID="requiredFieldStudentName"
                            runat="server"
                            CssClass="errorMsg errorSpan"
                            ForeColor="Red"
                            Display="Static"
                            ControlToValidate="studentName"
                            EnableClientScript="true">
                            Required field!
                        </asp:RequiredFieldValidator>
                    </div>
                </div>
                <!-- row - 1 -->

                <br />

                <!-- row - 2 -->
                <div class="row">
                    <div class="col-2">
                        <label for="studentType" class="maintext">Student Type:</label>
                    </div>

                    <div class="col-8">
                        <asp:DropDownList ID="studentTypeList" class="dropdown" CssClass="dropdown" runat="server">
                            <asp:ListItem Value="unselected" Text="Select ..."></asp:ListItem>
                            <asp:ListItem Value="fullTime">Full Time</asp:ListItem>
                            <asp:ListItem Value="partTime">Part Time</asp:ListItem>
                            <asp:ListItem Value="coop">Co-op</asp:ListItem>
                        </asp:DropDownList>

                        <asp:RequiredFieldValidator ID="requiredFieldStudentType" runat="server" CssClass="errorMsg errorSpan"
                            ErrorMessage="Must select one!"
                            ForeColor="Red" ControlToValidate="studentTypeList"
                            InitialValue="unselected" Display="Static"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <!-- row - 2 -->

                <br />

                <asp:Button ID="cmdAdd" Text="Add" runat="server" OnClick="cmdAdd_Click" type="button" class="btn btn-primary" />

                <div>
                    <br />
                    <br />

                    <div>
                        <asp:Table ID="studentsTable" runat="server" CssClass="table table-striped">
                            <asp:TableHeaderRow>
                                <asp:TableHeaderCell>ID</asp:TableHeaderCell>
                                <asp:TableHeaderCell>Name</asp:TableHeaderCell>
                                <asp:TableHeaderCell>Type</asp:TableHeaderCell>
                            </asp:TableHeaderRow>
                            <asp:TableRow>
                                <asp:TableCell ID="CellOne" runat="server"></asp:TableCell>
                                <asp:TableCell ID="CellTwo" runat="server"></asp:TableCell>
                                <asp:TableCell ID="CellThree" runat="server"></asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </div>
                    <br />

                    <asp:HyperLink ID="registerCourseLink" NavigateUrl="RegisterCourse.aspx" runat="server">Register Courses</asp:HyperLink>
                </div>
            </form>
        </div>
    </main>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-ka7Sk0Gln4gmtz2MlQnikT1wXgYsOg+OMhuP+IlRH9sENBO0LRn5q+8nbTov4+1p" crossorigin="anonymous"></script>
</body>
</html>
