using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void login(object sender, EventArgs e)
        {
            // 1. Take the input from the textboxes
            // Note: We used "username" and "password" as IDs in the HTML step above.
            string id = username.Text;
            string pass = password.Text;

            // 2. The "Hard Coded" Check
            // We strictly check if they typed "admin" and "admin" (or whatever you prefer)
            if (id == "admin" && pass == "admin")
            {
                // SUCCESS:
                // Redirect them to the Admin's functionality page.
                // You haven't created this yet, but let's assume it will be called "AdminHome.aspx"
                Response.Redirect("AdminHome.aspx");
            }
            else
            {
                // FAIL:
                // Show an error message.
                // Make sure you added a label with ID="lbl_msg" in the HTML as shown in Step A
                // If you don't have a label yet, you can just Response.Write for now.
                Response.Write("Invalid Admin Login");
            }
        }
    }
}