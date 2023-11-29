<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Defense.aspx.cs" Inherits="MS3.Defense" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Defense1" runat="server" Text="Add defense for a thesis" OnClick="Defense1_Click" />&nbsp;&nbsp;
            <asp:Button ID="Examiner1" runat="server" Text="Add Examiner for a defense" OnClick="Examiner1_Click" />
        </div>
        <br /><br />
        <div id="Extension1" runat="server">


            <asp:Label ID="Label1" runat="server" Text="Enter Defense Date: (MM/DD/YYYY)  "></asp:Label>&nbsp;
            <asp:TextBox ID="Date" runat="server"></asp:TextBox>
            <br /><br />
            <asp:Label ID="Label2" runat="server" Text="Enter Defense Location: "></asp:Label>&nbsp;
            <asp:TextBox ID="Location" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="Select a Thesis to add defense to "></asp:Label>
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateSelectButton="true" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            </asp:GridView>
            
            <br />
           
            <br />


        </div>
        <div id="Extension2" runat="server" >
            <asp:Label ID="Label3" runat="server" Text="First Name"></asp:Label>&nbsp;<asp:TextBox ID="First" runat="server"></asp:TextBox>
            <br /><br />
            <asp:Label ID="Label6" runat="server" Text="Last Name"></asp:Label>&nbsp;<asp:TextBox ID="Last" runat="server"></asp:TextBox>
            <br /><br />
            <asp:Label ID="Label7" runat="server" Text="Password"></asp:Label>&nbsp;<asp:TextBox ID="Pass" runat="server"></asp:TextBox>
            <br /><br />
            <asp:Label ID="Label8" runat="server" Text="Field Of Work"></asp:Label>&nbsp;<asp:TextBox ID="Field" runat="server"></asp:TextBox>
            <br /><br />
            <asp:Label ID="Label9" runat="server" Text="Is National?"></asp:Label>&nbsp;<asp:CheckBox ID="National" runat="server" />
            <br /><br />
             <asp:Label ID="Label5" runat="server" Text="Select Defense to Add Examiner to"></asp:Label>
            <asp:GridView ID="DefensesGridView" runat="server" AutoGenerateSelectButton="true" OnSelectedIndexChanged="DefensesGridView_SelectedIndexChanged">
            </asp:GridView>
            <br /><br />
        </div>
        
    </form>
</body>
</html>
