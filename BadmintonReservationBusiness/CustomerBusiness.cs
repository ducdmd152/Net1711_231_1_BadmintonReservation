using BadmintonReservationData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadmintonReservationBusiness
{
    public class CustomerBusiness
    {
        private readonly UnitOfWork _unitOfWork;

        public CustomerBusiness(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IBusinessResult> GetCustomerList()
        {
            try
            {
                var customers = await this._unitOfWork.CustomerRepository.GetAllAsync();
                if (customers == null)
                {
                    return new BusinessResult(400, "No customer data");
                }
                else
                {
                    return new BusinessResult(200, "Get available customer list sucess", customers);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(500, ex.Message);
            }
        }        
    }
}
