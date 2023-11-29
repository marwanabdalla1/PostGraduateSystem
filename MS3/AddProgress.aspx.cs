using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
/* @thesisSerialNo int, @progressReportDate date, @studentID int,@progressReportNo int */
namespace MS3
{
    public partial class AddProgress : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          

            BackExtension.Visible = false;


        }
        protected void Enter(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["GUC"].ToString();
            //create a new connection
            SqlConnection Connect = new SqlConnection(connStr);
            String idS = Session["id"].ToString();

            int id = Int16.Parse(idS);
            int TSO = Int16.Parse(thesisSerialNo.Text);
            int PRN = 0;
        

            DateTime today = DateTime.Today;
            String date = today.ToString("MM/dd/yyyy");

            


            SqlCommand AddProgressReportproc = new SqlCommand("AddProgressReport", Connect);
            AddProgressReportproc.CommandType = System.Data.CommandType.StoredProcedure;
            AddProgressReportproc.Parameters.Add(new SqlParameter("@thesisSerialNo", TSO));
            AddProgressReportproc.Parameters.Add(new SqlParameter("@progressReportDate", date));
            AddProgressReportproc.Parameters.Add(new SqlParameter("@studentID", id));
            AddProgressReportproc.Parameters.Add(new SqlParameter("@progressReportNo",PRN ));
            SqlParameter success = AddProgressReportproc.Parameters.Add(new SqlParameter("@output", SqlDbType.Int));
            success.Direction = ParameterDirection.Output;




            Connect.Open();
            AddProgressReportproc.ExecuteNonQuery();
            Connect.Close();
            if (success.Value.ToString() == "1")
            {
                Response.Write("Sucessful Entry");
                UpdateExtension.Visible = false;
                BackExtension.Visible = true;

            }
            else if (success.Value.ToString() == "-1")

                Response.Write("Thesis end date has passed");
            else
                Response.Write("Wrong Thesis Serial Number");


        }
        protected void Back(object sender, EventArgs e)
        {
            String type = Session["type"].ToString();

            int tt = Int16.Parse(type);
            if (tt == -1) {
                Response.Redirect("GucianStudentPage.aspx");
            }
            else if(tt==0)
            {
                Response.Redirect("NonGucianStudentPage.aspx");

            }
        }

        protected void Another(object sender, EventArgs e)
        {
            UpdateExtension.Visible = true;
            BackExtension.Visible = false;
        }
    }


}
