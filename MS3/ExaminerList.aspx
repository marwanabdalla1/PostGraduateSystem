<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExaminerList.aspx.cs" Inherits="MS3.ExaminerList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <br />
            <div>
            <asp:GridView ID="GridView1" runat="server" Height="16px" style="margin-right: 91px" Width="436px" AutoGenerateColumns="False" >
                <Columns>
                    <asp:BoundField DataField= "firstName" HeaderText="firstName" />
                    <asp:BoundField DataField= "lastName" HeaderText="lastName" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="FirstName" />
                    <asp:BoundField DataField="title" HeaderText="title" SortExpression="LastName" />
                </Columns>
            </asp:GridView>
        </div>
            <br />
            <br />
            <br />
            <br />
            <asp:Button ID="view" runat="server" Text="view" Width="105px" OnClick="view_Click" />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
