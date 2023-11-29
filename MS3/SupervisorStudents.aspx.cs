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
    public partial class SupervisorStudents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["GUC"].ToString();
            //create a new connection
            SqlConnection Connect = new SqlConnection(connStr);
            String s_id = Session["id"].ToString();
            int id = Int16.Parse(s_id);
            SqlCommand student = new SqlCommand("ViewSupStudentsYears", Connect);
            student.CommandType = System.Data.CommandType.StoredProcedure;
            student.Parameters.Add("@supervisorID", id);

            Connect.Open();
            SqlDataReader reader = student.ExecuteReader();
            GridView1.DataSource = reader;
            GridView1.DataBind();
            Connect.Close();
        }
  

    }
}