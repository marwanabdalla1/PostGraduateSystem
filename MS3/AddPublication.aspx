<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddPublication.aspx.cs" Inherits="MS3.AddPublication" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id ="UpdateExtension" runat ="server">
             Add Publication
          <br />
        <asp:Label ID="Label1" runat="server" Text="Title:"></asp:Label>
    &nbsp;&nbsp;
        <asp:TextBox ID="titleT" runat="server" Height="16px" Width="174px"></asp:TextBox>
        &nbsp;<br />
    
          <asp:Label ID="Label5" runat="server" Text="Publiction Date: (ex: mm/dd/yyyy)"></asp:Label>
    &nbsp;&nbsp; 
        <asp:TextBox ID="PubDate" runat="server" Width="207px"></asp:TextBox>  
            <br />
        <asp:Label ID="Label3" runat="server" Text="Host:"></asp:Label>
    &nbsp;&nbsp;
        <asp:TextBox ID="HostH" runat="server" Width="207px"></asp:TextBox>
        
         <br />
       <asp:Label ID="Label2" runat="server" Text="Place:"></asp:Label>
    &nbsp;&nbsp;
        <asp:TextBox ID="place" runat="server" Width="207px"></asp:TextBox>
               <br />   <asp:Label ID="Label4" runat="server" Text="Accepted:"></asp:Label>
 
            
        
             <asp:RadioButton ID="rdoButton1" GroupName="Group1" Text="Yes" Value="Yes"  runat="server" OnCheckedChanged="Group1_CheckedChanged" />
  <asp:RadioButton ID="rdoButton2" GroupName="Group1" Text="No" Value="No" runat="server" OnCheckedChanged="Group1_CheckedChanged" />

      
        
               <br />
  <asp:Button ID="Button1" runat="server" Text="Enter" OnClick="Enter" Width="220px" />
        </div>

         <br />
       <div id ="BackExtension" runat ="server" >
              <asp:Button ID="Button2" runat="server" Text="Back to Home Page" OnClick="Back" Width="220px" />
                           <br />
               <br />

                          <asp:Button ID="Button3" runat="server" Text="Link Thesis" OnClick="Link_Thesis" Width="220px" />

            </div>
    </form>
</body>
</html>

