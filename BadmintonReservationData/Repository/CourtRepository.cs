using BadmintonReservationData.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadmintonReservationData.Repository
{
    public class CourtRepository : GenericRepository<Court>
    {
        public CourtRepository(UnitOfWork unitOfWork) : base(unitOfWork)
        {            
        }
    }
}
