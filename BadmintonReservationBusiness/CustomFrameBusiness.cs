using BadmintonReservationData;
using BadmintonReservationData.DTOs;
using BadmintonReservationData.Enums;

namespace BadmintonReservationBusiness
{
    public class CustomFrameBusiness
    {
        private readonly UnitOfWork _unitOfWork;

        public CustomFrameBusiness(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IBusinessResult> GetAll()
        {
            try
            {
                var customFrames = await this._unitOfWork.CustomFrameRepository.GetAllAsync();

                if (customFrames == null)
                {
                    return new BusinessResult(400, "No court data");
                }
                else
                {
                    return new BusinessResult(200, "Get court list sucess", customFrames);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(500, ex.Message);
            }
        }

        public async Task<IBusinessResult> GetById(int id)
        {
            try
            {
                var customFrames = this._unitOfWork.CustomFrameRepository.GetById(id);

                if (customFrames == null)
                {
                    return new BusinessResult(-1, "No court data");
                }
                else
                {
                    return new BusinessResult(1, "Get court sucess", customFrames);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(-4, ex.Message);
            }
        }

        public async Task<IBusinessResult> CreateCourt(CustomFrameDTO customFrameRequest)
        {
            await this._unitOfWork.BeginTransactionAsync();
            try
            {
                var customFrame = new CustomFrame
                {
                    FrameId = customFrameRequest.frameId,
                    Price = customFrameRequest.pirce,
                    SpecificDate = customFrameRequest.specificDate,
                    Status = customFrameRequest.status,
                    FixedDateTypeId = customFrameRequest.dateType
                };

                await this._unitOfWork.CustomFrameRepository.CreateAsync(customFrame);              
                await this._unitOfWork.CommitTransactionAsync();
                return new BusinessResult(200, "Create Success");
            }
            catch (Exception ex)
            {
                this._unitOfWork.RollbackTransaction();
                return new BusinessResult(-4, ex.Message);
            }
        }
    }
}
