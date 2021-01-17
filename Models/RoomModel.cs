using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Arman_Web_App.Models
{

    public class RoomList
    {
        public List<Room> rooms { get; set; }
    }

    public class Room
    {
        public int roomID { get; set; }
        public string roomName { get; set; }
        public float roomX { get; set; }
        public float roomY { get; set; }
        public float roomZ { get; set; }
    }

}