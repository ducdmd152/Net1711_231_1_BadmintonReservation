using BadmintonReservationData.Base;
using BadmintonReservationData.DTO;
using BadmintonReservationData.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadmintonReservationData.Repository
{
    public class PurchasedRepository : GenericRepository<PurchasedHoursMonthly>
    {
        public PurchasedRepository(UnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public List<PurchasedHoursMonthly> GetAllWithCustomerAndPayment()
        {
            return this._dbSet
                .IgnoreAutoIncludes()
                .Include(x => x.Customer)
                .Include(x => x.Payment)
                .ToList();
        }

        public PurchasedHoursMonthly GetWithCustomerById(int id)
        {
            return this._dbSet.Include(x => x.Customer).Include(x => x.Payment).Where(x => x.Id == id).FirstOrDefault();
        }

        public async Task<PageableResponseDTO<PurchasedHoursMonthly>> GetAllWithFilterWithAsync(int pageIndex, int pageSize, PurchasedFilterDTO filter)
        {
            var query = this._dbSet
                              .IgnoreAutoIncludes()
                              .Where(item => item.Id.ToString().Contains(filter.SearchText)
                                  || item.Customer.FullName.ToLower().Contains(filter.SearchText.ToLower())
                                  || item.Customer.PhoneNumber.ToLower().Contains(filter.SearchText.ToLower()))
                              .Where(item => filter.Status == 0 || item.Status == filter.Status)
                              .Where(item => item.AmountHour >= filter.AmountHour)
                              .Include(item => item.Customer)
                              .Include(item => item.Payment)
                              .OrderByDescending(item => item.CreatedDate);

            var totalItemCount = await query.CountAsync();
            var totalOfPages = (int)Math.Ceiling((double)totalItemCount / pageSize);

            // Apply pagination
            var list = await query.Skip((pageIndex - 1) * pageSize)
                                  .Take(pageSize)
                                  .ToListAsync();

            return new PageableResponseDTO<PurchasedHoursMonthly>()
            {
                List = list.ToList(),
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalOfPages = totalOfPages
            };
        }
    }
}