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
    public partial class NonGucianStudentPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        protected void AddNo_Click(object sender, EventArgs e)
        { 

            Response.Redirect("AddNumber.aspx");
        }
        protected void ViewInfo_Click(object sender, EventArgs e)
        {

            Response.Redirect("ViewInfo.aspx");

        }

        protected void ViewThesis_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewThesis.aspx");

        }

        
        protected void AddProgress_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddProgress.aspx");
        }


        protected void FillProgress_Click(object sender, EventArgs e)
        {
            Response.Redirect("FillProgress.aspx");

        }

        protected void ViewCourses_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewCourses.aspx");

        }
        protected void AddPublication_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddPublication.aspx");

        }
        protected void LinkPublication_Click(object sender, EventArgs e)
        {
            Response.Redirect("LinkPublication.aspx");

        }
    }
}