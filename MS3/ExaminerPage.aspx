<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExaminerPage.aspx.cs" Inherits="MS3.ExaminerPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Examiner Homepage</div>
        <asp:Button ID="Editinfo" runat="server" Text="Edit" OnClick="Editinfo_Click" Width="119px" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
        <br />
&nbsp;<asp:Button ID="Comment" runat="server" Text="Add Comment" Width="117px" OnClick="Comment_Click" />
&nbsp;&nbsp;<br />
        <br />
        <asp:Button ID="Grade" runat="server" Text="Add grade" Width="117px" OnClick="Grade_Click" />
        <br />
        <br />
        <asp:Button ID="List" runat="server" style="margin-top: 3px" Text="List" Width="112px" OnClick="List_Click" />
        <br />
        <br />
        <asp:Button ID="Search" runat="server" Text="SearchThesis" Width="110px" OnClick="Search_Click" />
        <br />
        <br />
    </form>
</body>
</html>
