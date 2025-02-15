using EXE201.Models;
using EXE201.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EXE201.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingsController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBookings()
        {
            return Ok(await _bookingService.GetAllBookingsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Booking>> GetBooking(long id)
        {
            var booking = await _bookingService.GetBookingByIdAsync(id);
            if (booking == null)
                return NotFound();
            return Ok(booking);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking(Booking booking)
        {
            await _bookingService.AddBookingAsync(booking);
            return CreatedAtAction(nameof(GetBooking), new { id = booking.Id }, booking);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBooking(long id, Booking booking)
        {
            if (id != booking.Id)
                return BadRequest();

            await _bookingService.UpdateBookingAsync(booking);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(long id)
        {
            await _bookingService.DeleteBookingAsync(id);
            return NoContent();
        }
    }
}
