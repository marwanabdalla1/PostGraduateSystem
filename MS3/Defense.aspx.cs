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
    public partial class Defense : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Extension1.Visible = false;
            Extension2.Visible = false;
          
        }

        protected void Defense1_Click(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["GUC"].ToString();
            //create a new connection
            SqlConnection Connect = new SqlConnection(connStr);
            
            Extension2.Visible = false;
            Extension1.Visible = true;
            SqlCommand getThesis = new SqlCommand("select * from Thesis", Connect);
            Connect.Open();
            SqlDataReader read = getThesis.ExecuteReader();
            GridView1.DataSource = read;
            GridView1.DataBind();
            Connect.Close();

        }

        protected void Examiner1_Click(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["GUC"].ToString();
            //create a new connection
            SqlConnection Connect = new SqlConnection(connStr);
            Extension1.Visible = false;
            Extension2.Visible = true;
            
            SqlCommand getDefenses = new SqlCommand("select * from Defense", Connect);
            Connect.Open();
            SqlDataReader read = getDefenses.ExecuteReader();
            DefensesGridView.DataSource = read;
            DefensesGridView.DataBind();
            Connect.Close();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["GUC"].ToString();
            //create a new connection
            SqlConnection Connect = new SqlConnection(connStr);
            if (Location.Text == "")
            {
                Response.Write("Please Fill all boxes!");
                Defense1_Click(sender, e);
                return;
            }

            GridViewRow row = GridView1.SelectedRow;
            int serialNo =Int16.Parse(row.Cells[1].Text);
            SqlCommand check = new SqlCommand("CheckGUCianThesis", Connect);
            check.CommandType = System.Data.CommandType.StoredProcedure;
            check.Parameters.Add(new SqlParameter("@serialNo", serialNo));
            SqlParameter GUCian = check.Parameters.Add("@GUCian", SqlDbType.Int);
            GUCian.Direction = ParameterDirection.Output;
            Connect.Open();
            check.ExecuteNonQuery();
            Connect.Close();
            if (GUCian.Value.ToString() == "1")
            {
                SqlCommand gucianDef =new SqlCommand("AddDefenseGucian", Connect);
                gucianDef.CommandType = CommandType.StoredProcedure;
                gucianDef.Parameters.Add(new SqlParameter("@ThesisSerialNo", serialNo));
                try
                {
                    gucianDef.Parameters.Add(new SqlParameter("@DefenseDate", DateTime.Parse(Date.Text)));
                }
                catch(System.FormatException e1)
                {
                    Response.Write("Enter date in correct format");
                   Defense1_Click(sender, e);
                    return;
               }
                gucianDef.Parameters.Add(new SqlParameter("@DefenseLocation",Location.Text));
                Connect.Open();
                gucianDef.ExecuteNonQuery();
                Connect.Close();
                Response.Write("Defense added");
            }
            else
            {
                SqlCommand nongucianDef = new SqlCommand("AddDefenseNonGucian", Connect);
                nongucianDef.CommandType = CommandType.StoredProcedure;
                nongucianDef.Parameters.Add(new SqlParameter("@ThesisSerialNo", serialNo));
                nongucianDef.Parameters.Add(new SqlParameter("@DefenseDate", DateTime.Parse(Date.Text)));
                nongucianDef.Parameters.Add(new SqlParameter("@DefenseLocation", Location.Text));
                SqlParameter success = nongucianDef.Parameters.Add("@success", SqlDbType.Int);
                success.Direction = ParameterDirection.Output;
                Connect.Open();
                nongucianDef.ExecuteNonQuery();
                Connect.Close();
                if (success.Value.ToString() == "1")
                    Response.Write("Defense added");
                else
                    Response.Write("There is a grade less than 50%");
            }
        }

        protected void DefensesGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["GUC"].ToString();
            //create a new connection
            SqlConnection Connect = new SqlConnection(connStr);
            if(First.Text=="" || Last.Text=="" || Pass.Text=="" || Field.Text == "")
            {
                Response.Write("Please fill all boxes!");
                Examiner1_Click(sender, e);
                return;
            }
            GridViewRow row = DefensesGridView.SelectedRow;
            SqlCommand execute = new SqlCommand("AddExaminer", Connect);

            execute.CommandType = CommandType.StoredProcedure;
            execute.Parameters.Add(new SqlParameter("@ThesisSerialNo", Int16.Parse(row.Cells[1].Text)));
            execute.Parameters.Add(new SqlParameter("@DefenseDate", DateTime.Parse(row.Cells[2].Text)));
            execute.Parameters.Add(new SqlParameter("@ExaminerName", First.Text+" "+Last.Text));
            execute.Parameters.Add(new SqlParameter("@Password", Pass.Text));
            if (National.Checked)
                execute.Parameters.Add(new SqlParameter("@National", '1'));
            else
                execute.Parameters.Add(new SqlParameter("@National", '0'));
            execute.Parameters.Add(new SqlParameter("@fieldOfWork", Field.Text));
            Connect.Open();
            execute.ExecuteNonQuery();
            Connect.Close();
            Response.Write("Examiner added");
            Examiner1_Click(sender, e);
        }

        
    }
}