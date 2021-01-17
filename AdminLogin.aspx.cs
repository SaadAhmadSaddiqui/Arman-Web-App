using System;
using System.IO;
using System.Net;
using Arman_Web_App.Models;
using Newtonsoft.Json;

namespace Arman_Web_App
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Visible = false;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string LoginURL = "http://arman.gotdns.ch:9000/api/Admins?Username=" + txtUsername.Text + "&Password=" + txtPassword.Text;
            WebRequest webRequest = WebRequest.Create(LoginURL);
            webRequest.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();



            string resultText = null;
            using (Stream stream = response.GetResponseStream())
            {
                StreamReader sr = new StreamReader(stream);
                resultText = sr.ReadToEnd();
                sr.Close();
            }
            if (resultText == "\"Wrong Username or Password!\"")
            {
                resultText = JsonConvert.DeserializeObject<string>(resultText);
                lblMessage.Visible = true;
                lblMessage.Text = resultText;
            }
            else
            {
                AdminModel admin = JsonConvert.DeserializeObject<AdminModel>(resultText);
                
                Response.Write("<script>alert('Login Successful');</script>");
                Session["Username"] = admin.Username;
                Session["Name"] = admin.AdminName;
                Session["Role"] = "Admin";
                if (Session["CurrentPage"] != null)
                {
                    Response.Redirect(Session["CurrentPage"].ToString());
                }
                else
                {
                    Response.Redirect("HomePage.aspx");
                }
            }
        }
    }
}