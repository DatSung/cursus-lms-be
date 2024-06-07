using Cursus.LMS.DataAccess.Context;
using Cursus.LMS.DataAccess.IRepository;

namespace Cursus.LMS.DataAccess.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    public IStudentRepository StudentRepository { get; set; }
    public IInstructorRepository InstructorRepository { get; set; }
    public IPaymentCardRepository PaymentCardRepository { get; set; }

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        StudentRepository = new StudentRepository(_context);
        InstructorRepository = new InstructorRepository(_context);
        PaymentCardRepository = new PaymentCardRepository(_context);
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}