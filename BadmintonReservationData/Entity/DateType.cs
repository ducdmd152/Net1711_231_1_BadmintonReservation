using System;
using System.Collections.Generic;

namespace BadmintonReservationData
{
    public partial class DateType
    {
        public DateType()
        {
            CustomFrames = new HashSet<CustomFrame>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public virtual ICollection<CustomFrame> CustomFrames { get; set; }
    }
}
