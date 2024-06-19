using Cursus.LMS.DataAccess.Context;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Cursus.LMS.DataAccess.Repository;

public class InstructorRepository : Repository<Instructor>, IInstructorRepository
{
    private readonly ApplicationDbContext _context;

    public InstructorRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public void Update(Instructor instructor)
    {
        _context.Instructors.Update(instructor);
    }

    public void UpdateRange(IEnumerable<Instructor> instructors)
    {
        _context.Instructors.UpdateRange(instructors);
    }

    public async Task<Instructor> AddAsync(Instructor instructor)
    {
        var entityEntry = await _context.Instructors.AddAsync(instructor);
        return entityEntry.Entity;
    }
    public async Task<Instructor> GetAsync(string userId)
    {
        return await _context.Instructors.FirstOrDefaultAsync(x => x.UserId == userId);
    }

    public async Task<Instructor?> GetById(Guid id)
    {
        return await _context.Instructors.Include("ApplicationUser").FirstOrDefaultAsync(x => x.InstructorId == id);
    }
    public async Task<IDbContextTransaction> BeginTransactionAsync()
    {
        return await _context.Database.BeginTransactionAsync();
    }
}