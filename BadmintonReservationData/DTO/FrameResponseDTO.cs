namespace BadmintonReservationData.DTOs;

public class FrameResponseDTO
{
    public int Id { get; set; }
    public TimeSpan TimeFrom { get; set; }
    public TimeSpan TimeTo { get; set; }
    public int Status { get; set; }
    public double Price { get; set; }
    public int CourtId { get; set; }
}