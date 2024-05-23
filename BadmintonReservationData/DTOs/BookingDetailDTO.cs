namespace BadmintonReservationData.DTOs
{
    public class BookingDetailDTO
    {
        public DateTime BookDate { get; set; }
        public int FrameId { get; set; }
        public DateTime TimeFrom { get; set; }
        public DateTime TimeTo { get; set; }
        public double Price { get; set; }
    }
}
