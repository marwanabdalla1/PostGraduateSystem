<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LinkPublication.aspx.cs" Inherits="MS3.LinkPublication" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id ="NotFromPublication" runat ="server">
Link Publication           <br />

            <asp:Label ID="Label3" runat="server" Text="PublicationID:"></asp:Label>
    &nbsp;&nbsp;
        <asp:TextBox ID="PublicationID" runat="server" Height="16px" Width="174px"></asp:TextBox>
        &nbsp;<br />
        <asp:Label ID="Label1" runat="server" Text="Thesis Serial Number:"></asp:Label>
    &nbsp;&nbsp;
        <asp:TextBox ID="thesisSerialNo" runat="server" Height="16px" Width="174px"></asp:TextBox>
        &nbsp;<br />
              <asp:Button ID="Button1" runat="server" Text="Enter" OnClick="Link_Publication" Width="220px" />

        
        </div>




    </form>
</body>
</html>
