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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SignIn_Click(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["GUC"].ToString();
            //create a new connection
            SqlConnection Connect= new SqlConnection(connStr);

            String email = Email.Text;
            Session["Email"] = Email.Text;
            String pass = Password.Text;
            Session["password"] = Password.Text;
             int id = getID(Connect,  email);
            Session["id"] = id;
            SqlCommand loginproc = new SqlCommand("userLogin", Connect);
            loginproc.CommandType = CommandType.StoredProcedure;

            if (id != -1)
            {
                loginproc.Parameters.Add(new SqlParameter("@ID", id));
                loginproc.Parameters.Add(new SqlParameter("@Password", pass));
                SqlParameter success = loginproc.Parameters.Add("@success", SqlDbType.Int);
                SqlParameter type = loginproc.Parameters.Add("@type",SqlDbType.Int);
                success.Direction = ParameterDirection.Output;
                type.Direction = ParameterDirection.Output;
                Connect.Open();
                loginproc.ExecuteNonQuery();
                Connect.Close();
                if (success.Value.ToString() == "1")
                {


                    Homepage_Redirect(Connect, Int16.Parse(type.Value.ToString()), id);
                }

                else Response.Write("Incorrect Username/Password");

            }
            else
                Response.Write("Incorrect Username/Password");
        }
       
        //beykhosh bel provided email 3ashan yetala3 el id
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
        
       

        protected void Register_Click(object sender, EventArgs e)
        {
            int i = Int16.Parse(Title.SelectedItem.Value);
            if (i==1)
            Response.Redirect("GucianRegister.aspx");
            else
            {
                if (i == 2)
                    Response.Redirect("NonGucianRegister.aspx");
                else
                {
                    if (i == 3)
                        Response.Redirect("SupervisorRegister.aspx");
                    else { 
                    if (i == 4)
                            Response.Redirect("ExaminerRegister.aspx");
                    }
                }
            }
        }

   

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       

        protected void Homepage_Redirect(SqlConnection Connect, int type, int id)
        {
            //check user type 0-- > Student,1-- > Admin,2-- > Supervisor ,3-- > Examiner
            if (type == 0) {
           
                SqlCommand cmd = new SqlCommand("select * from GucianStudent", Connect);
                Connect.Open();
                SqlDataReader rd = cmd.ExecuteReader();

                //If ID belongs to a Gucian

                while (rd.Read())
                {
                    if (Int16.Parse(rd[0].ToString()) == id)
                    {
                        type = -1;
                        Session["type"] = type;

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
                        Session["type"] = type;

                        Response.Redirect("NonGucianStudentPage.aspx");
                        return;
                    }
                }
                Connect.Close();
            }

            else
            {
                if (type == 1)
                    Response.Redirect("AdminPage.aspx"); 
                else
                {
                    if (type == 2)
                        Response.Redirect("SupervisorPage.aspx");
                    else
                    {
                        if (type == 3)
                            Response.Redirect("ExaminerPage.aspx");
                    }
                }
            }

        }
    }

}