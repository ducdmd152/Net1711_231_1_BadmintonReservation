using BadmintonReservationData;
using BadmintonReservationData.DTO;

namespace BadmintonReservationWebApp.Models
{
    public class AddBookingModel
    {
        public int BookingTypeId { get; set; }
        public int Status { get; set; }
        public int PaymentStatus { get; set; }
        public double PromotionAmount { get; set; }
        public int PaymentType { get; set; }
        public int CustomerId { get; set; }
        public List<Customer> Customers { get; set; }
        public List<BookingDetailDTO> BookingDetails { get; set; } = new List<BookingDetailDTO>();
    }
}
