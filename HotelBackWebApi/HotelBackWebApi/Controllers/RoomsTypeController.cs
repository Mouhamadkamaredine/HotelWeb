using HotelBackWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelBackWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsTypeController : ControllerBase
    {
        private readonly RoomsTypeDbContext _context;

        public RoomsTypeController(RoomsTypeDbContext context)
        {
            _context = context;
        }

        // GET: api/PaymentDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomsType>>> GetCreateRooms()
        {
            return await _context.CreateRooms.ToListAsync();
        }

        // GET: api/PaymentDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomsType>> GetCreateRooms(int id)
        {
            var paymentDetail = await _context.CreateRooms.FindAsync(id);

            if (paymentDetail == null)
            {
                return NotFound();
            }

            return paymentDetail;
        }

        // PUT: api/PaymentDetail/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddRoom(int id, Room paymentDetail)
        {
            if (id != paymentDetail.RoomTypeId)
            {
                return BadRequest();
            }

            _context.Entry(paymentDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PaymentDetail
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RoomsType>> PostAddRoom(RoomsType paymentDetail)
        {
            _context.CreateRooms.Add(paymentDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCreateRooms", new { id = paymentDetail.RoomTypeId }, paymentDetail);
        }

        // DELETE: api/PaymentDetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddRoom(int id)
        {
            var paymentDetail = await _context.CreateRooms.FindAsync(id);
            if (paymentDetail == null)
            {
                return NotFound();
            }

            _context.CreateRooms.Remove(paymentDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaymentDetailExists(int id)
        {
            return _context.CreateRooms.Any(e => e.RoomTypeId == id);
        }
    }
}