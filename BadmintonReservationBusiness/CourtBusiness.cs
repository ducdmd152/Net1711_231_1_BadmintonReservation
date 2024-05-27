using BadmintonReservationData;
using BadmintonReservationData.DTOs;
using BadmintonReservationData.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadmintonReservationBusiness
{
    public class CourtBusiness
    {
        private readonly UnitOfWork unitOfWork;

        public CourtBusiness(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IBusinessResult> GetAll()
        {
            try
            {
                var courts = await this.unitOfWork.CourtRepository.GetAllAsync();

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
                var court = this.unitOfWork.CourtRepository.GetById(id);

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

        public async Task<IBusinessResult> CreateCourt(CourtRequestDTO courtRequest)
        { 
            await this.unitOfWork.BeginTransactionAsync();
            try
            {
                var court = new Court
                {
                    Name = courtRequest.Name,
                    Status = courtRequest.Status,
                };

                await this.unitOfWork.CourtRepository.CreateAsync(court);
                await this.unitOfWork.CommitTransactionAsync();
                return new BusinessResult(200, "Create Success");     
            }
            catch (Exception ex)
            {
                this.unitOfWork.RollbackTransaction();
                return new BusinessResult(-4, ex.Message);
            }
        }

        public async Task<IBusinessResult> UpdateCourt(CourtRequestDTO courtRequest)
        {
            await this.unitOfWork.BeginTransactionAsync();
            try
            {
                var court = this.unitOfWork.CourtRepository.GetById(courtRequest.Id);

                if (court == null)
                {
                    return new BusinessResult(-1, "No court data");
                }

                court.Name = courtRequest.Name;
                court.Status = courtRequest.Status;
                this.unitOfWork.CourtRepository.Update(court);
                await this.unitOfWork.CommitTransactionAsync();

                return new BusinessResult(200, "Update court success");
            }
            catch (Exception ex)
            {
                this.unitOfWork.RollbackTransaction();
                return new BusinessResult(-4, ex.Message);
            }
        }

        public async Task<IBusinessResult> RemoveCourt(int id)
        {
            await this.unitOfWork.BeginTransactionAsync();
            try
            {
                var court = this.unitOfWork.CourtRepository.GetById(id);

                if (court == null)
                {
                    return new BusinessResult(-1, "No court data");
                }

                this.unitOfWork.CourtRepository.Remove(court);
                await this.unitOfWork.CommitTransactionAsync();

                return new BusinessResult(200, "Delete Success");
            }
            catch (Exception ex)
            {
                this.unitOfWork.RollbackTransaction();
                return new BusinessResult(-4, ex.Message);
            }
        }
    } 
}