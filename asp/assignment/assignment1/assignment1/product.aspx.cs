using System;
using System.Web.UI;

namespace assignment1
{
    public partial class product : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvCategory.DataSource = new string[] { "Mobile", "Laptop" };
                gvCategory.DataBind();
            }
        }

        protected void gvCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string category = gvCategory.SelectedRow.Cells[1].Text;

            ddlProducts.Items.Clear();

            if (category == "Mobile")
            {
                ddlProducts.Items.Add("iPhone");
                ddlProducts.Items.Add("Samsung");
                ddlProducts.Items.Add("OnePlus");
            }
            else if (category == "Laptop")
            {
                ddlProducts.Items.Add("Dell");
                ddlProducts.Items.Add("HP");
                ddlProducts.Items.Add("Lenovo");
            }
        }

        protected void ddlProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            string product = ddlProducts.SelectedValue;

            if (product == "iPhone")
            {
                lblPrice.Text = "Price: ₹80,000";
                imgProduct.ImageUrl = "images/iphone.jpg";
            }
            else if (product == "Samsung")
            {
                lblPrice.Text = "Price: ₹60,000";
                imgProduct.ImageUrl = "images/samsung.jpg";
            }
            else if (product == "OnePlus")
            {
                lblPrice.Text = "Price: ₹40,000";
                imgProduct.ImageUrl = "images/oneplus.jpg";
            }
            else if (product == "Dell")
            {
                lblPrice.Text = "Price: ₹70,000";
                imgProduct.ImageUrl = "images/dell.jpg";
            }
            else if (product == "HP")
            {
                lblPrice.Text = "Price: ₹65,000";
                imgProduct.ImageUrl = "images/hp.jpg";
            }
            else if (product == "Lenovo")
            {
                lblPrice.Text = "Price: ₹55,000";
                imgProduct.ImageUrl = "images/lenovo.jpg";
            }
        }
    }
}