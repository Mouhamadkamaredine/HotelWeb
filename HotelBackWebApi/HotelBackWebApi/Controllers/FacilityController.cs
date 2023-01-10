using Hotel.Manager;
using HotelBackWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBackWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacilityController : ControllerBase
    {
        public readonly FacilityManager _facilityManager;
        public FacilityController(FacilityManager facilityManager)
        {
            this._facilityManager = facilityManager;
        }

        [HttpPost]
        public async Task<IActionResult> CreateFacility([FromBody] CreateFacilityInput input)
        {

            var result = await this._facilityManager.CreateFacility(
                input.Name,
                input.Title,
                input.Image
               );


            return Created($"AddFacility/{result}", result);
        }

        [HttpGet]
        [Route("{id}")]

        public async Task<IActionResult> RetrieveRoomById([FromRoute] int id)
        {
            try
            {
                var result = await this._facilityManager.RetrieveFacilityById(id);

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
                var result = this._facilityManager.GetFacility();
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

        public async Task<IActionResult> UpdateRoom([FromBody] CreateFacilityInput input)
        {
            await this._facilityManager.UpdateFacility(
                input.Id,
                input.Name,
                input.Title,
                input.Image);
            return Ok();
        }
        [HttpDelete]
        [Route("{id}")]

        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            await this._facilityManager.DeleteFacility(id);
            return Ok();
        }
    }
}
