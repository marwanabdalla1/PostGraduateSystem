<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddNumber.aspx.cs" Inherits="MS3.AddNumber" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Please enter number:"></asp:Label>
        </div>
        <br />
            <asp:TextBox ID="Number" runat="server"  OnTextChanged="Number_TextChanged" Width="217px"></asp:TextBox>
                <br />
 
                <br />
        <asp:Button ID="Button1" runat="server" Text="Enter" OnClick="Enter" Width="220px" />
        

    </form>
</body>

</html>
