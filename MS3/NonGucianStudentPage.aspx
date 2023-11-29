<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NonGucianStudentPage.aspx.cs" Inherits="MS3.NonGucianStudentPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="direction: ltr">
            Non-Gucian Homepage

             <br />
        

                <asp:Button ID="AddNumber" runat="server" Text="Add Number" Width="268px" OnClick="AddNo_Click" />
                     

    <br />
                                   <br />
      <asp:Button ID="ViewInfo" runat="server" Text="View My Personal Information" Width="268px" OnClick="ViewInfo_Click" />
                          <br />
                                   <br />

                 <asp:Button ID="ViewThesis" runat="server" Text="View My Thesis" Width="268px" OnClick="ViewThesis_Click" />

        <br />
                                   <br />

                 <asp:Button ID="Progress" runat="server" Text="Add Progress Report" Width="268px" OnClick="AddProgress_Click" />

                           <br />
                                   <br />

                 <asp:Button ID="ViewProgress" runat="server" Text="Fill Progress Report" Width="268px" OnClick="FillProgress_Click" />

                           <br />
                                   <br />

             <asp:Button ID="Publication" runat="server" Text="Add Publication" Width="268px" OnClick="AddPublication_Click" />

          <br />
                                   <br />

              <asp:Button ID="Button1" runat="server" Text="Link Publication" Width="268px" OnClick="LinkPublication_Click" />
               <br />
                                   <br />
                    <asp:Button ID="ViewCourses" runat="server" Text="View Courses " Width="268px" OnClick="ViewCourses_Click" />
        </div>
    </form>
    
                 
</body>
</html>
 <br />
                 