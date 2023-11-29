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
    public partial class LinkPublication : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /* check if Session["PubID is not null"] */
          

            /* depending on the pubID we are going to set which dvider to visible */
        }



        protected void Link_Publication(object sender, EventArgs e)
        {

            try
            {
                String connStr = WebConfigurationManager.ConnectionStrings["GUC"].ToString();
                SqlConnection Connect = new SqlConnection(connStr);


                int id = (int)Session["id"];

                int pubID = Int16.Parse(PublicationID.Text);
                int TiD = Int16.Parse(thesisSerialNo.Text);




                SqlCommand LinkPublicationproc = new SqlCommand("linkPubThesis", Connect);
                LinkPublicationproc.CommandType = System.Data.CommandType.StoredProcedure;
                LinkPublicationproc.Parameters.Add(new SqlParameter("@PubID", pubID));
                LinkPublicationproc.Parameters.Add(new SqlParameter("@thesisSerialNo", TiD));
                LinkPublicationproc.Parameters.Add(new SqlParameter("@studentID", id));
                SqlParameter success = LinkPublicationproc.Parameters.Add(new SqlParameter("@output", SqlDbType.Int));
                success.Direction = ParameterDirection.Output;
                Connect.Open();
                LinkPublicationproc.ExecuteNonQuery();
                Connect.Close();

                if (success.Value.ToString() == "1")
                {
                    Response.Write("Thesis linked to publication");
                    /*UpdateExtension.Visible = false;
                    BackExtension.Visible = true;
                    */
                }
                else if (success.Value.ToString() == "-1")
                {
                    Response.Write("Thesis expired");
                }

                else if (success.Value.ToString() == "0")
                {
                    Response.Write("Thesis id is not yours");
                }
            }

            catch (System.Data.SqlClient.SqlException)
            {
                Response.Write("Inavlid data entered");

            }

           
        }



    }
    
}