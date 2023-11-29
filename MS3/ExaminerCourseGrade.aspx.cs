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
    public partial class ExaminerCourseGrade : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Enter_Click(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["GUC"].ToString();
            //create a new connection
            SqlConnection Connect = new SqlConnection(connStr);
           
                int SerialNumber1 = Int16.Parse(SerialNumber.Text);
                DateTime date = DateTime.Parse(DefenseDate.Text);
                Decimal Gradee = Decimal.Parse(Grade.Text);
                SqlCommand AddGrade = new SqlCommand("AddDefenseGrade", Connect);
                AddGrade.CommandType = System.Data.CommandType.StoredProcedure;
            AddGrade.Parameters.Add(new SqlParameter("@ThesisSerialNo", SerialNumber1));
            AddGrade.Parameters.Add(new SqlParameter("@DefenseDate", date));
            AddGrade.Parameters.Add(new SqlParameter("@Grade", Gradee));

            SqlParameter success = AddGrade.Parameters.Add(new SqlParameter("@success", SqlDbType.Int));
            success.Direction = ParameterDirection.Output;
            SqlDataAdapter ExaminerGrade = new SqlDataAdapter("AddDefenseGrade", Connect);
            

            
               

            





            ExaminerGrade.SelectCommand = AddGrade;
            Connect.Open();
            AddGrade.ExecuteNonQuery();
            DataTable Dt = new DataTable();
            ExaminerGrade.Fill(Dt);
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