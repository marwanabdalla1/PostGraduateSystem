<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExaminerSearch.aspx.cs" Inherits="MS3.ExaminerSearch" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <div>
            <asp:GridView ID="GridView1" runat="server" Height="16px" style="margin-right: 91px" Width="436px" AutoGenerateColumns="False" >
                <Columns>
                    <asp:BoundField DataField= "serialNumber" HeaderText="serialNumber" SortExpression="serialNumber" />
                    <asp:BoundField DataField= "field" HeaderText="field" SortExpression="field" />
                    <asp:BoundField DataField="type" HeaderText="type" SortExpression="type" />
                    <asp:BoundField DataField="title" HeaderText="title" SortExpression="title" />
                    <asp:BoundField DataField="startDate" HeaderText="startDate" SortExpression="startDate" />
                    <asp:BoundField DataField="endDate" HeaderText="endDate" SortExpression="endDate" />
                    <asp:BoundField DataField="defenseDate" HeaderText="defenseDate" SortExpression="defenseDate" />
                    <asp:BoundField DataField="years" HeaderText="years" SortExpression="years" />
                    <asp:BoundField DataField="grade" HeaderText="grade" SortExpression="grade" />
                    <asp:BoundField DataField="payment_id" HeaderText="payment_id" SortExpression="payment_id" />
                    <asp:BoundField DataField="noOfExtensions" HeaderText="noOfExtensions" />
                </Columns>
            </asp:GridView>
             </div>
            <br />
            <br />
            Please enter Keyword<br />
            <br />
            <asp:TextBox ID="Keyword" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Go" runat="server" Text="Go" Width="74px" OnClick="Go_Click" />
        
            <br />
            <br />
        
            </div>
    </form>
</body>
</html>
