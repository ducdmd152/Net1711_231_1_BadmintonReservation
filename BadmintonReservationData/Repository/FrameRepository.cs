using BadmintonReservationData.Base;
using BadmintonReservationData.Enums;
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

        public async Task<List<Frame>> GetAllFrameAvailableForDate()
        {
            return await this._dbSet
                              .IgnoreAutoIncludes()
                              .Where(item => item.Status == (int)FrameStatus.Active)
                              .Include(item => item.Court)
                              .ToListAsync();
        }

        public async Task<List<Frame>> GetAllFrameAvailableOfCourtForDate(int id)
        {
            return await this._dbSet
                              .IgnoreAutoIncludes()
                              .Where(item => item.CourtId == id)
                              .Where(item => item.Status == (int)FrameStatus.Active)
                              .Include(item => item.Court)
                              .ToListAsync();
        }
        
        public async Task<List<Frame>> GetAllWithCourtAsync()
    	{
	        return await _dbSet
		        .Where(item => item.Status != (int) FrameStatus.Delete)
	            .Include(item => item.Court)
	            .ToListAsync();
    	}

	    public async Task<Frame?> GetByIdWithCourtAsync(int id)
	    {
		    return await _dbSet
			    .Where(item => item.Id == id && item.Status != (int) FrameStatus.Delete)
			    .Include(item => item.Court)
			    .SingleOrDefaultAsync();
	    }

	    public async Task<Frame?> GetExistedFrame(int timeFrom, int timeTo, int courtId)
	    {
		    return await _dbSet.Where(
			    item => item.TimeFrom == timeFrom
			            && item.TimeTo == timeTo
			            && item.CourtId == courtId
			            && item.Status != (int) FrameStatus.Delete
			            )
			            .Include(item => item.Court)
			    .SingleOrDefaultAsync();
	    }
    }
}
