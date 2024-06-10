namespace BadmintonReservationData.DTOs;

public class FrameResponseDTO
{
    public int Id { get; set; }
    public int TimeFrom { get; set; }
    public int TimeTo { get; set; }
    public int Status { get; set; }
    public double Price { get; set; }
    public int CourtId { get; set; }
}