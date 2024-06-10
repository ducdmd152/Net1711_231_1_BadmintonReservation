using BadmintonReservationData.Base;
using BadmintonReservationData.Enums;
using Microsoft.EntityFrameworkCore;

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
                .Where(item => item.Status != (int)FrameStatus.Delete)
                .Include(item => item.Court)
                .ToListAsync();
        }

        public async Task<Frame?> GetByIdWithCourtAsync(int id)
        {
            return await _dbSet
                .Where(item => item.Id == id && item.Status != (int)FrameStatus.Delete)
                .Include(item => item.Court)
                .SingleOrDefaultAsync();
        }

        public async Task<bool?> GetExistedFrameForUpdate(int oldTimeFrom, int oldTimeTo, int oldCourtId, int timeFrom,
            int timeTo, int courtId)
        {
            return await _dbSet
                .AnyAsync(item =>
                    item.CourtId == courtId
                    && item.Status != (int)FrameStatus.Delete
                    && !(item.TimeFrom == oldTimeFrom && item.TimeTo == oldTimeTo && item.CourtId == oldCourtId)
                    && (
                        (item.TimeFrom <= timeFrom && item.TimeTo >= timeTo) || // Case 1: encompasses the input range
                        (item.TimeFrom <= timeFrom && item.TimeTo > timeFrom &&
                         item.TimeTo < timeTo) || // Case 2: starts before and ends within the input range
                        (item.TimeTo >= timeTo && item.TimeFrom < timeTo &&
                         item.TimeFrom > timeFrom) || // Case 3: starts within and ends after the input range
                        (item.TimeFrom > timeFrom && item.TimeTo < timeTo) // Case 4: completely inside the input range
                    )
                );
        }

        public async Task<bool?> GetExistedFrameForCreate(int timeFrom, int timeTo, int courtId)
        {
            return await _dbSet
                .AnyAsync(item =>
                    item.CourtId == courtId
                    && item.Status != (int)FrameStatus.Delete
                    && (
                        (item.TimeFrom <= timeFrom && item.TimeTo >= timeTo) || // Case 1: encompasses the input range
                        (item.TimeFrom <= timeFrom && item.TimeTo > timeFrom &&
                         item.TimeTo < timeTo) || // Case 2: starts before and ends within the input range
                        (item.TimeTo >= timeTo && item.TimeFrom < timeTo &&
                         item.TimeFrom > timeFrom) || // Case 3: starts within and ends after the input range
                        (item.TimeFrom > timeFrom && item.TimeTo < timeTo) // Case 4: completely inside the input range
                    )
                );
        }
    }
}