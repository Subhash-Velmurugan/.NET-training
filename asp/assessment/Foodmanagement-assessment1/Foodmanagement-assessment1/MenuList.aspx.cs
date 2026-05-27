using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Foodmanagement_assessment1
{
    public partial class MenuList : System.Web.UI.Page
    {
        string conStr = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("login.aspx");
            }

            if (!IsPostBack)
            {
                LoadMenu();

                if (Request.QueryString["DeleteId"] != null)
                {
                    int id = Convert.ToInt32(Request.QueryString["DeleteId"]);
                    DeleteMenu(id);
                    LoadMenu();
                }
            }
        }
        void LoadMenu()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM MenuItems", con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvMenu.DataSource = dt;
                gvMenu.DataBind();
            }
        }
        void DeleteMenu(int id)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM MenuItems WHERE MenuId=@id", con);
                cmd.Parameters.AddWithValue("@id", id);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}