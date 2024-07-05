using System.Security.Claims;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;
using DocumentFormat.OpenXml.Spreadsheet;

namespace Cursus.LMS.Service.Service;

public class LevelService : ILevelService
{
    private readonly IUnitOfWork _unitOfWork;

    public LevelService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseDTO> GetLevels
    (
        ClaimsPrincipal User,
        string? filterOn,
        string? filterQuery,
        string? sortBy,
        bool? isAscending,
        int pageNumber = 1,
        int pageSize = 5
    )
    {
        try
        {
            var levels = await _unitOfWork.LevelRepository.GetAllAsync();
            return new ResponseDTO()
            {
                Result = levels
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Task<ResponseDTO> GetLevel(ClaimsPrincipal User, Guid levelId)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDTO> CreateLevel(ClaimsPrincipal User, CreateLevelDTO createLevelDto)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDTO> UpdateLevel(ClaimsPrincipal User, UpdateLevelDTO updateLevelDto)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDTO> DeleteLevel(ClaimsPrincipal User, Guid levelId)
    {
        throw new NotImplementedException();
    }
}