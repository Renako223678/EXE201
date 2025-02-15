using EXE201.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EXE201.Services
{
    public interface IBookingService
    {
        Task<IEnumerable<Booking>> GetAllBookingsAsync();
        Task<Booking?> GetBookingByIdAsync(long id);
        Task AddBookingAsync(Booking booking);
        Task UpdateBookingAsync(Booking booking);
        Task DeleteBookingAsync(long id);
    }
}
