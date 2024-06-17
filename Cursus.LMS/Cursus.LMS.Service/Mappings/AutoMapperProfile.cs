using AutoMapper;
using Cursus.LMS.Model.Domain;
using Cursus.LMS.Model.DTO;
using Cursus.LMS.Utility.Constants;

namespace Cursus.LMS.Service.Mappings;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<UserInfoDTO, ApplicationUser>().ReverseMap();
        CreateMap<Category, CategoryDTO>().ReverseMap();
        CreateMap<Category, CreateCategoryDTO>().ReverseMap();
        CreateMap<Category, UpdateCategoryDTO>().ReverseMap();
        CreateMap<Category, AdminCategoryDTO>().ReverseMap();
    }
}