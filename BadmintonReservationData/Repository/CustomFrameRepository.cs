using BadmintonReservationData.Base;

namespace BadmintonReservationData.Repository;

public class CustomFrameRepository: GenericRepository<CustomFrame>
{
    public CustomFrameRepository(UnitOfWork unitOfWork) : base(unitOfWork)
    {
    }
}
