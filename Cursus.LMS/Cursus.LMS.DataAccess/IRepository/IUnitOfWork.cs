using Cursus.LMS.DataAccess.IRepository;

namespace Cursus.LMS.DataAccess.IRepository;

public interface IUnitOfWork
{
    IStudentRepository StudentRepository { get; }
    IInstructorRepository InstructorRepository { get; }
    ICategoryRepository CategoryRepository { get; }
    IEmailTemplateRepository EmailTemplateRepository { get; }
    IUserManagerRepository UserManagerRepository { get; }
    IInstructorCommentRepository InstructorCommentRepository { get; }
    ICourseRepository CourseRepository { get; }
    IPaymentCardRepository PaymentCardRepository { get; }
    IInstructorRatingRepository InstructorRatingRepository { get; }
    ICourseVersionRepository CourseVersionRepository { get; }
    ICourseSectionVersionRepository CourseSectionVersionRepository { get; }
    ISectionDetailsVersionRepository SectionDetailsVersionRepository { get; }
    ICourseVersionStatusRepository CourseVersionStatusRepository { get; }
    ICourseVersionCommentRepository CourseVersionCommentRepository { get; }
    IStudentCourseRepository StudentCourseRepository { get; }
    Task<int> SaveAsync();
}