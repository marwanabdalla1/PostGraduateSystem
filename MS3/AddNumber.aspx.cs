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
    public partial class AddNumber : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Enter(object sender, EventArgs e)
        {
            try
            {
                String connStr = WebConfigurationManager.ConnectionStrings["GUC"].ToString();
                //create a new connection
                SqlConnection Connect = new SqlConnection(connStr);
                int id = Int32.Parse(Session["id"].ToString());

                String N = Number.Text;
                if (N != "")
                {
                    SqlCommand addnumberproc = new SqlCommand("addMobile", Connect);
                    addnumberproc.CommandType = System.Data.CommandType.StoredProcedure;
                    addnumberproc.Parameters.Add(new SqlParameter("@ID", id));
                    addnumberproc.Parameters.Add(new SqlParameter("@mobile_number", N));
                    Connect.Open();
                    addnumberproc.ExecuteNonQuery();
                    Connect.Close();
                    Homepage_Redirect(Connect, Int16.Parse(Session["id"].ToString()));
                }
                else
                    Response.Write("Text box is empty, Please enter a number!");


            }
            catch(System.Data.SqlClient.SqlException)
            {
                Response.Write("Please enter a valid number!");
            }


        }

        protected void Number_TextChanged(object sender, EventArgs e)
        {

        }


        protected void Homepage_Redirect(SqlConnection Connect, int id)
        {
            SqlCommand cmd = new SqlCommand("select * from GucianStudent", Connect);
            Connect.Open();
            SqlDataReader rd = cmd.ExecuteReader();

            //If ID belongs to a Gucian

            while (rd.Read())
            {
                if (Int16.Parse(rd[0].ToString()) == id)
                {
                    Response.Redirect("GucianStudentPage.aspx");
                    return;
                }
            }
            Connect.Close();


            //If ID belongs to a NonGucian

            cmd.CommandText = "select * from NonGucianStudent";
            Connect.Open();
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                if (Int16.Parse(rd[0].ToString()) == id)
                {
                    Response.Redirect("NonGucianStudentPage.aspx");
                    return;
                }
            }
            Connect.Close();

            //If ID belongs to a Supervisor

            cmd.CommandText = "select * from Supervisor";
            Connect.Open();
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                if (Int16.Parse(rd[0].ToString()) == id)
                {
                    Response.Redirect("SupervisorPage.aspx");
                    return;
                }
            }
            Connect.Close();

            //If ID belongs to an Examiner

            cmd.CommandText = "select * from Examiner";
            Connect.Open();
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                if (Int16.Parse(rd[0].ToString()) == id)
                {
                    Response.Redirect("ExaminerPage.aspx");
                    return;
                }
            }
            Connect.Close();

            //If ID belongs to an Admin

            cmd.CommandText = "select * from Admin";
            Connect.Open();
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                if (Int16.Parse(rd[0].ToString()) == id)
                {
                    Response.Redirect("AdminPage.aspx");
                    return;
                }
            }
            Connect.Close();
        }


    }
}
