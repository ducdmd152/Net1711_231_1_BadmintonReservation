using BadmintonReservationData;

namespace BadmintonReservationWebApp.Models
{
    public class CourtReport
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public List<Frame> Frames { get; set; } = new List<Frame> ();
    }
}
