using Hotel.Manager;
using HotelBackWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBackWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelInfoController : ControllerBase
    {
        public readonly HotelInfoManager _hotelInfoManager;
        public HotelInfoController(HotelInfoManager hotelInfoManager)
        {
            this._hotelInfoManager = hotelInfoManager;
        }

        [HttpPost]
        public async Task<IActionResult> CreateFacility([FromBody] CreateHotelInfoInput input)
        {

            var result = await this._hotelInfoManager.CreateHotelInfo(
                input.Descreption,
                input.AboutUs,
                input.Email,
                input.Phone1,
                input.phone2,
                input.Address1,
                input.Address2,
                input.CopyRight
               );


            return Created($"AddHotelInfo/{result}", result);
        }

        [HttpGet]
        [Route("{id}")]

        public async Task<IActionResult> RetrieveHotelInfoById([FromRoute] int id)
        {
            try
            {
                var result = await this._hotelInfoManager.RetrieveHotelInfoById(id);

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
                var result = this._hotelInfoManager.GetFacility();
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


        [HttpPut(nameof(UpdateHotelInfo))]

        public async Task<IActionResult> UpdateHotelInfo([FromBody] CreateHotelInfoInput input)
        {
            await this._hotelInfoManager.UpdateHotelInfo(
                input.Id,
                 input.Descreption,
                input.AboutUs,
                input.Email,
                input.Phone1,
                input.phone2,
                input.Address1,
                input.Address2,
                input.CopyRight);
            return Ok();
        }
        [HttpDelete]
        [Route("{id}")]

        public async Task<IActionResult> DeleteHotelInfo([FromRoute] int id)
        {
            await this._hotelInfoManager.DeleteFacility(id);
            return Ok();
        }
    }
}
