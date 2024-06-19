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

        CreateMap<Instructor, InstructorInfoLiteDTO>()
            .ForMember(dest => dest.FullName, opt
                => opt.MapFrom(src => src.ApplicationUser.FullName))
            .ForMember(dest => dest.Email, opt
                => opt.MapFrom(src => src.ApplicationUser.Email))
            .ForMember(dest => dest.PhoneNumber, opt
                => opt.MapFrom(src => src.ApplicationUser.PhoneNumber))
            .ForMember(dest => dest.Gender, opt
                => opt.MapFrom(src => src.ApplicationUser.Gender))
            .ForMember(dest => dest.BirthDate, opt
                => opt.MapFrom(src => src.ApplicationUser.BirthDate))
            .ForMember(dest => dest.IsAccepted, opt
                => opt.MapFrom(src => src.IsAccepted))
            .ReverseMap();
    }
}