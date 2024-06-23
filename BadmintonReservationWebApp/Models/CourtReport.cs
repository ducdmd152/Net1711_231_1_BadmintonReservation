using BadmintonReservationData;

namespace BadmintonReservationWebApp.Models
{
    public class CourtReport
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Status { get; set; }
        public int SurfaceType { get; set; }
        public int OpeningHours { get; set; }
        public int CloseHours { get; set; }
        public string? Amentities { get; set; }
        public int Capacity { get; set; }
        public int CourtType { get; set; }
        public string TotalBooking { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public List<Frame> Frames { get; set; } = new List<Frame> ();
    }
}
