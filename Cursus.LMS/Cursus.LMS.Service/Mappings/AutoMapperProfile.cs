using AutoMapper;
using Cursus.LMS.Model.Domain;
using Cursus.LMS.Model.DTO;

namespace Cursus.LMS.Service.Mappings;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<UserInfoDTO, ApplicationUser>().ReverseMap();
        CreateMap<Category, CategoryDTO>().ReverseMap();
    }
}