<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddProgress.aspx.cs" Inherits="MS3.AddProgress" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #BackExtension {
            margin-bottom: 0px;
        }
    </style>
</head>
<body> 
    <form id="form1" runat="server">
       
        <div id ="UpdateExtension" runat ="server">
            
         Add Progress
          <br />
        <asp:Label ID="Label1" runat="server" Text="Thesis Serial Number:"></asp:Label>
    &nbsp;&nbsp;
        <asp:TextBox ID="thesisSerialNo" runat="server" Height="16px" Width="174px"></asp:TextBox>
        &nbsp;<br />
        
      
               <br />
  <asp:Button ID="Button1" runat="server" Text="Enter" OnClick="Enter" Width="220px" />
             </div>
        <div id ="BackExtension" runat ="server" >
              <asp:Button ID="Button2" runat="server" Text="Back to Home Page" OnClick="Back" Width="220px" />
                           <br />
               <br />

                          <asp:Button ID="Button3" runat="server" Text="Add Another Progress" OnClick="Another" Width="220px" />

            </div>
    </form>
</body>
</html>
