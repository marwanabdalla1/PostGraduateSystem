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
    public partial class ExaminerSearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Go_Click(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["GUC"].ToString();
            //create a new connection
            SqlConnection Connect = new SqlConnection(connStr);

            SqlCommand SearchExaminer = new SqlCommand("SearchThesis", Connect);
            SearchExaminer.CommandType = CommandType.StoredProcedure;
            String Key = Keyword.Text;
            SearchExaminer.Parameters.Add(new SqlParameter("@keyword", Key));
            SqlParameter success = SearchExaminer.Parameters.Add(new SqlParameter("@success", SqlDbType.Int));
            success.Direction = ParameterDirection.Output;
            SqlDataAdapter ExaminerSearch = new SqlDataAdapter("SearchThesis", Connect);


            ExaminerSearch.SelectCommand = SearchExaminer;



            Connect.Open();

            SearchExaminer.ExecuteNonQuery();
            DataTable Dt = new DataTable();
            ExaminerSearch.Fill(Dt);
            GridView1.DataSource = Dt;
            GridView1.DataBind();
            Connect.Close();
            if (success.Value.ToString() == "1")
            {
                Response.Write("Sucessful Entry");
               
            }
            else
                Response.Write("Invalid Keyword. Please Try Again");


        }
    }
}