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
    public partial class ExaminerDefenseComment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Go_Click(object sender, EventArgs e)
        {

            String connStr = WebConfigurationManager.ConnectionStrings["GUC"].ToString();
            //create a new connection
            SqlConnection Connect = new SqlConnection(connStr);


            int SerialNumber2 = Int16.Parse(SerialNumber.Text);
            DateTime date = DateTime.Parse(DefenseDate.Text);
            String Comment1 = Comment.Text;
            SqlCommand AddComment = new SqlCommand("AddCommentsGrade", Connect);
            AddComment.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataAdapter ExaminerComment = new SqlDataAdapter("AddCommentsGrade", Connect);
            AddComment.Parameters.Add(new SqlParameter("@ThesisSerialNo", SerialNumber2));
            AddComment.Parameters.Add(new SqlParameter("@DefenseDate", date));
            AddComment.Parameters.Add(new SqlParameter("@Comments",Comment1));
            SqlParameter success = AddComment.Parameters.Add(new SqlParameter("@success", SqlDbType.Int));
            success.Direction = ParameterDirection.Output;
            ExaminerComment.SelectCommand = AddComment;
            SqlCommand cmd = new SqlCommand("select * from ExaminerEvaluateDefense", Connect);
            Connect.Open();
            AddComment.ExecuteNonQuery();
            DataTable Dt = new DataTable();
            ExaminerComment.Fill(Dt);
            GridView1.DataSource = Dt;
            GridView1.DataBind();
            Connect.Close();
            if (success.Value.ToString() == "1")
            {
                Response.Write("Sucessful Entry");

            }
            else
                Response.Write("Invalid Entries. Please Try Again");

        }
    }

    }
