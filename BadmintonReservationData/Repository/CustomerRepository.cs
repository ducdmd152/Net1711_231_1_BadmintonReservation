using BadmintonReservationData.Base;

namespace BadmintonReservationData.Repository
{
    public class CustomerRepository : GenericRepository<Customer>
    {
        public CustomerRepository(UnitOfWork unitOfWork) : base(unitOfWork)
        {            
        }        
    }
}
