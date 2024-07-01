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

        CreateMap<CreateCategoryDTO, Category>()
            .ForMember(dest => dest.Id, opt
                => opt.MapFrom(src => Guid.NewGuid()))
            .ForMember(dest => dest.ParentId, opt
                => opt.MapFrom(src => src.ParentId != null ? Guid.Parse(src.ParentId) : (Guid?)null))
            .ReverseMap();

        CreateMap<Category, UpdateCategoryDTO>().ReverseMap();

        CreateMap<Category, AdminCategoryDTO>()
            .ForMember(dest => dest.ParentName, opt
                => opt.MapFrom(src => src.ParentCategory.Name)).ReverseMap();

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

        CreateMap<Instructor, InstructorInfoDTO>()
            .ForMember(dest => dest.InstructorId, opt
                => opt.MapFrom(src => src.InstructorId))
            .ForMember(dest => dest.UserId, opt
                => opt.MapFrom(src => src.UserId))
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
            .ForMember(dest => dest.Country, opt
                => opt.MapFrom(src => src.ApplicationUser.Country))
            .ForMember(dest => dest.Address, opt
                => opt.MapFrom(src => src.ApplicationUser.Address))
            .ForMember(dest => dest.Degree, opt
                => opt.MapFrom(src => src.Degree))
            .ForMember(dest => dest.Industry, opt
                => opt.MapFrom(src => src.Industry))
            .ForMember(dest => dest.TaxNumber, opt
                => opt.MapFrom(src => src.ApplicationUser.TaxNumber))
            .ForMember(dest => dest.IsAccepted, opt
                => opt.MapFrom(src => src.IsAccepted))
            .ReverseMap();

        CreateMap<InstructorComment, GetAllCommentsDTO>().ReverseMap();
        CreateMap<InstructorComment, CreateInstructorCommentDTO>().ReverseMap();
        CreateMap<InstructorComment, UpdateInstructorCommentDTO>().ReverseMap();


        CreateMap<CourseVersion, GetCourseVersionDTO>().ReverseMap();
        CreateMap<CourseVersionStatus, GetCourseVersionStatusDTO>().ReverseMap();
        
        CreateMap<CourseVersionComment, GetCourseCommnetDTO>()
            .ForMember(dest => dest.CourseVersionId, opt => opt.MapFrom(src => src.CourseVersionId))
            .ForMember(dest => dest.Comment, opt => opt.MapFrom(src => src.Comment))
            .ForMember(dest => dest.CreateBy, opt => opt.MapFrom(src => src.CreateBy))
            .ForMember(dest => dest.CreateTime, opt => opt.MapFrom(src => src.CreateTime))
            .ForMember(dest => dest.UpdateBy, opt => opt.MapFrom(src => src.UpdateBy))
            .ForMember(dest => dest.UpdateTime, opt => opt.MapFrom(src => src.UpdateTime))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
            .ReverseMap();
    }
}