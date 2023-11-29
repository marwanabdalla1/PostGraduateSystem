<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MS3.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Postgraduate Website"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Email:"></asp:Label>
            <br />
            <asp:TextBox ID="Email" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server"  Text="Password"></asp:Label>
            :<br />
            <asp:TextBox ID="Password" runat="server" >  </asp:TextBox>
        &nbsp;&nbsp;&nbsp;<br />
            <br />
            <asp:Button ID="SignIn" runat="server" Text="Sign in" OnClick="SignIn_Click" Width="297px" />
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label4" runat="server" Text="OR"></asp:Label>
            <br />
            <br />
            <asp:DropDownList ID="Title" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Height="23px" Width="148px">
                 <asp:ListItem Enabled="true" Text="Select Title" Value="-1"></asp:ListItem>
    <asp:ListItem Text="GUCian" Value="1"></asp:ListItem>
    <asp:ListItem Text="Non GUCian" Value="2"></asp:ListItem>
    <asp:ListItem Text="supervisor" Value="3"></asp:ListItem>
    <asp:ListItem Text="examiner" Value="4"></asp:ListItem>
            </asp:DropDownList>
            &nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Text="Create new account" OnClick="Register_Click" style="margin-left: 2px" Width="235px" />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
        </div>
    </form>
</body>
</html>
