using Cursus.LMS.DataAccess.Context;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;

namespace Cursus.LMS.DataAccess.Repository;

public class InstructorCommentRepository : Repository<InstructorComment>, IInstructorCommentRepository
{
    private readonly ApplicationDbContext _context;

    public InstructorCommentRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public void Update(InstructorComment instructorComment)
    {
        _context.InstructorComments.Update(instructorComment);
    }

    public void UpdateRange(IEnumerable<InstructorComment> instructorComments)
    {
        _context.InstructorComments.UpdateRange(instructorComments);
    }
}