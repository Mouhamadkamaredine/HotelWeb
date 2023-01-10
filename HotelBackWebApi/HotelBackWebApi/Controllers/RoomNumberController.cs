using Hotel.Manager;
using HotelBackWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBackWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomNumberController : ControllerBase
    {
        public readonly RoomManager _roomManager;
        public RoomNumberController(RoomManager roomManager)
        {
            this._roomManager = roomManager;
        }

       

      
       
       

    }
}
