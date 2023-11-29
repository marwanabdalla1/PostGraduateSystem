<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupervisorPage.aspx.cs" Inherits="MS3.SupervisorPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Supervisor Homepage</div>
        <br />
        <asp:Button ID="NameAndYears" runat="server" Text="My Students" OnClick="Supervisor_Students" />
        <br /><br />
        <asp:Button ID="Publication" runat="server" Text="Students Publication" OnClick="Students_Publication" />
        <br /><br />

        <asp:Button ID="Defense" runat="server" Text="Defenses and Examiners" OnClick="Defense_redirect" />
        <br /><br />

        <asp:Button ID="Evaluate" runat="server" Text="Evaluate a progress report" OnClick="Evaluate_Redirect" />
        <br /><br />

        <asp:Button ID="Cancel" runat="server" Text="Cancel a Thesis" OnClick="Cancel_Redirect" />

    </form>
</body>
</html>
