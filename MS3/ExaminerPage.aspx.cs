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
    public partial class ExaminerPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Editinfo_Click(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["GUC"].ToString();
            //create a new connection
            SqlConnection Connect = new SqlConnection(connStr);
            Response.Redirect("ExaminerEditInfo.aspx");
        }

        

        protected void Grade_Click(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["GUC"].ToString();
            //create a new connection
            SqlConnection Connect = new SqlConnection(connStr);
            Response.Redirect("ExaminerCourseGrade.aspx");
            
        }

        protected void Comment_Click(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["GUC"].ToString();
            //create a new connection
            SqlConnection Connect = new SqlConnection(connStr);
            Response.Redirect("ExaminerDefenseComment.aspx");
        }

        protected void List_Click(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["GUC"].ToString();
            //create a new connection
            SqlConnection Connect = new SqlConnection(connStr);


            Response.Redirect("ExaminerList.aspx");
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["GUC"].ToString();
            //create a new connection
            SqlConnection Connect = new SqlConnection(connStr);


            Response.Redirect("ExaminerSearch.aspx");
        }
    }
}