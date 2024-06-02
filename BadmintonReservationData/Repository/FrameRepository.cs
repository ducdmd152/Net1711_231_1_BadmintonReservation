using BadmintonReservationData.Base;
using Microsoft.EntityFrameworkCore;

namespace BadmintonReservationData.Repository;

public class FrameRepository : GenericRepository<Frame>
{
    public FrameRepository(UnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public async Task<List<Frame>> GetAllWithCourtAsync()
    {
        return await _dbSet
            .Include(item => item.Court)
            .ToListAsync();
    }
}