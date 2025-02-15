using EXE201.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EXE201.Repositories
{
    public interface IBookingRepository
    {
        Task<IEnumerable<Booking>> GetAllAsync();
        Task<Booking?> GetByIdAsync(long id);
        Task AddAsync(Booking booking);
        Task UpdateAsync(Booking booking);
        Task DeleteAsync(long id);
    }
}
