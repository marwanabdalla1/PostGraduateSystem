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
    public partial class StudentPublication : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Publication_View(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["GUC"].ToString();
            //create a new connection
            SqlConnection Connect = new SqlConnection(connStr);
            String s_id = Session["id"].ToString();
            int id = Int16.Parse(s_id);
            int studentID = 0;
            try
            {
                 studentID = Int16.Parse(StudentID.Text);
            }
            catch (System.FormatException e1)
            {
                Page_Load(sender, e);
            }
           Boolean flag = false;
            SqlCommand check = new SqlCommand("select * from GucianStudent", Connect);
            Connect.Open();
            SqlDataReader rd = check.ExecuteReader();
            while (rd.Read())
            {
                if (rd[0].ToString() == StudentID.Text)
                    flag = true;
            }
            Connect.Close();
            if (!flag)
            {
                Connect.Open();
               SqlCommand check1 = new SqlCommand("select * from NonGUCianStudent", Connect);
               SqlDataReader rd1 = check1.ExecuteReader();
                while (rd1.Read())
                {
                    if (rd1[0].ToString() == StudentID.Text)
                        flag = true;
                }
                Connect.Close();
            }
 
            if (flag)
            {
                SqlCommand viewPub = new SqlCommand("ViewAStudentPublications", Connect);
                viewPub.CommandType = System.Data.CommandType.StoredProcedure;
                viewPub.Parameters.Add("@StudentID", studentID);

                Connect.Open();
                SqlDataReader reader = viewPub.ExecuteReader();
                GridView1.DataSource = reader;
                GridView1.DataBind();
                Connect.Close();
           }
            else
            {
                Response.Write("Enter a correct student ID!");
          }
        }

    }
}