using Arman_Web_App.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;

namespace Arman_Web_App
{
    public partial class RoomInfo : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ArmanCon"].ConnectionString);

        public List<Room> roomsList = new List<Room>();

        #region Generated methods
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["Username"] == null)
                {
                    Session["CurrentPage"] = "RoomInfo.aspx";
                    Response.Redirect("AdminLogin.aspx");
                }
                BindRooms();
                alertSuccess.Visible = false;
                alertUpdate.Visible = false;
                alertDeleted.Visible = false;
                alertInfo.Visible = false;
            }
            catch (Exception ex)
            {
                AlertInfo(ex.Message);
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            PostRoom();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateRoom();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteRoom();
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            if (CheckRoomExists())
            {
                RoomList roomList = GetRooms("http://arman.gotdns.ch:9000/api/Rooms/Get/" + txtRoomID.Text.Trim());
                txtRoomName.Text = roomList.rooms[0].roomName;
                txtRoomX.Text = roomList.rooms[0].roomX.ToString();
                txtRoomZ.Text = roomList.rooms[0].roomZ.ToString();
            }
            else
            {
                AlertInfo("Invalid Room ID!");
            }
        }
        #endregion

        #region User methods

        private void BindRooms()
        {
            RoomList roomList = GetRooms("http://arman.gotdns.ch:9000/api/Rooms/Get/");

            gvRooms.DataSource = roomList.rooms;
            gvRooms.DataBind();

        }

        private RoomList GetRooms(string URL)
        {
            string JSON = ReadFromURL(URL);
            JSON = "{\"rooms\":" + JSON + "}";
            return JsonConvert.DeserializeObject<RoomList>(JSON);
        }

        private string ReadFromURL(string URL)
        {
            WebRequest webRequest = WebRequest.Create(URL);
            webRequest.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();

            string resultText = null;
            using (Stream stream = response.GetResponseStream())
            {
                StreamReader sr = new StreamReader(stream);
                resultText = sr.ReadToEnd();
                sr.Close();
            }
            return resultText;
        }

        private void PostRoom()
        {
            if (txtRoomName.Text == "" || txtRoomX.Text == "" || txtRoomZ.Text == "")
            {
                AlertInfo("Please fill in all the fields!");
            }
            else
            {
                if (!RoomNameCheck())
                {
                    try
                    {
                        string URL = "http://arman.gotdns.ch:9000/api/Rooms/Post/";
                        WebRequest webRequest = WebRequest.Create(URL);
                        webRequest.Method = "POST";
                        webRequest.ContentType = "application/json";
                        string roomJson = JsonConvert.SerializeObject(MakeRoom());
                        using (StreamWriter sw = new StreamWriter(webRequest.GetRequestStream()))
                        {
                            sw.Write(roomJson);
                            sw.Flush();

                            using (HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse())
                            {
                                string resultText = null;
                                using (Stream stream = response.GetResponseStream())
                                {
                                    StreamReader sr = new StreamReader(stream);
                                    resultText = sr.ReadToEnd();
                                    sr.Close();
                                }
                            }
                            alertSuccess.Visible = true;
                        }
                        Clear();
                        BindRooms();
                    }
                    catch (WebException ex)
                    {
                        AlertInfo(ex.Message);
                    }
                    
                }
            }
        }
    
        private void UpdateRoom()
        {
            if (CheckRoomExists())
            {
                if (txtRoomName.Text == "" || txtRoomX.Text == "" || txtRoomZ.Text == "")
                {
                    AlertInfo("Please fill in all the fields!");
                }
                else
                {
                    try
                    {
                        string URL = "http://arman.gotdns.ch:9000/api/Rooms/Put/" + txtRoomID.Text.Trim();
                        WebRequest webRequest = WebRequest.Create(URL);
                        webRequest.Method = "PUT";
                        webRequest.ContentType = "application/json";
                        string roomJson = JsonConvert.SerializeObject(MakeRoom());
                        using (StreamWriter sw = new StreamWriter(webRequest.GetRequestStream()))
                        {
                            sw.Write(roomJson);
                            sw.Flush();
                            using (HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse())
                            {
                                string resultText = null;
                                using (Stream stream = response.GetResponseStream())
                                {
                                    StreamReader sr = new StreamReader(stream);
                                    resultText = sr.ReadToEnd();
                                    sr.Close();
                                }
                            }
                            alertUpdate.Visible = true;
                        }
                        Clear();
                        BindRooms();
                    }
                    catch (WebException ex)
                    {
                        AlertInfo(ex.Message);
                    }
                }
            }
            else
            {
                AlertInfo("Invalid Room ID!");
            }
        }

        private void DeleteRoom()
        {
            if (CheckRoomExists())
            {
                try
                {
                    WebRequest webRequest = WebRequest.Create("http://arman.gotdns.ch:9000/api/Rooms/Delete/" + txtRoomID.Text.Trim());
                    webRequest.Method = "DELETE";
                    HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
                    BindRooms();
                    alertDeleted.Visible = true;
                    Clear();
                }
                catch (Exception ex)
                {
                    AlertInfo(ex.Message);
                }
            }
            else
            {
                AlertInfo("Invalid Room ID!");
            }
        }

        private Room MakeRoom()
        {
            try
            {
                Room room = new Room
                {
                    roomName = txtRoomName.Text,
                    roomX = Convert.ToSingle(txtRoomX.Text),
                    roomY = 0,
                    roomZ = Convert.ToSingle(txtRoomZ.Text)
                };
                return room;
            }
            catch (Exception ex)
            {
                AlertInfo(ex.Message);
                return new Room
                {
                    roomName = "Default Room: Some error occured while creating a room. Check the format of the room.",
                    roomX = Convert.ToSingle(txtRoomX.Text),
                    roomY = 0,
                    roomZ = Convert.ToSingle(txtRoomZ.Text)
                };
            }
        }

        private void Clear()
        {
            txtRoomID.Text = txtRoomName.Text = txtRoomX.Text = txtRoomY.Text = txtRoomZ.Text = "";
        }

        void AlertInfo(string msg)
        {
            alertInfo.Visible = true;
            alertInfoText.InnerText = msg;
        }

        bool RoomNameCheck()
        {
            try
            {
                con.Open();
                SqlCommand ncmd = new SqlCommand("SELECT * FROM SzabistRooms WHERE RoomName = '" + txtRoomName.Text + "'", con);
                SqlDataReader dr = ncmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Close();
                    con.Close();
                    AlertInfo("Room is already added!");
                    return true;
                }
                else
                {
                    dr.Close();
                    con.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {
                AlertInfo(ex.Message);
                return true;
            }
        }

        bool CheckRoomExists()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM SzabistRooms WHERE RoomID= '" + txtRoomID.Text.Trim() + "'", con);
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
        #endregion
    }
}