<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExaminerDefenseComment.aspx.cs" Inherits="MS3.ExaminerDefenseComment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <div>
            <asp:GridView ID="GridView1" runat="server" Height="16px" style="margin-right: 91px" Width="436px" AutoGenerateColumns="False" >
                <Columns>
                    <asp:BoundField DataField= "date" HeaderText="date" />
                    <asp:BoundField DataField="serialNo" HeaderText="serialNo" />
                    <asp:BoundField DataField="examinerId" HeaderText="examinerId" />
                    <asp:BoundField DataField="comment" HeaderText="comment" />
                </Columns>
            </asp:GridView>
        </div>
        <asp:Label ID="Label1" runat="server" Text="Please fill the info below"></asp:Label>
        <br />
        <br />
        ThesisSerialNumber<br />
        <br />
        <asp:TextBox ID="SerialNumber" runat="server" style="margin-bottom: 0px"></asp:TextBox>
        <br />
        <br />
        DefenseDate<br />
        <br />
        <asp:TextBox ID="DefenseDate" runat="server"></asp:TextBox>
        <br />
        <br />
        Comment<br />
        <br />
        <asp:TextBox ID="Comment" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Go" runat="server" Text="Go" Width="119px" OnClick="Go_Click" />
        <br />
            </div>
    </form>
</body>
</html>
