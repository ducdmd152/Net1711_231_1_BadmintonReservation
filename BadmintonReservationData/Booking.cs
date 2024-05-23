using System;
using System.Collections.Generic;

namespace BadmintonReservationData
{
    public partial class Booking
    {
        public Booking()
        {
            BookingDetails = new HashSet<BookingDetail>();
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int BookingTypeId { get; set; }
        public DateTime? BookingDateFrom { get; set; }
        public DateTime? BookingDateTo { get; set; }
        public int Status { get; set; }
        public double PromotionAmount { get; set; }
        public int PaymentType { get; set; }
        public int PaymentId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public virtual BookingType BookingType { get; set; } = null!;
        public virtual Customer Customer { get; set; } = null!;
        public virtual Payment Payment { get; set; } = null!;
        public virtual ICollection<BookingDetail> BookingDetails { get; set; }
    }
}
