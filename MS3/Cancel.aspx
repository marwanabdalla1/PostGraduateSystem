<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cancel.aspx.cs" Inherits="MS3.Cancel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="Label1" runat="server" Text="Enter Thesis Serial Number: "></asp:Label>&nbsp;

        <asp:TextBox ID="Serial" runat="server"></asp:TextBox>&nbsp;

        <asp:Button ID="CancelThesis" runat="server" Text="Cancel Thesis" OnClick="Cancel_Thesis" />

    </form>
</body>
</html>
