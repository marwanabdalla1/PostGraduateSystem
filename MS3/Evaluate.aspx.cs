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
    public partial class Evaluate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["GUC"].ToString();
            //create a new connection
            SqlConnection Connect = new SqlConnection(connStr);
            SqlCommand getinfo = new SqlCommand("ViewProgressReports", Connect);
            getinfo.CommandType = System.Data.CommandType.StoredProcedure;
            getinfo.Parameters.Add(new SqlParameter("@supervisorId", Int16.Parse(Session["id"].ToString())));
            Connect.Open();
            SqlDataReader grid = getinfo.ExecuteReader();
            GridView1.DataSource = grid;
            GridView1.DataBind();
            Connect.Close();
            
        }
      

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            String connStr = WebConfigurationManager.ConnectionStrings["GUC"].ToString();
            //create a new connection
            SqlConnection Connect = new SqlConnection(connStr);
            GridViewRow row = GridView1.SelectedRow;
            int s = 4;
            try
            {
                s = Int16.Parse(EvaluationNumber.Text);
            }
            catch(System.FormatException e1){
                
                Page_Load(sender, e);
            }
            int superId = Int16.Parse(Session["id"].ToString());
            int thesisSerialNo = Int16.Parse(row.Cells[7].Text);
            int reportNo = Int16.Parse(row.Cells[2].Text);




            if ((s == 0 || s == 1 || s == 2 || s == 3))
            {

                SqlCommand proc = new SqlCommand("EvaluateProgressReport", Connect);
                proc.CommandType = System.Data.CommandType.StoredProcedure;
                proc.Parameters.Add(new SqlParameter("@supervisorID", superId));
                proc.Parameters.Add(new SqlParameter("@thesisSerialNo", thesisSerialNo));
                proc.Parameters.Add(new SqlParameter("@progressReportNo", reportNo));
                proc.Parameters.Add(new SqlParameter("@evaluation", s));
                Connect.Open();
                proc.ExecuteNonQuery();
                Response.Write("Report Evaluated!");
                Connect.Close();
            }
            else
                Response.Write("Enter Evaluation between 0 and 3 !");

            Console.WriteLine(thesisSerialNo);
            Console.WriteLine(reportNo);
            Console.WriteLine(superId);
            Console.WriteLine(s);
            Page_Load(sender, e);
        }
    }
}