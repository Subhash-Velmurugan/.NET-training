using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Foodmanagement_assessment1
{
    public partial class OrderStats : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("login.aspx");
            }

            lblVisitors.Text = Application["TotalVisitors"].ToString();
            lblActive.Text = Application["ActiveUsers"].ToString();
        }
    }
}