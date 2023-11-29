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
    public partial class ExaminerRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected int getID(SqlConnection Connect, String email)
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

        protected void SignUp_Click(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["GUC"].ToString();
            //create a new connection
            SqlConnection Connect = new SqlConnection(connStr);
            string firstName = FirstName.Text;
            string lastName = LastName.Text;
            string pass = Password.Text;
            string email = Email.Text;
            string field = FieldOfWork.Text;
            Boolean flag = isNational.Checked;
            SqlCommand Registerproc = new SqlCommand("examinerRegister", Connect);
            Registerproc.CommandType = CommandType.StoredProcedure;

            Registerproc.Parameters.Add(new SqlParameter("@first_name", firstName));
            Registerproc.Parameters.Add(new SqlParameter("@last_name", lastName));
            Registerproc.Parameters.Add(new SqlParameter("@password", pass));
            Registerproc.Parameters.Add(new SqlParameter("@fieldOfWork", field));
            Registerproc.Parameters.Add(new SqlParameter("@email", email));
            if(flag)
            Registerproc.Parameters.Add(new SqlParameter("@isNational", '1'));
            else
            Registerproc.Parameters.Add(new SqlParameter("@isNational", '0'));

            Connect.Open();
            Registerproc.ExecuteNonQuery();
            Connect.Close();
            int s_id = getID(Connect, email);
            Session["id"] = s_id;
            Session["email"] = email;
            Response.Redirect("ExaminerPage.aspx");
        }
       
    }
}