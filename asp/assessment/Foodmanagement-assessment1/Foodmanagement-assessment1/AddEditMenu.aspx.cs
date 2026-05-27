using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace Foodmanagement_assessment1
{
    public partial class AddEditMenu : System.Web.UI.Page
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
                if (Request.QueryString["MenuId"] != null)
                {
                    LoadData();
                }
            }
        }

        void LoadData()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM MenuItems WHERE MenuId=@id", con);
                cmd.Parameters.AddWithValue("@id", Request.QueryString["MenuId"]);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    txtItemName.Text = dr["ItemName"].ToString();
                    txtCategory.Text = dr["Category"].ToString();
                    txtPrice.Text = dr["Price"].ToString();
                    txtQty.Text = dr["AvailableQuantity"].ToString();
                }
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd;
                if (!string.IsNullOrEmpty(Request.QueryString["MenuId"]))
                {
                    cmd = new SqlCommand(
                        "UPDATE MenuItems SET ItemName=@name, Category=@cat, Price=@price, AvailableQuantity=@qty WHERE MenuId=@id",
                        con);

                    cmd.Parameters.AddWithValue("@id", Request.QueryString["MenuId"]);
                }
                else
                {
                    cmd = new SqlCommand(
                        "INSERT INTO MenuItems(ItemName,Category,Price,AvailableQuantity) VALUES(@name,@cat,@price,@qty)",
                        con);
                }

                cmd.Parameters.AddWithValue("@name", txtItemName.Text);
                cmd.Parameters.AddWithValue("@cat", txtCategory.Text);
                cmd.Parameters.AddWithValue("@price", txtPrice.Text);
                cmd.Parameters.AddWithValue("@qty", txtQty.Text);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            Response.Redirect("MenuList.aspx");
        }
    }
}