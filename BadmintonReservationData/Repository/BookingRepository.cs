using BadmintonReservationData.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadmintonReservationData.Repository
{
    public class BookingRepository : GenericRepository<Booking>
    {
        public BookingRepository(UnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<List<Booking>> GetAllWithDetailsAsync()
        {
            return await this._dbSet.IgnoreAutoIncludes()
                              //.Include(item => item.Customer)                            
                              //.Include(item => item.BookingDetails)
                              //.Include(item => item.BookingType)
                              //.Include(item => item.Payment)
                              .ToListAsync();
        }

        public async Task<Booking> GetByIdWithDetailsAsync(int id)
        {
            return await this._dbSet.IgnoreAutoIncludes()
                              //.Include(item => item.Customer)
                              //.Include(item => item.BookingDetails)
                              //.Include(item => item.BookingType)
                              //.Include(item => item.Payment)
                              .SingleOrDefaultAsync(item => item.Id == id);
        }
    }
}
