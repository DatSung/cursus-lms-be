using Cursus.LMS.Model.Domain;

namespace Cursus.LMS.DataAccess.IRepository;

public interface IStudentCommentRepository : IRepository<StudentComment>
{
    void Update(StudentComment studentComment);
    void UpdateRange(IEnumerable<StudentComment> studentComments);
}