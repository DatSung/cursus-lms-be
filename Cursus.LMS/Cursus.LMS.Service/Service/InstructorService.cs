using System.Security.Claims;
using AutoMapper;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;
using Cursus.LMS.Utility.Constants;
using Microsoft.IdentityModel.Tokens;

namespace Cursus.LMS.Service.Service;

public class InstructorService : IInstructorService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public InstructorService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }


    public async Task<ResponseDTO> GetAll
    (
        ClaimsPrincipal User,
        string? filterOn,
        string? filterQuery,
        string? sortBy,
        bool? isAscending,
        int pageNumber,
        int pageSize
    )
    {
        try
        {
            var instructors = await _unitOfWork.InstructorRepository.GetAsync(x => x.IsAccepted == true);
            return new ResponseDTO()
            {
                IsSuccess = true,
                StatusCode = 200,
                Result = instructors,
                Message = "Get all instructor successfully"
            };
        }
        catch (Exception e)
        {
            return new ResponseDTO()
            {
                IsSuccess = false,
                StatusCode = 500,
                Result = null,
                Message = e.Message
            };
        }
    }

    public Task<ResponseDTO> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDTO> UpdateById(Guid id, UpdateInstructorDTO updateInstructorDto)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDTO> AcceptInstructor(ClaimsPrincipal User, Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDTO> RejectInstructor(ClaimsPrincipal User, Guid id)
    {
        throw new NotImplementedException();
    }
}