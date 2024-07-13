using Cursus.LMS.DataAccess.Context;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;


namespace Cursus.LMS.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IStudentRepository StudentRepository { get; set; }
        public IInstructorRepository InstructorRepository { get; set; }
        public ICategoryRepository CategoryRepository { get; }
        public IEmailTemplateRepository EmailTemplateRepository { get; }
        public IUserManagerRepository UserManagerRepository { get; }
        public IInstructorCommentRepository InstructorCommentRepository { get; }
        public IPaymentCardRepository PaymentCardRepository { get; set; }
        public ICourseRepository CourseRepository { get; set; }
        public IInstructorRatingRepository InstructorRatingRepository { get; set; }
        public ICourseVersionRepository CourseVersionRepository { get; }
        public ICourseSectionVersionRepository CourseSectionVersionRepository { get; }
        public ISectionDetailsVersionRepository SectionDetailsVersionRepository { get; }
        public ICourseVersionStatusRepository CourseVersionStatusRepository { get; }
        public ICourseVersionCommentRepository CourseVersionCommentRepository { get; }
        public IStudentCourseRepository StudentCourseRepository { get; }
        public ILevelRepository LevelRepository { get; }
        public ICartHeaderRepository CartHeaderRepository { get; }
        public ICartDetailsRepository CartDetailsRepository { get; }
        public ICourseReviewRepository CourseReviewRepository { get; }
        public ICourseReportRepository CourseReportRepository { get; }
        public IOrderHeaderRepository OrderHeaderRepository { get; }
        public IOrderDetailsRepository OrderDetailsRepository { get; }
        public IOrderStatusRepository OrderStatusRepository { get; }

        public UnitOfWork(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            StudentRepository = new StudentRepository(_context);
            InstructorRepository = new InstructorRepository(_context);
            PaymentCardRepository = new PaymentCardRepository(_context);
            CategoryRepository = new CategoryRepository(_context);
            EmailTemplateRepository = new EmailTemplateRepository(_context);
            UserManagerRepository = new UserManagerRepository(userManager);
            InstructorCommentRepository = new InstructorCommentRepository(_context);
            InstructorRatingRepository = new InstructorRatingRepository(_context);
            CourseRepository = new CourseRepository(_context);
            CourseVersionRepository = new CourseVersionRepository(_context);
            CourseSectionVersionRepository = new CourseSectionVersionRepository(_context);
            SectionDetailsVersionRepository = new SectionDetailsVersionRepository(_context);
            CourseVersionStatusRepository = new CourseVersionStatusRepository(_context);
            CourseVersionCommentRepository = new CourseVersionCommentRepository(_context);
            StudentCourseRepository = new StudentCourseRepository(_context);
            LevelRepository = new LevelRepository(_context);
            CartHeaderRepository = new CartHeaderRepository(_context);
            CartDetailsRepository = new CartDetailsRepository(_context);
            CourseReviewRepository = new CourseReviewRepository(_context);
            CourseReportRepository = new CourseReportRepository(_context);
            OrderHeaderRepository = new OrderHeaderRepository(_context);
            OrderDetailsRepository = new OrderDetailsRepository(_context);
            OrderStatusRepository = new OrderStatusRepository(_context);
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}