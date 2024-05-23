using BadmintonReservationData.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadmintonReservationBusiness
{
    public class CourtBusiness
    {
        private readonly CourtDAO dao;

        public CourtBusiness()
        {
            this.dao = new CourtDAO();
        }

        public async Task<IBusinessResult> GetAll()
        {
            try
            {
                var courts = await dao.GetAllAsync();

                if (courts == null)
                {
                    return new BusinessResult(400, "No court data");
                }
                else
                {
                    return new BusinessResult(200, "Get court list sucess", courts);
                }
            }
            catch (Exception ex) {
                return new BusinessResult(500, ex.Message);
            }
        }

        public async Task<IBusinessResult> GetById(int id)
        {
            try
            {
                var court = dao.GetById(id);

                if (court == null)
                {
                    return new BusinessResult(-1, "No court data");
                }
                else
                {
                    return new BusinessResult(1, "Get court sucess", court);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(-4, ex.Message);
            }
        }
    } 
}