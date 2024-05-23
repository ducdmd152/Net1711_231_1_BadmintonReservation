using System;
using System.Collections.Generic;

namespace BadmintonReservationData
{
    public partial class CustomFrame
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public DateTime SpecificDate { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int FrameId { get; set; }
        public int FixedDateTypeId { get; set; }

        public virtual DateType FixedDateType { get; set; } = null!;
        public virtual Frame Frame { get; set; } = null!;
    }
}
