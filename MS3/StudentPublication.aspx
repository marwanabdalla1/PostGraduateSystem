<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentPublication.aspx.cs" Inherits="MS3.StudentPublication" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="Label1" runat="server" Text="Enter student ID:  "></asp:Label> &nbsp;

        <asp:TextBox ID="StudentID" runat="server"></asp:TextBox> &nbsp;

        <asp:Button ID="View" runat="server" Text="View Publications" OnClick="Publication_View" />
        <br /><br />

        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>

    </form>
</body>
</html>
