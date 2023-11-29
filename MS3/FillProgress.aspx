<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FillProgress.aspx.cs" Inherits="MS3.FillProgress" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id ="UpdateExtension" runat ="server">
            Fill Progress
          <br />
       
                  <br />

        <asp:Label ID="Label1" runat="server" Text="Thesis Serial Number:"></asp:Label>
    &nbsp;&nbsp;
        <asp:TextBox ID="thesisSerialNo" runat="server" Height="16px" Width="174px"></asp:TextBox>
        &nbsp;<br />
      

        <asp:Label ID="Label3" runat="server" Text="Progress Report Number:"></asp:Label>
    &nbsp;&nbsp;
        <asp:TextBox ID="progressReportNo" runat="server" Width="207px"></asp:TextBox>
        
         <br />
       <asp:Label ID="Label2" runat="server" Text="State"></asp:Label>
    &nbsp;&nbsp;

        <asp:TextBox ID="State" runat="server" Width="207px"></asp:TextBox>
                         <br />
         <asp:Label ID="Label4" runat="server" Text="Description"></asp:Label>
    &nbsp;&nbsp;

        <asp:TextBox ID="Description" runat="server" Width="207px"></asp:TextBox>
                         <br />
                                 <br />

        <asp:Button ID="Button1" runat="server" Text="Enter" OnClick="Enter" Width="220px" />
            </div>
    </form>
</body>
</html>
