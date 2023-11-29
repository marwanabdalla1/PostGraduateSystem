using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MS3
{
    public partial class Cancel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Cancel_Thesis(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["GUC"].ToString();
            //create a new connection
            SqlConnection Connect = new SqlConnection(connStr);
            int serialNo = 0;
            try
            {
                 serialNo = Int16.Parse(Serial.Text);
            }
            catch(System.FormatException e1)
            {
                Page_Load(sender, e);
            }
            Boolean flag = false;
            SqlCommand c = new SqlCommand("CancelThesis", Connect);
            c.CommandType = System.Data.CommandType.StoredProcedure;
            c.Parameters.Add("@ThesisSerialNo", serialNo);

            SqlCommand thesis = new SqlCommand("select * from Thesis", Connect);
            Connect.Open();
            SqlDataReader check1 = thesis.ExecuteReader();
            int count = 0;
            while (check1.Read())
            {
                count++;
            }
            Connect.Close();
     
            Connect.Open();
            SqlDataReader check3 = thesis.ExecuteReader();
           
            while (check3.Read())
            {
                if (check3[0].ToString() == Serial.Text)
                    flag = true;
            }
            Connect.Close();
            if (flag)
            {
                Connect.Open();
                c.ExecuteNonQuery();
                Connect.Close();

                Connect.Open();
                SqlDataReader check2 = thesis.ExecuteReader();
                int count1 = 0;
                while (check2.Read())
                {
                    count1++;
                }
                Connect.Close();
                if (count == count1 + 1)
                {
                    Response.Write("Thesis Canceled!");
                }
                else
                    Response.Write("The last progress report is not evaluated zero!");
            }
            else
                Response.Write("Enter a correct thesis serial number");
        }
    }
}