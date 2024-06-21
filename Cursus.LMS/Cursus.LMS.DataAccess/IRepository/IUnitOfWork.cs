using Cursus.LMS.DataAccess.IRepository;

namespace Cursus.LMS.DataAccess.IRepository;

public interface IUnitOfWork
{
    IStudentRepository StudentRepository { get; }
    IPaymentCardRepository PaymentCardRepository { get; }
    IInstructorRepository InstructorRepository { get; }
    Task<int> SaveAsync();
    ICategoryRepository CategoryRepository { get; }
    IEmailTemplateRepository EmailTemplateRepository { get; }
    IUserManagerRepository UserManagerRepository { get; }
    IInstructorCommentRepository InstructorCommentRepository { get; }
    ICourseRepository CourseRepository { get; }
}