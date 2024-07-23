using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;

namespace Cursus.LMS.Service.Service;

public class CourseProgressService : ICourseProgressService
{
    public Task<ResponseDTO> CreateProgress(CreateProgressDTO createProgressDto)
    {
        try
        {
            throw new NotImplementedException();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Task<ResponseDTO> UpdateProgress(UpdateProgressDTO updateProgressDto)
    {
        try
        {
            throw new NotImplementedException();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Task<ResponseDTO> GetProgress(GetProgressDTO getProgressDto)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDTO> GetPercentage(GetPercentageDTO getPercentageDto)
    {
        throw new NotImplementedException();
    }
}