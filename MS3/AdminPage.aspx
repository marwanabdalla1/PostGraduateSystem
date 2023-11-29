<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="MS3.AdminPage" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Admin Homepage</div>
 
           
 
           
        <br />
 
           
 
           
        <asp:Button ID="ViewSup" runat="server" Text="View supervisors" OnClick="ViewSup_Click" />
     
        <asp:Button ID="ViewTheses" runat="server" Text="View Theses" OnClick="ViewTheses_Click" />
        <asp:Button ID="IssuePayment" runat="server" Text="Issue new payment" OnClick="IssuePayment_Click" />
     
        <asp:Button ID="ExtensionButton" runat="server" Text="Update thesis Extension" OnClick="ExtensionButton_Click" />
        <div id="success" runat="server" visible="True">
            <br />
        <asp:Label ID="Label13" runat="server" Text="Payment Successfully added" Visible="True" ForeColor="Green"></asp:Label>
           </div>
        <div id="successExtension" runat="server" visible="True">
            <br />
        <asp:Label ID="Label14" runat="server" Text="Extension Successfully made" Visible="True" ForeColor="Green"></asp:Label>
           </div>
       <div id="TableForm" runat="server">
        <br />
        <asp:Label ID="OngoingThesesCount" runat="server" Text="On going Theses Count: " Visible="False" ForeColor="Green"></asp:Label>
        <br />
        <br />
        <asp:GridView ID="Table" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        </asp:GridView>
           </div>

         <div id="PaymentForm" runat="server">
                <br />
                <asp:DropDownList ID="payDD" runat="server" OnSelectedIndexChanged="IssueTypeDropDown_SelectedIndexChanged" Height="23px" Width="190px">
                 <asp:ListItem Enabled="true" Text="Select Payment type" Value="-1"></asp:ListItem>
    <asp:ListItem Text="Thesis" Value="1"></asp:ListItem>
    <asp:ListItem Text="Installment" Value="2"></asp:ListItem>
            </asp:DropDownList>
                  &nbsp;<asp:Button ID="GO" runat="server" Text="GO" OnClick="GO_Click" />
                  </div>


           <div id="ThesisPayForm" runat="server">
               
                 <div id="incorrect_SN" runat="server">
                     <br />
               <asp:Label ID="Label8" runat="server" Text="Serial Number does not exist" ForeColor="Red"></asp:Label>
               <br />
                     </div>
                 <div id="incorrect_SN2" runat="server">
                     <br />
               <asp:Label ID="Label12" runat="server" Text="Serial Number is of the incorrect type/Text box is empty" ForeColor="Red"></asp:Label>
               <br />
                     </div>
                 <br />
               <asp:Label ID="Label1" runat="server" Text="Serial Number:"></asp:Label>
               &nbsp;<asp:TextBox ID="Serialno" runat="server" Width="174px"></asp:TextBox>
                <br />
               <div id="incorrect_amount" runat="server">
                    
                   <br />
                   <asp:Label ID="Label9" runat="server" Text="Amount is of the incorrect type/Text box is empty" ForeColor="Red"></asp:Label>
                   
                   <br />
                   
               </div>
              
                <br />
                <asp:Label ID="Label2" runat="server" Text="Amount:"></asp:Label>
               &nbsp;<asp:TextBox ID="Amount" runat="server" Width="214px"></asp:TextBox>
                <br />
              
               <div id="incorrect_Install" runat="server">
                   <br />
                   <asp:Label ID="Label10" runat="server" ForeColor="Red" Text="Number of installment is of the incorrect type/Text box is empty"></asp:Label>
                   <br />
               </div>
                <br />
                <asp:Label ID="Label3" runat="server" Text="Number of installments:"></asp:Label>
               &nbsp;<asp:TextBox ID="NoInstall" runat="server" Width="117px"></asp:TextBox>
                <br />
                 <div id="incorrect_FP" runat="server">
                    
                   <br />
                   <asp:Label ID="Label11" runat="server" Text="Fund percentage is of the incorrect type/Text box is empty" ForeColor="Red"></asp:Label>
                   
                     <br />
                   
               </div>
                <br />
                <asp:Label ID="Label4" runat="server" Text="fund Percentage:"></asp:Label>
               &nbsp;<asp:TextBox ID="FundPerc" runat="server"></asp:TextBox>
               <br />
               <br />
               <asp:Button ID="ThesisButton" runat="server" Text="Issue Thesis Payment" OnClick="ThesisPay_Click"/>
            </div>


         <div id="InstallPayForm" runat="server">

               <div id="Incorrect_PID" runat="server">
                   <br />
                   <asp:Label ID="Label17" runat="server" Text="Payment ID is of the incorrect type/Text box is empty" ForeColor="Red"></asp:Label>
                   <br />
                   </div>
              <div id="PID_Ex" runat="server">
                  <br />
                  <asp:Label ID="Label18" runat="server" Text="Payment ID does not exist" ForeColor="Red"></asp:Label>
                   <br />
                   </div>

             <br />

             <asp:Label ID="Label5" runat="server" Text="Payment ID:"></asp:Label>&nbsp;
             <asp:TextBox ID="PID" runat="server" Width="208px"></asp:TextBox>
             <br />
             <br /> <div id="Incorrect_ISD" runat="server">
                 <asp:Label ID="Label19" runat="server" Text="Installment Start date is of the incorrect type/Text box is empty (MM/DD/YYYY)" ForeColor="Red"></asp:Label>
                   <br />
                   <br />
                   </div>
             <asp:Label ID="Label6" runat="server" Text="Installment Start Date:"></asp:Label>
             &nbsp;<asp:TextBox ID="InstallStart" runat="server" Width="151px"></asp:TextBox>

             <br />
             <br />
            <div id="dup_error" runat="server">
                     <asp:Label ID="Label20" runat="server" Text="Entry already exists, change ID or start date" ForeColor="Red"></asp:Label>
              
                     <br />
                     <br />
              
             </div>
             <asp:Button ID="InstallButton" runat="server" Text="Issue Installment Payment" OnClick="InstallPay_Click" />
         </div>

           <div id="UpdateExtension" runat="server">
               <div id="Incorrect_SN_Ex" runat="server">
                                        <br />
               <asp:Label ID="Label15" runat="server" Text="Serial Number is of the incorrect type/Text box is empty" ForeColor="Red"></asp:Label>
                   </div>
               <div id="Incorrect_SN_Ex2" runat="server">
                     <br />
               <asp:Label ID="Label16" runat="server" Text="Serial Number does not exist" ForeColor="Red"></asp:Label>
                     </div>
               <br />
               <asp:Label ID="Label7" runat="server" Text="Thesis Serial Number:"></asp:Label>

          &nbsp;&nbsp;
               <asp:TextBox ID="SID" runat="server" style="width: 168px"></asp:TextBox>
               &nbsp;<asp:Button ID="Extend" runat="server" Text="Extend Thesis" OnClick="Extend_Click" />

          </div>
&nbsp;</form>
</body>
</html>
