using BadmintonReservationData;
using BadmintonReservationData.DAO;
using BadmintonReservationData.DTOs;
using System.Linq.Expressions;

namespace BadmintonReservationBusiness
{
    public class BookingBusiness
    {
       // private readonly BookingDAO this._unitOfWork.BookingRepository;
        private readonly UnitOfWork _unitOfWork;

        public BookingBusiness()
        {
            _unitOfWork ??= new UnitOfWork();
        }

        public async Task<IBusinessResult> GetAllAsync()
        {
            try
            {
                var result = await this._unitOfWork.BookingRepository.GetAllWithDetailsAsync();

                if (result == null)
                {
                    return new BusinessResult(404, "No booking data");
                }
                else
                {
                    return new BusinessResult(200, "Get booking list success", result);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(500, ex.Message);
            }
        }

        public async Task<IBusinessResult> GetByIdAsync(int id)
        {
            try
            {
                var result = await this._unitOfWork.BookingRepository.GetByIdWithDetailsAsync(id);

                if (result == null)
                {
                    return new BusinessResult(404, "No booking data");
                }
                else
                {
                    return new BusinessResult(200, "Get booking success", result);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(100, ex.Message);
            }
        }

        public async Task<IBusinessResult> CreateBookingAsync(CreateBookingRequestDTO bookingRequest)
        {
            try
            {
                var booking = new Booking
                {
                    CustomerId = bookingRequest.CustomerId,
                    BookingTypeId = bookingRequest.BookingTypeId,
                    BookingDateFrom = bookingRequest.BookingDateFrom,
                    BookingDateTo = bookingRequest.BookingDateTo,
                    PromotionAmount = bookingRequest.PromotionAmount,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    Status = 0, // Initial status
                    BookingDetails = bookingRequest.BookingDetails.Select(d => new BookingDetail
                    {
                        BookDate = d.BookDate,
                        FrameId = d.FrameId,
                        TimeFrom = d.TimeFrom,
                        TimeTo = d.TimeTo,
                        Price = d.Price,
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now
                    }).ToList(),
                    Payment = new Payment
                    {
                        Amount = bookingRequest.BookingDetails.Sum(d => d.Price),
                        Status = 0, // Initial status
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now
                    }
                };

                await this._unitOfWork.BookingRepository.CreateAsync(booking);
                return new BusinessResult(201, "Booking created successfully", booking);
            }
            catch (Exception ex)
            {
                return new BusinessResult(500, ex.Message);
            }
        }

        public async Task<IBusinessResult> UpdateBookingAsync(int id, UpdateBookingRequestDTO updateRequest)
        {
            try
            {
                var booking = await this._unitOfWork.BookingRepository.GetByIdWithDetailsAsync(id);
                if (booking == null)
                {
                    return new BusinessResult(404, "Booking not found");
                }

                if (updateRequest.Status.HasValue)
                {
                    booking.Status = updateRequest.Status.Value;
                    booking.UpdatedDate = DateTime.Now;
                    switch (updateRequest.Status.Value)
                    {
                        case 1:
                            // pending -> skip
                            break;
                        case 2:
                            // successful -> skip
                            break;
                        case 3:
                            // failed -> update all details' status to failed
                            foreach(var details in booking.BookingDetails)
                            {
                                details.Status = 3;
                            }
                            break;
                        case 4:
                            // cancelled -> update all details' status to cancelled
                            foreach (var details in booking.BookingDetails)
                            {
                                details.Status = 4;
                            }
                            break;
                        default:
                            // default code block
                            break;
                    }                    
                }

                if (updateRequest.PaymentStatus.HasValue)
                {
                    booking.Payment.Status = updateRequest.PaymentStatus.Value;
                    booking.Payment.UpdatedDate = DateTime.Now;
                }

                await this._unitOfWork.BookingRepository.UpdateAsync(booking);

                return new BusinessResult(200, "Booking updated successfully", booking);
            }
            catch (Exception ex)
            {
                return new BusinessResult(500, ex.Message);
            }
        }

        public async Task<IBusinessResult> DeleteBookingAsync(int id)
        {
            try
            {
                var booking = await _unitOfWork.BookingRepository.GetByIdWithDetailsAsync(id);
                if (booking == null)
                {
                    return new BusinessResult(404, "Booking not found");
                }

                //foreach (var details in booking.BookingDetails)
                //{
                //    await _unitOfWork.BookingDetailsRepository.RemoveAsync(details);
                //}
                //await _unitOfWork.PaymentRepository.RemoveAsync(booking);

                await _unitOfWork.BookingRepository.RemoveAsync(booking);
                return new BusinessResult(200, "Booking deleted successfully");
            }
            catch (Exception ex)
            {
                return new BusinessResult(500, ex.Message);
            }
        }
    }

}