using BadmintonReservationData.Base;

namespace BadmintonReservationData.Repository;

public class CustomerFrameRepository: GenericRepository<CustomFrame>
{
    public CustomerFrameRepository(UnitOfWork unitOfWork) : base(unitOfWork)
    {
    }
}
