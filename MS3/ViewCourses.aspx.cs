﻿using System;
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
    public partial class ViewCourses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = (int)Session["id"];

            String connStr = WebConfigurationManager.ConnectionStrings["GUC"].ToString();

            SqlConnection Connect = new SqlConnection(connStr);

            SqlCommand ViewCoursesGrades = new SqlCommand("ViewCoursesGrades", Connect);
            ViewCoursesGrades.CommandType = CommandType.StoredProcedure;

            ViewCoursesGrades.Parameters.Add(new SqlParameter("@studentID", id));


            Connect.Open();
            SqlDataReader reader = ViewCoursesGrades.ExecuteReader();
            GridView1.DataSource = reader;
            GridView1.DataBind();
            Connect.Close();
        }
    }
}