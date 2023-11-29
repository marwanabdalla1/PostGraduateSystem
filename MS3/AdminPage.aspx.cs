using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MS3
{
    public partial class AdminPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            refresh_page();
        }
        protected void refresh_page()
        {
            OngoingThesesCount.Visible = false;
            TableForm.Visible = false;
            PaymentForm.Visible = false;
            ThesisPayForm.Visible = false;
            InstallPayForm.Visible = false;
            UpdateExtension.Visible = false;
            incorrect_SN.Visible = false;
            incorrect_SN2.Visible = false;
            incorrect_amount.Visible = false;
            incorrect_Install.Visible = false;
            incorrect_FP.Visible = false;
            success.Visible = false;
            successExtension.Visible = false;
            Incorrect_SN_Ex.Visible = false;
            Incorrect_SN_Ex2.Visible = false;
            PID_Ex.Visible = false;
            Incorrect_PID.Visible = false;
            Incorrect_ISD.Visible = false;
            dup_error.Visible = false;

        }

            protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        }

        protected void ViewSup_Click(object sender, EventArgs e)
        {
            refresh();
            TableForm.Visible = true;
            String connStr = WebConfigurationManager.ConnectionStrings["GUC"].ToString();
            SqlConnection Connect = new SqlConnection(connStr);
            SqlDataAdapter AdminListSupProc = new SqlDataAdapter("AdminListSup", Connect);
            Connect.Open();
            DataTable DT = new DataTable();
            AdminListSupProc.Fill(DT);
            Table.DataSource=DT;
            Table.DataBind();
            Connect.Close();

        }
      
        protected void ViewTheses_Click(object sender, EventArgs e)
        {
            refresh();
            TableForm.Visible = true;
            String connStr = WebConfigurationManager.ConnectionStrings["GUC"].ToString();
            SqlConnection Connect = new SqlConnection(connStr);
            SqlDataAdapter AdminViewAllTheses = new SqlDataAdapter("AdminViewAllTheses", Connect);
            SqlCommand AdminViewOnGoingTheses = new SqlCommand("AdminViewOnGoingTheses", Connect);
            SqlParameter Count = AdminViewOnGoingTheses.Parameters.Add("@thesesCount", SqlDbType.Int);
            Count.Direction = ParameterDirection.Output;
            AdminViewOnGoingTheses.CommandType = CommandType.StoredProcedure;
            OngoingThesesCount.Visible=true;
            Connect.Open();
            DataTable DT = new DataTable();
            AdminViewAllTheses.Fill(DT);
            Table.DataSource = DT;
            Table.DataBind();
            AdminViewOnGoingTheses.ExecuteNonQuery();
            Connect.Close();
            OngoingThesesCount.Text = "On going Theses Count: " + Count.Value.ToString();



        }

        protected void IssuePayment_Click(object sender, EventArgs e)
        {
            refresh();
            PaymentForm.Visible = true;
        }

        protected void IssueTypeDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        protected static void Clear(TextBox T)
        {
            T.Text = "";
        }
        protected void refresh()
        {
            refresh_page();
            Clear(SID);
            Clear(Serialno);
            Clear(Amount);
            Clear(NoInstall);
            Clear(FundPerc);
            Clear(PID);
            Clear(InstallStart);
          
        }

        protected void GO_Click(object sender, EventArgs e)
        {
            refresh();
            int i = Int16.Parse(payDD.SelectedItem.Value);
            if (i == 1)
            {
                ThesisPayForm.Visible = true;
            }
            else
            {
                if (i == 2)
                    InstallPayForm.Visible = true;
                else
                    PaymentForm.Visible = true;
            }
            payDD.SelectedIndex = 0;
        }
  
        protected void TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ThesisPay_Click(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["GUC"].ToString();
            SqlConnection Connect = new SqlConnection(connStr);

            int serialNo=-1;
            decimal amount=-1;
            int noInstall=-1;
            decimal fund = -1;
            if ((Serialno.Text == "" || !(Regex.IsMatch(Serialno.Text, @"^\d+$")) /*int.TryParse(Serialno.Text, out serialNo)*/))
            {
                ThesisPayForm.Visible = true;
                incorrect_SN2.Visible = true;
                return;
            }
            else
                int.TryParse(Serialno.Text, out serialNo);

            //does serial number exists?

            SqlCommand cmd = new SqlCommand("select * from Thesis", Connect);
            Connect.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            Boolean SN_exists = false;
            while (rd.Read())
            {
                if (Int16.Parse(rd[0].ToString()) == serialNo)
                {
                    SN_exists = true;
                    break;
                }
            }
            Connect.Close();

            if (!SN_exists)
            {
                ThesisPayForm.Visible = true;
                incorrect_SN.Visible = true;
                return;
            }

            if (Amount.Text == "" || !(decimal.TryParse(Amount.Text, out amount)))
            {
                ThesisPayForm.Visible = true;
                incorrect_amount.Visible = true;
                return;
            }

            if ((NoInstall.Text == "" || !(Regex.IsMatch(NoInstall.Text, @"^\d+$")) ))
            {
                ThesisPayForm.Visible = true;
                incorrect_Install.Visible = true;
                return;
            }
            else
                int.TryParse(NoInstall.Text, out noInstall);

            if (FundPerc.Text == "" || !(decimal.TryParse(FundPerc.Text, out fund)))
            {
                ThesisPayForm.Visible = true;
                incorrect_FP.Visible = true;
                return;
            }

           
           
            if (SN_exists== true)
            {
                SqlCommand payment_thesis = new SqlCommand("AdminIssueThesisPayment", Connect);
                payment_thesis.CommandType = CommandType.StoredProcedure;
                payment_thesis.Parameters.Add(new SqlParameter("@ThesisSerialNo", serialNo));
                payment_thesis.Parameters.Add(new SqlParameter("@amount", amount));
                payment_thesis.Parameters.Add(new SqlParameter("@noOfInstallments", noInstall));
                payment_thesis.Parameters.Add(new SqlParameter("@fundPercentage", fund));

                Connect.Open();
                payment_thesis.ExecuteNonQuery();
                Connect.Close();

                refresh();

                success.Visible = true;



            }



        }
     
        protected void InstallPay_Click(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["GUC"].ToString();
            SqlConnection Connect = new SqlConnection(connStr);

            SqlCommand InstallPaym_proc = new SqlCommand("AdminIssueInstallPayment", Connect);
            InstallPaym_proc.CommandType = CommandType.StoredProcedure;
            Boolean dup = false;

            int pid;
            DateTime SD;

         

            if (PID.Text=="" || !int.TryParse(PID.Text, out pid)){
                InstallPayForm.Visible = true;
                Incorrect_PID.Visible = true;
                return;
            }
            else
            {
                pid = int.Parse(PID.Text);
                SqlCommand cmd = new SqlCommand("select * from Payment", Connect);
                Connect.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                Boolean PID_exists = false;
                while (rd.Read())
                {
                    if (Int16.Parse(rd[0].ToString()) == pid)
                    {
                        PID_exists = true;
                        break;
                    }
                }
                Connect.Close();

                if (PID_exists)
                {
                    if (InstallStart.Text == "empty" || !(DateTime.TryParse(InstallStart.Text, out SD)))
                    {
                        InstallPayForm.Visible = true;
                        Incorrect_ISD.Visible = true;
                        return;
                    }
                    cmd.CommandText = "select * from Installment";
                    Connect.Open();
                    rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        if ((Int16.Parse(rd[1].ToString()) == pid) && (DateTime.Parse(rd[0].ToString()) == SD))
                        {
                            dup = true;
                        }

                    }
                    Connect.Close();
                    if (!dup)
                    {
                        InstallPaym_proc.Parameters.Add(new SqlParameter("@paymentID ", int.Parse(PID.Text)));
                        InstallPaym_proc.Parameters.Add(new SqlParameter("@InstallStartDate", DateTime.Parse(InstallStart.Text)));

                        Connect.Open();
                        InstallPaym_proc.ExecuteNonQuery();
                        Connect.Close();

                        refresh();

                        success.Visible = true;
                    }
                    else
                    {
                        InstallPayForm.Visible = true;
                        dup_error.Visible = true;
                    }
                }
                else
                {
                    InstallPayForm.Visible = true;
                    PID_Ex.Visible = true;
                }
            }
         

           
        }
        protected void ExtensionButton_Click(object sender, EventArgs e)
        {
            UpdateExtension.Visible = true;
        }

     
        protected void Extend_Click(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["GUC"].ToString();
            SqlConnection Connect = new SqlConnection(connStr);
            int serialNo = -1;
            if ((SID.Text == "" || !(Regex.IsMatch(SID.Text, @"^\d+$"))))
            {
                UpdateExtension.Visible = true;
                Incorrect_SN_Ex.Visible = true;
              
            }
            else
            {
                serialNo = int.Parse(SID.Text);
                SqlCommand cmd = new SqlCommand("select * from Thesis", Connect);
                Connect.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                Boolean SN_exists = false;
                while (rd.Read())
                {
                    if (Int16.Parse(rd[0].ToString()) == serialNo)
                    {
                        SN_exists = true;
                        break;
                    }
                }
                Connect.Close();

                if (SN_exists)
                {
                    SqlCommand updateExtensionProc = new SqlCommand("AdminUpdateExtension", Connect);
                    updateExtensionProc.CommandType = CommandType.StoredProcedure;
                    updateExtensionProc.Parameters.Add(new SqlParameter("@ThesisSerialNo", serialNo));

                    Connect.Open();
                    updateExtensionProc.ExecuteNonQuery();
                    Connect.Close();

                    refresh();
                    successExtension.Visible = true;

                }
                else
                {
                    UpdateExtension.Visible = true;
                    Incorrect_SN_Ex2.Visible = true;
                }
                }
            }
        }

    
}