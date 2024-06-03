using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadmintonReservationData.DTOs
{
    public class CreatePurchasedRequestDTO
    {
        public double AmountHour { get; set; }
        public int Status { get; set; }
        public int CustomerId { get; set; }
        public int PaymentId { get; set; }
    }
}