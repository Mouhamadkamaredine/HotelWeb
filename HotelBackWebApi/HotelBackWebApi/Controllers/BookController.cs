 using Hotel.Manager;
using HotelBackWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBackWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public readonly BookinManager _bookingManager;
        public BookController(BookinManager bookingManager)
        {
            this._bookingManager = bookingManager;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking([FromBody] CreateBookInput input)
        {

            var result = await this._bookingManager.CreateBook(

                input.FirstName,
                input.LastName,
                input.Email,
                input.Phone,
                input.Country,
                 input.City,
                input.Address,
                input.ZipCode,
                 input.RoomCount,
                input.Adult,
                input.Child,
                 input.Checkin,
                input.Checkout,
                input.TimeArrive,
                
                input.RoomNb
           
                );


            return Created($"AddBook/{result}", result);
        }

        [HttpGet]
        [Route("{id}")]

        public async Task<IActionResult> RetrieveBookById([FromRoute] int id)
        {
            try
            {
                var result = await this._bookingManager.RetrieveBookingId(id);

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
        [Route("{checkin},{checkout}")]

        public async Task<IActionResult> CheckAvai([FromRoute] string checkin , string checkout)
        {
            try
            {
                var result = await this._bookingManager.CheckAva(checkin,checkout);

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

        public IActionResult RetrieveBooking()
        {
            try
            {
                var result = this._bookingManager.GetBooking();
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


        [HttpPut(nameof(UpdateBooking))]

        public async Task<IActionResult> UpdateBooking([FromBody] CreateBookInput input)
        {
            await this._bookingManager.UpdateBooking(
                input.Id,
                  input.FirstName,
                input.LastName,
                input.Email,
                input.Phone,
                input.Country,
                 input.City,
                input.Address,
                input.ZipCode,
                 input.RoomCount,
                input.Adult,
                input.Child,
                 input.Checkin,
                input.Checkout,
                input.TimeArrive,
                 
                input.RoomNb);
            return Ok();
        }
        [HttpDelete]
        [Route("{id}")]

        public async Task<IActionResult> DeleteBooking([FromRoute] int id)
        {
            await this._bookingManager.DeleteBooking(id);
            return Ok();
        }
    }
}
