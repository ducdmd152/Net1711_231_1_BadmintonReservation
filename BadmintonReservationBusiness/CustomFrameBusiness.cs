using BadmintonReservationData;

namespace BadmintonReservationBusiness
{
    public class CustomFrameBusiness
    {
        private readonly UnitOfWork _unitOfWork;

        public CustomFrameBusiness(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
