using Cursus.LMS.DataAccess.Context;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;

namespace Cursus.LMS.DataAccess.Repository;

public class StudentCommentRepository : Repository<StudentComment>, IStudentCommentRepository
{
    private readonly ApplicationDbContext _context;
    public StudentCommentRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
    public void Update(StudentComment studentComment)
    {
        _context.StudentComments.Update(studentComment);
    }
    public void UpdateRange(IEnumerable<StudentComment> studentComments)
    {
        _context.StudentComments.UpdateRange(studentComments);
    }
}