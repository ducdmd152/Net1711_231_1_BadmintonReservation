using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadmintonReservationData.DTO
{
    public class UpdateCourtDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Court Name is required")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "Court status is required")]
        public int Status { get; set; }
    }
}
