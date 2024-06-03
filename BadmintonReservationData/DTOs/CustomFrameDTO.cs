

namespace BadmintonReservationData.DTOs
{
    public sealed record CustomFrameDTO(int id, int frameId, double pirce, DateTime specificDate, int dateType, string dateTypeName, 
        int status); 
}
