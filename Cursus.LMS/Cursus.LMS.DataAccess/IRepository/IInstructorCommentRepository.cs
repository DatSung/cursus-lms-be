using Cursus.LMS.Model.Domain;

namespace Cursus.LMS.DataAccess.IRepository;

public interface IInstructorCommentRepository : IRepository<InstructorComment>
{
    void Update(InstructorComment instructorComment);
    void UpdateRange(IEnumerable<InstructorComment> instructorComments);
}