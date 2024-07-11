namespace BadmintonReservationWebApp.Models
{
    public class CourtSearchCondition
    {
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 4;
        public string SearchText { get; set; } = "";
        public int SearchMode { get; set; } = 1;
        public int StatusFilter { get; set; } = 0;
        public int SurfaceTypeFilter { get; set; } = 0;
        public int CourtType { get; set; } = 0;
        public int OpeningHours { get; set; } = 0;
        public int CloseHours { get; set; } = 0;
    }
}
