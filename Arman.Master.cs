using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Arman_Web_App
{
    public partial class Arman : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			try
			{
                if (Session["Username"] != null)
                {
                    linkLogIn.Visible = false;
                    linkLogOut.Visible = true;
                    linkAdminManagement.Visible = true;
                    linkRoomManagement.Visible = true;
                    lblHelloUser.Text = "Hello, " + Session["Name"].ToString() + "!";
                    lblHelloUser.Visible = true;
                    lblAdminPanel.Visible = false;

                }
                else
                {
                    linkLogIn.Visible = true;
                    linkLogOut.Visible = false;
                    linkRoomManagement.Visible = false;
                    linkAdminManagement.Visible = false;
                    lblHelloUser.Visible = false; // Hello User label
                }
            }
			catch (Exception ex)
			{
                Response.Write("<script>alert('" + ex.Message + "')");
            }
        }

        protected void linkLogIn_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminLogin.aspx");
        }

        protected void linkLogOut_Click(object sender, EventArgs e)
        {
            Session["Role"] = null;
            Session["Username"] = null;
            Session["Name"] = null;
            Session["CurrentPage"] = null;
            Response.Redirect("HomePage.aspx");
        }

        protected void linkRoomManagement_Click(object sender, EventArgs e)
        {
            Response.Redirect("RoomInfo.aspx");
        }

        protected void linkAdminManagement_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminInfo.aspx");
        }
    }
}