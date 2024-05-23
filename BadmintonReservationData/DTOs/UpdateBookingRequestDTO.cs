namespace BadmintonReservationData.DTOs
{
    public class UpdateBookingRequestDTO
    {
        public int Status { get; set; } // 1: Pending, 2: Successful, 3: Cancelled
        public int? PaymentStatus { get; set; } // 1: NotYet, 2: Paid, 3: Refund
    }
}
