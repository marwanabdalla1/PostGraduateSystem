<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExaminerCourseGrade.aspx.cs" Inherits="MS3.ExaminerCourseGrade" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
            <asp:GridView ID="GridView1" runat="server" Height="16px" style="margin-right: 91px" Width="436px" AutoGenerateColumns="False" >
                <Columns>
                    <asp:BoundField DataField= "serialNumber" HeaderText="serialNumber" />
                    <asp:BoundField DataField="date" HeaderText="date" />
                    <asp:BoundField DataField="location" HeaderText="location" SortExpression="location" />
                    <asp:BoundField DataField="grade" HeaderText="grade" SortExpression="grade" />
                </Columns>
            </asp:GridView>
        </div>
        
        <asp:Label ID="Label1" runat="server" Text="Please enter the required information"></asp:Label>
        <br />
        <br />
        ThesisSerialNumber&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="SerialNumber" runat="server"></asp:TextBox>
        <br />
        <br />
        DefenseDate&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="DefenseDate" runat="server"></asp:TextBox>
        <br />
        <br />
        Grade&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="Grade" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Enter" runat="server" Text="Enter" Width="107px" OnClick="Enter_Click" />
            </div>
    </form>
</body>
</html>
