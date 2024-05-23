using System;
using System.Collections.Generic;

namespace BadmintonReservationData
{
    public partial class Court
    {
        public Court()
        {
            Frames = new HashSet<Frame>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public virtual ICollection<Frame> Frames { get; set; }
    }
}
