using Cursus.LMS.DataAccess.Context;
using Cursus.LMS.DataAccess.IRepository;

namespace Cursus.LMS.DataAccess.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    public IStudentRepository StudentRepository { get; set; }
    public IInstructorRepository InstructorRepository { get; set; }
    public ICategoryRepository CategoryRepository { get; }
    public IEmailTemplateRepository EmailTemplateRepository { get; }
    public IPaymentCardRepository PaymentCardRepository { get; set; }
    
    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        StudentRepository = new StudentRepository(_context);
        InstructorRepository = new InstructorRepository(_context);
        PaymentCardRepository = new PaymentCardRepository(_context);
        CategoryRepository = new CategoryRepository(_context);
        EmailTemplateRepository = new EmailTemplateRepository(_context);
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }
}