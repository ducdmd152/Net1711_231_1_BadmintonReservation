namespace BadmintonReservationData.DTOs
{
    public class CreateBookingRequestDTO
    {
        public int CustomerId { get; set; }
        public int Status { get; set; }
        public int BookingTypeId { get; set; }
        public DateTime? BookingDateFrom { get; set; }
        public DateTime? BookingDateTo { get; set; }
        public double PromotionAmount { get; set; }
        public int PaymentType { get; set; } // 1: Thanh toán tại quầy, 2: Thanh toán thẻ
        public List<BookingDetailDTO> BookingDetails { get; set; }
    }
}
