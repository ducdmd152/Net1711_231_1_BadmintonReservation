namespace BadmintonReservationData.DTOs
{
    public class BookingDetailDTO
    {
        public DateTime BookDate { get; set; }
        public int FrameId { get; set; }
        public int TimeFrom { get; set; }
        public int TimeTo { get; set; }
        public double Price { get; set; }
    }
}
