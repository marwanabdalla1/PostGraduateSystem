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
    public partial class NonGucianRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        protected void SignUp_Click(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["GUC"].ToString();
            //create a new connection
            SqlConnection Connect = new SqlConnection(connStr);
            String Fname = FirstName.Text;
            String Lname = LastName.Text;
            String Pass = Password.Text;
            String Fac = Faculty.Text;
            String email = Email.Text;
            String address = Address.Text;

            SqlCommand Registerproc = new SqlCommand("studentRegister", Connect);
            Registerproc.CommandType = CommandType.StoredProcedure;

            Registerproc.Parameters.Add(new SqlParameter("@first_name", Fname));
            Registerproc.Parameters.Add(new SqlParameter("@last_name", Lname));
            Registerproc.Parameters.Add(new SqlParameter("@password", Pass));
            Registerproc.Parameters.Add(new SqlParameter("@faculty", Fac));
            Registerproc.Parameters.Add(new SqlParameter("@Gucian", '0'));
            Registerproc.Parameters.Add(new SqlParameter("@email", email));
            Registerproc.Parameters.Add(new SqlParameter("@address", address));
            SqlCommand cmd = new SqlCommand("select * from PostGradUser", Connect);
            Connect.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            Boolean Flag = false;
            while (rd.Read())
            {
                if (rd[1].ToString().Equals(email))
                {
                    Flag = true;
                    break;
                }
            }
            Connect.Close();
            if (Flag == true)
                Response.Write("E-mail is already taken");
            else
            {
                Connect.Open();
                Registerproc.ExecuteNonQuery();
                Connect.Close();
                int id = getID(Connect, email);
                Session["id"] = id;
                Response.Redirect("NonGucianStudentPage.aspx");
            }
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
    }
}