using BadmintonReservationData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadmintonReservationBusiness
{
    public class FrameBusiness
    {
        private readonly UnitOfWork _unitOfWork;

        public FrameBusiness(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IBusinessResult> GetAllFrameAvailableOfCourtForDate(int id, DateTime bookingDate)
        {
            try
            {
                var frames = await this._unitOfWork.FrameRepository.GetAllFrameAvailableOfCourtForDate(id);
                var bookedFrameIdList = await this._unitOfWork.BookingDetailRepository.GetBookedFrameIdListAt(bookingDate);

                var availableFrameForBookingDate = frames.Where(frame => !bookedFrameIdList.Any(item => item == frame.Id)).ToList();
                
                if (availableFrameForBookingDate == null)
                {
                    return new BusinessResult(400, "No frame data");
                }
                else
                {
                    return new BusinessResult(200, "Get available frame list sucess", availableFrameForBookingDate);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(500, ex.Message);
            }
        }
    }
}
