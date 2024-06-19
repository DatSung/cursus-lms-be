using Cursus.LMS.DataAccess.Context;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;
using Microsoft.EntityFrameworkCore;

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

    public async Task<Instructor?> GetById(Guid id)
    {
        return await _context.Instructors.Include("ApplicationUser").FirstOrDefaultAsync(x => x.InstructorId == id);
    }
}