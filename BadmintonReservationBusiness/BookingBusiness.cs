using BadmintonReservationData;
using BadmintonReservationData.DAO;
using BadmintonReservationData.DTOs;

namespace BadmintonReservationBusiness
{
    public class BookingBusiness
    {
        private readonly BookingDAO dao;

        public BookingBusiness()
        {
            this.dao = new BookingDAO();
        }

        public async Task<IBusinessResult> GetAll()
        {
            try
            {
                var result = await this.dao.GetAllWithDetailsAsync();

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

        public async Task<IBusinessResult> GetById(int id)
        {
            try
            {
                var result = await dao.GetByIdWithDetailsAsync(id);

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

        public async Task<IBusinessResult> CreateBooking(CreateBookingRequestDTO bookingRequest)
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

                await dao.CreateAsync(booking);
                return new BusinessResult(201, "Booking created successfully", booking);
            }
            catch (Exception ex)
            {
                return new BusinessResult(500, ex.Message);
            }
        }

        public async Task<IBusinessResult> UpdateBooking(int id, UpdateBookingRequestDTO updateRequest)
        {
            try
            {
                var booking = await dao.GetByIdAsync(id);
                if (booking == null)
                {
                    return new BusinessResult(404, "Booking not found");
                }

                booking.Status = updateRequest.Status;
                booking.UpdatedDate = DateTime.Now;

                if (updateRequest.PaymentStatus.HasValue)
                {
                    booking.Payment.Status = updateRequest.PaymentStatus.Value;
                    booking.Payment.UpdatedDate = DateTime.Now;
                }

                await dao.UpdateAsync(booking);

                return new BusinessResult(200, "Booking updated successfully", booking);
            }
            catch (Exception ex)
            {
                return new BusinessResult(500, ex.Message);
            }
        }
    }
}