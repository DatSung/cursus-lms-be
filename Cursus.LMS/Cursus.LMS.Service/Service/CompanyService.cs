using AutoMapper;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Service.IService;

namespace Cursus.LMS.Service.Service;

public class CompanyService : ICompanyService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CompanyService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ResponseDTO> GetCompany()
    {
        try
        {
            var company = await _unitOfWork.CompanyRepository.GetAsync(c => c.Id != Guid.Empty);
            if (company == null)
            {
                return new ResponseDTO
                {
                    IsSuccess = false,
                    Message = "Company not found",
                    StatusCode = 404
                };
            }
            return new ResponseDTO
            {
                IsSuccess = true,
                Message = "Get company successfully",
                StatusCode = 200,
                Result = company 
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

    public async Task<ResponseDTO> UpdateCompany(UpdateCompanyDTO companyDto)
    {
        try
        {
            var company = await _unitOfWork.CompanyRepository.GetAsync(c => c.Id == companyDto.Id);
            if (company == null)
            {
                return new ResponseDTO
                {
                    IsSuccess = false,
                    Message = "Company not found",
                    StatusCode = 404
                };
            }

            _mapper.Map(companyDto, company);
            _unitOfWork.CompanyRepository.Update(company);
            await _unitOfWork.SaveAsync();

            return new ResponseDTO
            {
                IsSuccess = true,
                Message = "Company updated successfully",
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