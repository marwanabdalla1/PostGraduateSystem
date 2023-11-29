<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Evaluate.aspx.cs" Inherits="MS3.Evaluate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="Label1" runat="server" Text="Enter Evaluation between 0 and 3: "></asp:Label>&nbsp;
        <asp:TextBox ID="EvaluationNumber" runat="server" Width="34px"></asp:TextBox>&nbsp;
       
        <br /><br />
        <asp:Label ID="Label2" runat="server" Text="Select one progress report to evaluate"></asp:Label>
        <br />

        <asp:GridView ID="GridView1" runat="server" AutoGenerateSelectButton="true"
            onselectedindexchanged="GridView1_SelectedIndexChanged" >
        
        </asp:GridView>
        
    </form>
</body>
</html>
