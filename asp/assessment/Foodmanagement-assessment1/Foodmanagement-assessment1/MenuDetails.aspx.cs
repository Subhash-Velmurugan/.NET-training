using System;
using System.Data.SqlClient;
using System.Configuration;

namespace Foodmanagement_assessment1
{
    public partial class MenuDetails : System.Web.UI.Page
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
                LoadDetails();
            }
        }

        void LoadDetails()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM MenuItems WHERE MenuId=@id", con);
                cmd.Parameters.AddWithValue("@id", Request.QueryString["MenuId"]);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    lblName.Text = dr["ItemName"].ToString();
                    lblCategory.Text = dr["Category"].ToString();
                    lblPrice.Text = dr["Price"].ToString();
                    lblQty.Text = dr["AvailableQuantity"].ToString();
                }
            }
        }
    }
}