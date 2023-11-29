using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace MS3
{
    public partial class FillProgress : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //Ghayar fel procedure name w attributes bas
        protected void Enter(object sender, EventArgs e)
        {
            int id = (int)Session["id"];
            String connStr = WebConfigurationManager.ConnectionStrings["GUC"].ToString();
            
            SqlConnection Connect = new SqlConnection(connStr);

            int TSO = Int16.Parse(thesisSerialNo.Text);
            int PRN = Int16.Parse(progressReportNo.Text);
            int state = Int16.Parse(State.Text);
            String desc = Description.Text;



            

            SqlCommand FillProgressReportproc = new SqlCommand("FillProgressReport", Connect);
            FillProgressReportproc.CommandType = System.Data.CommandType.StoredProcedure;
            FillProgressReportproc.Parameters.Add(new SqlParameter("@thesisSerialNo", TSO));
            FillProgressReportproc.Parameters.Add(new SqlParameter("@progressReportNo", PRN));
            FillProgressReportproc.Parameters.Add(new SqlParameter("@state", state));
            FillProgressReportproc.Parameters.Add(new SqlParameter("@description", desc));
            FillProgressReportproc.Parameters.Add(new SqlParameter("@studentID", id));
            SqlParameter success = FillProgressReportproc.Parameters.Add(new SqlParameter("@output", SqlDbType.Int));
            success.Direction = ParameterDirection.Output;




            Connect.Open();
            FillProgressReportproc.ExecuteNonQuery();
            Connect.Close();
            if (success.Value.ToString() == "1")
            {
                Response.Write("Sucessful Entry");
                UpdateExtension.Visible = false;
            }
            else
                Response.Write("Invalid Entries. Please Try Again");

        }
    }
}