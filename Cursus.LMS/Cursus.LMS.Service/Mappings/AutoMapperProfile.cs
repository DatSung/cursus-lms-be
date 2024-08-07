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

        CreateMap<EmailTemplateDTO, EmailTemplateDTO>()
            .ForMember(dest => dest.TemplateName, opt
                => opt.MapFrom(src => src.TemplateName))
            .ForMember(dest => dest.SenderName, opt
                => opt.MapFrom(src => src.SenderName))
            .ForMember(dest => dest.SenderEmail, opt
                => opt.MapFrom(src => src.SenderEmail))
            .ForMember(dest => dest.Category, opt
                => opt.MapFrom(src => src.Category))
            .ForMember(dest => dest.SubjectLine, opt
                => opt.MapFrom(src => src.SubjectLine))
            .ForMember(dest => dest.PreHeaderText, opt
                => opt.MapFrom(src => src.PreHeaderText))
            .ForMember(dest => dest.PersonalizationTags, opt
                => opt.MapFrom(src => src.PersonalizationTags))
            .ForMember(dest => dest.BodyContent, opt
                => opt.MapFrom(src => src.BodyContent))
            .ForMember(dest => dest.FooterContent, opt
                => opt.MapFrom(src => src.FooterContent))
            .ForMember(dest => dest.CallToAction, opt
                => opt.MapFrom(src => src.CallToAction))
            .ForMember(dest => dest.Language, opt
                => opt.MapFrom(src => src.Language))
            .ForMember(dest => dest.RecipientType, opt
                => opt.MapFrom(src => src.RecipientType))
            .ReverseMap();

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


        CreateMap<CourseVersion, GetCourseVersionDTO>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
            .ForMember(dest => dest.LevelName, opt => opt.MapFrom(src => src.Level.Name));

        CreateMap<CourseSectionVersion, GetCourseSectionDTO>().ReverseMap();
        
        CreateMap<CourseVersionStatus, GetCourseVersionStatusDTO>().ReverseMap();

        CreateMap<CourseVersionComment, GetCourseCommnetDTO>()
            .ForMember(dest => dest.CourseVersionId, opt => opt.MapFrom(src => src.CourseVersionId))
            .ForMember(dest => dest.Comment, opt => opt.MapFrom(src => src.Comment))
            .ForMember(dest => dest.CreateBy, opt => opt.MapFrom(src => src.CreatedBy))
            .ForMember(dest => dest.CreateTime, opt => opt.MapFrom(src => src.CreatedTime))
            .ForMember(dest => dest.UpdateBy, opt => opt.MapFrom(src => src.UpdatedBy))
            .ForMember(dest => dest.UpdateTime, opt => opt.MapFrom(src => src.UpdatedTime))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
            .ReverseMap();


        CreateMap<Course, GetCourseInfoDTO>().ReverseMap();
        CreateMap<Level, GetLevelDTO>().ReverseMap();

        CreateMap<Student, StudentInfoDTO>().ReverseMap();
        CreateMap<Student, StudentFullInfoDTO>()
            .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.StudentId))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.ApplicationUser.FullName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.ApplicationUser.Email))
            .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.ApplicationUser.PhoneNumber))
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.ApplicationUser.Gender))
            .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.ApplicationUser.BirthDate))
            .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.ApplicationUser.Country))
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.ApplicationUser.Address))
            .ForMember(dest => dest.AvatarUrl, opt => opt.MapFrom(src => src.ApplicationUser.AvatarUrl))
            .ForMember(dest => dest.University, opt => opt.MapFrom(src => src.University))
            .ReverseMap();
        //CreateMap<Student, StudentFullInfoDTO>().ReverseMap();


        CreateMap<StudentComment, GetAllCommentsDTO>().ReverseMap();
        CreateMap<StudentComment, CreateStudentCommentDTO>().ReverseMap();
        CreateMap<StudentComment, UpdateStudentCommentDTO>().ReverseMap();

        CreateMap<CartHeader, CartHeaderDTO>().ReverseMap();
        CreateMap<CartDetails, CartDetailsDTO>().ReverseMap();


        CreateMap<OrderHeader, GetOrderHeaderDTO>().ReverseMap();
        CreateMap<OrderDetails, GetOrderDetailsDTO>().ReverseMap();

        CreateMap<Transaction, GetTransactionDTO>().ReverseMap();

        CreateMap<CourseBookmark, CreateCourseBookmarkDTO>().ReverseMap();

        CreateMap<Company, UpdateCompanyDTO>().ReverseMap();
        CreateMap<Privacy, CreatePrivacyDTO>().ReverseMap();
        CreateMap<Privacy, UpdatePrivacyDTO>().ReverseMap();
        CreateMap<TermOfUse, CreateTermOfUseDTO>().ReverseMap();
        CreateMap<TermOfUse, UpdateTermOfUseDTO>().ReverseMap();

        CreateMap<Balance, GetBalanceDTO>().ReverseMap();

        CreateMap<OrderStatus, GetOrdersStatusDTO>().ReverseMap();

        CreateMap<CourseVersion, GetCourseDTO>().ReverseMap();

        CreateMap<CourseReview, GetCourseReviewDTO>().ReverseMap();
    }
}