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
        public IInstructorRatingRepository InstructorRatingRepository { get; set; }

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
            InstructorRatingRepository = new InstructorRatingRepository(_context); // Thêm dòng này
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
