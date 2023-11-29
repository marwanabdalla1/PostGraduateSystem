using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MS3
{
    public partial class SupervisorPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Supervisor_Students(object sender, EventArgs e)
        {
            Response.Redirect("SupervisorStudents.aspx");
        }
        protected void Students_Publication(object sender, EventArgs e)
        {
            Response.Redirect("StudentPublication.aspx");
        }
        protected void Cancel_Redirect(object sender, EventArgs e)
        {
            Response.Redirect("Cancel.aspx");
        }
        protected void Evaluate_Redirect(object sender, EventArgs e)
        {
            Response.Redirect("Evaluate.aspx");
        }

        protected void Defense_redirect(object sender, EventArgs e)
        {
            Response.Redirect("Defense.aspx");
        }
    }
}