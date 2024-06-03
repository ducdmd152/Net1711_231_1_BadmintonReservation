using BadmintonReservationData;
using BadmintonReservationData.DTOs;

namespace BadmintonReservationBusiness;

public class FrameBusiness
{
    private readonly UnitOfWork unitOfWork;

    public FrameBusiness(UnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<IBusinessResult> GetAll()
    {
        try
        {
            var frames = await unitOfWork.FrameRepository.GetAllWithCourtAsync();
            if (frames == null)
            {
                return new BusinessResult(400, "No frame data");
            }
            else
            {
                return new BusinessResult(200, "Get frame list success", frames);
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
            var frame = await unitOfWork.FrameRepository.GetByIdAsync(id);

            if (frame == null)
            {
                return new BusinessResult(400, "No frame data");
            }
            else
            {
                var response = new FrameResponseDTO
                {
                    Id = frame.Id,
                    TimeFrom = frame.TimeFrom.TimeOfDay,
                    TimeTo = frame.TimeTo.TimeOfDay,
                    Price = frame.Price,
                    Status = frame.Status,
                    CourtId = frame.CourtId
                };
                return new BusinessResult(200, "Get frame success", response);
            }
        }
        catch (Exception ex)
        {
            return new BusinessResult(500, ex.Message);
        }
    }

    public async Task<IBusinessResult> CreateFrame(CreateFrameRequestDTO createFrameRequestDto)
    {
        await this.unitOfWork.BeginTransactionAsync();
        try
        {
            var baseDate = DateTime.Today;
            var frame = new Frame()
            {
                TimeFrom = baseDate.Add(createFrameRequestDto.TimeFrom),
                TimeTo = baseDate.Add(createFrameRequestDto.TimeTo),
                Status = createFrameRequestDto.Status,
                Price = createFrameRequestDto.Price,
                CourtId = createFrameRequestDto.CourtId
            };

            await unitOfWork.FrameRepository.CreateAsync(frame);
            await unitOfWork.CommitTransactionAsync();
            return new BusinessResult(200, "Create Success");
        }
        catch (Exception ex)
        {
            this.unitOfWork.RollbackTransaction();
            return new BusinessResult(500, ex.Message);
        }
    }

    public async Task<IBusinessResult> UpdateFrame(UpdateFrameRequestDTO updateFrameRequestDto)
    {
        await this.unitOfWork.BeginTransactionAsync();
        try
        {
            var frame = await unitOfWork.FrameRepository.GetByIdAsync(updateFrameRequestDto.Id);

            if (frame == null)
            {
                return new BusinessResult(400, "No frame data");
            }
            var baseDate = DateTime.Today;
            frame.TimeFrom = baseDate.Add(updateFrameRequestDto.TimeFrom);
            frame.TimeTo = baseDate.Add(updateFrameRequestDto.TimeTo);
            frame.Status = updateFrameRequestDto.Status;
            frame.Price = updateFrameRequestDto.Price;
            frame.CourtId = updateFrameRequestDto.CourtId;
            unitOfWork.FrameRepository.Update(frame);
            await unitOfWork.CommitTransactionAsync();

            return new BusinessResult(200, "Update frame success");
        }
        catch (Exception ex)
        {
            unitOfWork.RollbackTransaction();
            return new BusinessResult(500, ex.Message);
        }
    }

    public async Task<IBusinessResult> RemoveFrame(int id)
    {
        await this.unitOfWork.BeginTransactionAsync();
        try
        {
            var frame = await unitOfWork.FrameRepository.GetByIdAsync(id);

            if (frame == null)
            {
                return new BusinessResult(-1, "No frame data");
            }

            unitOfWork.FrameRepository.Remove(frame);
            await unitOfWork.CommitTransactionAsync();

            return new BusinessResult(200, "Delete Success");
        }
        catch (Exception ex)
        {
            this.unitOfWork.RollbackTransaction();
            return new BusinessResult(500, ex.Message);
        }
    }
}