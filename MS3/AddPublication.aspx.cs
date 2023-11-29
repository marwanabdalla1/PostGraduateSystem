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
    public partial class AddPublication : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BackExtension.Visible = false;
        }
        protected void Group1_CheckedChanged(Object sender, EventArgs e)
        {
            if (rdoButton1.Checked)
            {
            }

            if (rdoButton2.Checked)
            {
            }
        }

        protected void Enter(object sender, EventArgs e)
        {
            try
            {
                String connStr = WebConfigurationManager.ConnectionStrings["GUC"].ToString();
                //create a new connection
                SqlConnection Connect = new SqlConnection(connStr);

                bool value = true;


                if (rdoButton1.Checked)
                {
                    value = true;
                }

                if (rdoButton2.Checked)
                {
                    value = false;
                }

                String Title = titleT.Text;
                DateTime today = DateTime.Today;
                String Host = HostH.Text;
                String Place = place.Text;

                String timeStamp = PubDate.Text;
                DateTime x = DateTime.Parse(timeStamp);

                int pid=0;


                SqlCommand AddPublicationproc = new SqlCommand("AddPublication", Connect);
                AddPublicationproc.CommandType = System.Data.CommandType.StoredProcedure;
                AddPublicationproc.Parameters.Add(new SqlParameter("@title", Title));
                AddPublicationproc.Parameters.Add(new SqlParameter("@pubDate", x));
                AddPublicationproc.Parameters.Add(new SqlParameter("@host", Host));
                AddPublicationproc.Parameters.Add(new SqlParameter("@place", Place));
                AddPublicationproc.Parameters.Add(new SqlParameter("@accepted", value));
                SqlParameter pubID = AddPublicationproc.Parameters.Add(new SqlParameter("@pubID",pid));
                SqlParameter success = AddPublicationproc.Parameters.Add(new SqlParameter("@output", SqlDbType.Int));
                success.Direction = ParameterDirection.Output;
                pubID.Direction = ParameterDirection.Output;



                /* hankhaly el procedure tetala3 int el just added id 3ashan ne link it to the thesis*/

               



                Connect.Open();
                AddPublicationproc.ExecuteNonQuery();
                Connect.Close();
                Session["PubID"] = pubID.Value.ToString();
                if (success.Value.ToString() == "1")
                {
                    Response.Write("Sucessful Entry, Publication id is: "+ pubID.Value.ToString());
                    UpdateExtension.Visible = false;
                    BackExtension.Visible = true;

                }
                else
                    Response.Write("Invalid Entries. Please Try Again");
            }
            catch (System.FormatException)
            {
                Response.Write("Date entered was not in proper format");
            }

            /* @title varchar(50), @pubDate datetime, @host varchar(50), @place varchar(50), @accepted bit */


        }

        protected void Link_Thesis(object sender, EventArgs e)
        {
            Response.Redirect("LinkPublication.aspx");

        }

        protected void Back(object sender, EventArgs e)
        {
            String type = Session["type"].ToString();

            int tt = Int16.Parse(type);
            if (tt == -1)
            {
                Response.Redirect("GucianStudentPage.aspx");
            }
            else if (tt == 0)
            {
                Response.Redirect("NonGucianStudentPage.aspx");

            }
        }
    }
}