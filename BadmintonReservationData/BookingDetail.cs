using System;
using System.Collections.Generic;

namespace BadmintonReservationData
{
    public partial class BookingDetail
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public DateTime BookDate { get; set; }
        public int FrameId { get; set; }
        public DateTime TimeFrom { get; set; }
        public DateTime TimeTo { get; set; }
        public double Price { get; set; }
        public int Status { get; set; }
        public DateTime? CheckinTime { get; set; }
        public DateTime? CheckoutTime { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public virtual Booking Booking { get; set; } = null!;
        public virtual Frame Frame { get; set; } = null!;
    }
}
