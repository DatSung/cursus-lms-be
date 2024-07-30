using AutoMapper;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;

namespace Cursus.LMS.Service.Service;

public class PrivacyService : IPrivacyService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PrivacyService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ResponseDTO> GetPrivacies()
    {
        try
        {
            var privacies = await _unitOfWork.PrivacyRepository.GetAllAsync();
            return new ResponseDTO
            {
                IsSuccess = true,
                Message = "Get privacies successfully",
                StatusCode = 200,
                Result = privacies
            };
        }
        catch (Exception ex)
        {
            return new ResponseDTO
            {
                IsSuccess = false,
                Message = ex.Message,
                StatusCode = 500
            };
        }
    }

    public async Task<ResponseDTO> GetPrivacy(Guid id)
    {
        try
        {
            var privacy = await _unitOfWork.PrivacyRepository.GetAsync(p => p.Id == id);
            if (privacy == null)
            {
                return new ResponseDTO
                {
                    IsSuccess = false,
                    Message = "Privacy policy not found",
                    StatusCode = 404
                };
            }
            return new ResponseDTO
            {
                IsSuccess = true,
                Message = "Get privacy policy successfully",
                StatusCode = 200,
                Result = privacy
            };
        }
        catch (Exception ex)
        {
            return new ResponseDTO
            {
                IsSuccess = false,
                Message = ex.Message,
                StatusCode = 500
            };
        }
    }

    public async Task<ResponseDTO> CreatePrivacy(CreatePrivacyDTO privacyDto)
    {
        try
        {
            var privacy = _mapper.Map<Privacy>(privacyDto);
            privacy.Id = Guid.NewGuid();
            privacy.LastUpdated = DateTime.Now; 

            await _unitOfWork.PrivacyRepository.AddAsync(privacy);
            await _unitOfWork.SaveAsync();

            return new ResponseDTO
            {
                IsSuccess = true,
                Message = "Privacy policy created successfully",
                StatusCode = 200,
                Result = privacy 
            };
        }
        catch (Exception ex)
        {
            return new ResponseDTO
            {
                IsSuccess = false,
                Message = ex.Message,
                StatusCode = 500
            };
        }
    }

    public async Task<ResponseDTO> UpdatePrivacy(UpdatePrivacyDTO privacyDto)
    {
        try
        {
            var privacy = await _unitOfWork.PrivacyRepository.GetAsync(p => p.Id == privacyDto.Id);
            if (privacy == null)
            {
                return new ResponseDTO
                {
                    IsSuccess = false,
                    Message = "Privacy policy not found",
                    StatusCode = 404
                };
            }

            _mapper.Map(privacyDto, privacy);
            privacy.LastUpdated = DateTime.Now;

            _unitOfWork.PrivacyRepository.Update(privacy);
            await _unitOfWork.SaveAsync();

            return new ResponseDTO
            {
                IsSuccess = true,
                Message = "Privacy policy updated successfully",
                StatusCode = 200
            };
        }
        catch (Exception ex)
        {
            return new ResponseDTO
            {
                IsSuccess = false,
                Message = ex.Message,
                StatusCode = 500
            };
        }
    }

    public async Task<ResponseDTO> DeletePrivacy(Guid id)
    {
        try
        {
            var privacy = await _unitOfWork.PrivacyRepository.GetAsync(p => p.Id == id);
            if (privacy == null)
            {
                return new ResponseDTO
                {
                    IsSuccess = false,
                    Message = "Privacy policy not found",
                    StatusCode = 404
                };
            }

            privacy.IsActive = false;
            await _unitOfWork.SaveAsync();

            return new ResponseDTO
            {
                IsSuccess = true,
                Message = "Privacy policy deleted successfully",
                StatusCode = 200
            };
        }
        catch (Exception ex)
        {
            return new ResponseDTO
            {
                IsSuccess = false,
                Message = ex.Message,
                StatusCode = 500
            };
        }
    }
}
