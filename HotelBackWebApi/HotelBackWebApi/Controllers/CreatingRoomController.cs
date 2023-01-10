using Hotel.Manager;
using HotelBackWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBackWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreatingRoomController : ControllerBase
    {
        public readonly RoomManager _roomManager;
        public CreatingRoomController(RoomManager roomManager)
        {
            this._roomManager = roomManager;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoom([FromBody] CreateRoomInput input)
        {

            var result = await this._roomManager.CreateRoom(
                input.RoomNb,
                input.RoomName,
                input.Descreption,
                input.Cost,
                input.BedType,
                input.Geusts,
                input.RoomSize,
                input.RoomImage) ;


            return Created($"AddRoom/{result}", result);
        }

        [HttpGet]
        [Route("{id}")]

        public async Task<IActionResult> RetrieveRoomById([FromRoute] int id)
        {
            try
            {
                var result = await this._roomManager.RetrieveRoomById(id);

                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (ArgumentNullException)
            {
                return BadRequest("Invalid Inputts");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


       
        [HttpGet]

        public IActionResult RetrieveRoom()
        {
            try
            {
                var result = this._roomManager.GetRoom();
                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (ArgumentNullException)
            {
                return BadRequest("Invalid Inputs");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

       
        [HttpPut(nameof(UpdateRoom))]

        public async Task<IActionResult> UpdateRoom([FromBody] CreateRoom input)
        {
            await this._roomManager.UpdateRoom(
                input.ID,
                input.RoomNb,
                input.RoomName,
                input.Descreption,
                input.Cost,
                input.BedType,
                input.Geusts,
                input.RoomSize,
                input.RoomImage);
            return Ok();
        }
        [HttpDelete]
        [Route("{id}")]

        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            await this._roomManager.DeleteRoom(id);
            return Ok();
        }
    }
}
