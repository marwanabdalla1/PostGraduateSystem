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
    public partial class ExaminerList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public int getID(SqlConnection Connect, String email)
        {
            //getpass ka2enaha table el postgrad
            SqlCommand getpass = new SqlCommand("select * from PostGradUser", Connect);
            Connect.Open();
            //
            SqlDataReader rd = getpass.ExecuteReader();
            int id = -1;
            while (rd.Read())
            {
                if (rd[1].ToString() == email)
                {
                    id = Int16.Parse(rd[0].ToString());
                    break;
                }
            }
            Connect.Close();
            return id;
        }

            protected void view_Click(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["GUC"].ToString();
            //create a new connection
            SqlConnection Connect = new SqlConnection(connStr);
            SqlCommand ViewExaminer = new SqlCommand("viewexaminerInfoDefense", Connect);
            ViewExaminer.CommandType = CommandType.StoredProcedure;
            int idd = Int16.Parse(Session["id"].ToString());
            ViewExaminer.Parameters.Add(new SqlParameter("@id", idd));
            SqlDataAdapter ExaminerInfoo = new SqlDataAdapter("viewexaminerInfoDefense", Connect);


            ExaminerInfoo.SelectCommand = ViewExaminer;
          



            Connect.Open();

            ViewExaminer.ExecuteNonQuery();
            DataTable Dt = new DataTable();
            ExaminerInfoo.Fill(Dt);
            GridView1.DataSource = Dt;
            GridView1.DataBind();
            Connect.Close();


            


        }

    }
}