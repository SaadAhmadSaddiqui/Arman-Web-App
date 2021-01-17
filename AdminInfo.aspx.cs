using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Arman_Web_App
{
    public partial class AdminInfo : System.Web.UI.Page
    {
         SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ArmanCon"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["Username"] == null)
                {
                    Session["CurrentPage"] = "AdminInfo.aspx";
                    Response.Redirect("AdminLogin.aspx");
                }
                gvAdmins.DataBind();

                alertSuccess.Visible = false;
                alertUpdate.Visible = false;
                alertDeleted.Visible = false;
                alertInfo.Visible = false;
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')");
            }
        }

        protected void btnPGo_Click(object sender, EventArgs e)
        {
            GetAdminByID();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            NewAdmin();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateAdmin();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteAdmin();
        }

        // User Defined Methods START

        void NewAdmin()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                if (txtAdminUsername.Text == "" || txtAdminPassword.Text == "" || txtAdminName.Text == "" || txtAdminEmail.Text == "")
                {
                    AlertInfo("Please fill in all the fields!");
                }
                else
                {
                    SqlCommand ncmd = new SqlCommand("SELECT * FROM Admins WHERE Username = '" + txtAdminUsername.Text + "'", con);
                    SqlDataReader dr = ncmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        AlertInfo("Username is already taken, try another username.");
                    }
                    else
                    {
                        dr.Close();
                        SqlCommand cmd = new SqlCommand("INSERT INTO Admins (Username, Password, AdminName, AdminEmail) VALUES (@Username, @Password, @AdminName, @AdminEmail)", con);
                        cmd.Parameters.AddWithValue("@Username", txtAdminUsername.Text);
                        cmd.Parameters.AddWithValue("@Password", txtAdminPassword.Text);
                        cmd.Parameters.AddWithValue("@AdminName", txtAdminName.Text);
                        cmd.Parameters.AddWithValue("@AdminEmail", txtAdminEmail.Text);

                        cmd.ExecuteNonQuery();
                        con.Close();
                        alertSuccess.Visible = true;
                        gvAdmins.DataBind();
                        Clear();
                    }

                }

            }
            catch (Exception ex)
            {
                AlertInfo(ex.Message);
            }
        }

        void UpdateAdmin()
        {
            if (CheckAdminExists())
            {
                if (txtAdminUsername.Text == "" || txtAdminPassword.Text == "" || txtAdminName.Text == "" || txtAdminEmail.Text == "")
                {
                    AlertInfo("Please fill in all the fields!");
                }
                else
                {
                    try
                    {
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();

                            SqlCommand cmd = new SqlCommand("UPDATE Admins SET Username = @aUsername, Password = @aPassword, AdminName = @AdminName, AdminEmail = @AdminEmail WHERE AdminID = '" + txtAdminID.Text + "'", con);
                            cmd.Parameters.AddWithValue("@aUsername", txtAdminUsername.Text);
                            cmd.Parameters.AddWithValue("@aPassword", txtAdminPassword.Text);
                            cmd.Parameters.AddWithValue("@AdminName", txtAdminName.Text);
                            cmd.Parameters.AddWithValue("@AdminEmail", txtAdminEmail.Text);

                            cmd.ExecuteNonQuery();

                            con.Close();
                            alertUpdate.Visible = true;
                            Clear();
                            gvAdmins.DataBind();
                        }
                    }
                    catch (Exception ex)
                    {
                        AlertInfo(ex.Message);
                    }
                }
            }
            else
            {
                AlertInfo("Invalid Admin ID!");
            }
        }

        void DeleteAdmin()
        {
            try
            {
                if (CheckAdminExists())
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("DELETE FROM Admins WHERE AdminID = '" + txtAdminID.Text + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    alertDeleted.Visible = true;
                    Clear();
                    gvAdmins.DataBind();
                }
                else
                {
                    AlertInfo("Invalid Admin ID!");
                }

            }
            catch (Exception ex)
            {
                AlertInfo(ex.Message);
            }
        }

        void GetAdminByID()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM Admins WHERE AdminID = '" + txtAdminID.Text.Trim() + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        txtAdminUsername.Text = dr.GetValue(1).ToString();
                        txtAdminPassword.Text = dr.GetValue(2).ToString();
                        txtAdminName.Text = dr.GetValue(3).ToString();
                        txtAdminEmail.Text = dr.GetValue(4).ToString();
                    }
                }
                else
                {
                    AlertInfo("Invalid Admin ID!");
                    Clear();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                AlertInfo(ex.Message);
            }
        }

        bool CheckAdminExists()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM Admins WHERE AdminID= '" + txtAdminID.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                AlertInfo(ex.Message);
                return false;
            }
        }

        void Clear()
        {
            txtAdminUsername.Text = txtAdminID.Text = txtAdminPassword.Text = txtAdminEmail.Text = txtAdminName.Text = "";
        }

        void AlertInfo(string msg)
        {
            alertInfo.Visible = true;
            alertInfoText.InnerText = msg;
        }
    }
}