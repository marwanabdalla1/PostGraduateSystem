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
    public partial class ExaminerEditInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void Edit_Click(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["GUC"].ToString();
            //create a new connection
            SqlConnection Connect = new SqlConnection(connStr);
            

            string name = Name.Text;
            string FieldOfWork = Field.Text;
            int id = int.Parse(Session["id"].ToString());
            Boolean flag= National.Checked;
            SqlCommand editExaminerProfilee = new SqlCommand("editExaminerProfile", Connect);
            editExaminerProfilee.CommandType = CommandType.StoredProcedure;
            editExaminerProfilee.Parameters.Add(new SqlParameter("@id", id));
            editExaminerProfilee.Parameters.Add(new SqlParameter("@name", name));
            editExaminerProfilee.Parameters.Add(new SqlParameter("@fieldOfWork", FieldOfWork));
            SqlDataAdapter ExaminerEdit = new SqlDataAdapter("editExaminerProfile", Connect);


            ExaminerEdit.SelectCommand = editExaminerProfilee;
            if (flag)
                editExaminerProfilee.Parameters.Add(new SqlParameter("@isNational", "1"));
            else
                editExaminerProfilee.Parameters.Add(new SqlParameter("@isNational", "0"));
            Connect.Open();
            editExaminerProfilee.ExecuteNonQuery();
            DataTable Dt = new DataTable();
            ExaminerEdit.Fill(Dt);
            GridView1.DataSource = Dt;
            GridView1.DataBind();
            Connect.Close();
        }

        
    }
}