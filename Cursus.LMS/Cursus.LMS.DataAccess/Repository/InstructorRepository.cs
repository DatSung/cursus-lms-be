using Cursus.LMS.DataAccess.Context;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;

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
}