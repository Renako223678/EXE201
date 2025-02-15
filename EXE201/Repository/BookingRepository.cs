using EXE201.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EXE201.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly EXE201Context _context;

        public BookingRepository(EXE201Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Booking>> GetAllAsync()
        {
            return await _context.Bookings
                .Include(b => b.Account)
                .Include(b => b.Discount)
                .Include(b => b.BookingDetails)
                .Include(b => b.Payments)
                .ToListAsync();
        }

        public async Task<Booking?> GetByIdAsync(long id)
        {
            return await _context.Bookings
                .Include(b => b.Account)
                .Include(b => b.Discount)
                .Include(b => b.BookingDetails)
                .Include(b => b.Payments)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task AddAsync(Booking booking)
        {
            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Booking booking)
        {
            _context.Bookings.Update(booking);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                await _context.SaveChangesAsync();
            }
        }
    }
}
