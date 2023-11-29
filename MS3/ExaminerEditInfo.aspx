<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExaminerEditInfo.aspx.cs" Inherits="MS3.ExaminerEditInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <p>
            Edit Your Info</p>
        <p>
            <div>
            <asp:GridView ID="GridView1" runat="server" Height="16px" style="margin-right: 91px" Width="436px" AutoGenerateColumns="False" >
                <Columns>
                    <asp:BoundField DataField= "id" HeaderText="id" />
                    <asp:BoundField DataField= "name" HeaderText="name" />
                    <asp:BoundField DataField="fieldOfWork" HeaderText="fieldOfWork" />
                    <asp:BoundField DataField="isNational" HeaderText="isNational" />
                </Columns>
            </asp:GridView>
        </div>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            Name
        </p>
        <p>
            <asp:TextBox ID="Name" runat="server"></asp:TextBox>
        </p>
        <p>
            FieldOfWork</p>
        <p>
            <asp:TextBox ID="Field" runat="server"></asp:TextBox>
        </p>
        <p>
            IsNational&nbsp;&nbsp;
            <asp:CheckBox ID="National" runat="server" />
        </p>
        <p>
            &nbsp;</p>
        <p>
            <asp:Button ID="Edit" runat="server" Text="Edit" Width="100px" OnClick="Edit_Click" />
        </p>
            </div>
    </form>
</body>
</html>
