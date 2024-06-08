using BadmintonReservationData.Base;
using BadmintonReservationData.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadmintonReservationData.Repository
{
    public class FrameRepository : GenericRepository<Frame>
    {
        public FrameRepository(UnitOfWork unitOfWork) : base(unitOfWork)
        {            
        }

        public async Task<List<Frame>> GetAllFrameAvailableOfCourtForDate(int id)
        {
            return await this._dbSet
                              .IgnoreAutoIncludes()
                              .Where(item => item.CourtId == id)
                              .Where(item => item.Status == (int)FrameStatus.Active)
                              .ToListAsync();
        }
    }
}
