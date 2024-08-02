using AutoMapper;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;

namespace Cursus.LMS.Service.Service;

public class TermOfUseService : ITermOfUseService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public TermOfUseService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ResponseDTO> GetTermOfUses()
    {
        try
        {
            var termOfUses = await _unitOfWork.TermOfUseRepository.GetAllAsync();
            return new ResponseDTO
            {
                IsSuccess = true,
                Message = "Get terms of use successfully",
                StatusCode = 200,
                Result = termOfUses
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

    public async Task<ResponseDTO> GetTermOfUse(Guid id)
    {
        try
        {
            var termOfUse = await _unitOfWork.TermOfUseRepository.GetAsync(t => t.Id == id);
            if (termOfUse == null)
            {
                return new ResponseDTO
                {
                    IsSuccess = false,
                    Message = "Term of use not found",
                    StatusCode = 404
                };
            }
            return new ResponseDTO
            {
                IsSuccess = true,
                Message = "Get term of use successfully",
                StatusCode = 200,
                Result = termOfUse
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

    public async Task<ResponseDTO> CreateTermOfUse(CreateTermOfUseDTO termOfUseDto)
    {
        try
        {
            var termOfUse = _mapper.Map<TermOfUse>(termOfUseDto);
            termOfUse.Id = Guid.NewGuid();
            termOfUse.LastUpdated = DateTime.Now; // Set last updated time

            await _unitOfWork.TermOfUseRepository.AddAsync(termOfUse);
            await _unitOfWork.SaveAsync();

            return new ResponseDTO
            {
                IsSuccess = true,
                Message = "Term of use created successfully",
                StatusCode = 201,
                Result = termOfUse.Id // Return the ID of the newly created term of use
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

    public async Task<ResponseDTO> UpdateTermOfUse(UpdateTermOfUseDTO termOfUseDto)
    {
        try
        {
            var termOfUse = await _unitOfWork.TermOfUseRepository.GetAsync(t => t.Id == termOfUseDto.Id);
            if (termOfUse == null)
            {
                return new ResponseDTO
                {
                    IsSuccess = false,
                    Message = "Term of use not found",
                    StatusCode = 404
                };
            }

            _mapper.Map(termOfUseDto, termOfUse);
            termOfUse.LastUpdated = DateTime.Now; // Update last updated time

            _unitOfWork.TermOfUseRepository.Update(termOfUse);
            await _unitOfWork.SaveAsync();

            return new ResponseDTO
            {
                IsSuccess = true,
                Message = "Term of use updated successfully",
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

    public async Task<ResponseDTO> DeleteTermOfUse(Guid id)
    {
        try
        {
            var termOfUse = await _unitOfWork.TermOfUseRepository.GetAsync(t => t.Id == id);
            if (termOfUse == null)
            {
                return new ResponseDTO
                {
                    IsSuccess = false,
                    Message = "Term of use not found",
                    StatusCode = 404
                };
            }

            termOfUse.IsActive = false;
            await _unitOfWork.SaveAsync();

            return new ResponseDTO
            {
                IsSuccess = true,
                Message = "Term of use deleted successfully",
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