<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupervisorRegister.aspx.cs" Inherits="MS3.SupervisorRegister" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Supervisor Sign Up</div>
                  <br />

        <asp:Label ID="Label1" runat="server" Text="First name:"></asp:Label>
    &nbsp;&nbsp;
        <asp:TextBox ID="FirstName" runat="server" Height="16px" Width="174px"></asp:TextBox>
        &nbsp;<br />
        <br />
&nbsp;<asp:Label ID="Label2" runat="server" Text="Last Name:"></asp:Label>
        &nbsp;
        <asp:TextBox ID="LastName" runat="server" Width="171px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Email: "></asp:Label>
        &nbsp;
        <asp:TextBox ID="Email" runat="server" Width="207px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Password: "></asp:Label>
        &nbsp;
        <asp:TextBox ID="Password" runat="server" Width="183px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label5" runat="server" Text="Faculty"></asp:Label>
        :&nbsp;&nbsp;
        <asp:TextBox ID="Faculty" runat="server" Width="192px"></asp:TextBox>
        <br />
        <br />
        
        <br />
        <asp:Button ID="SignUp" runat="server" Text="Sign Up" Width="268px" OnClick="SignUp_Click" />
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
