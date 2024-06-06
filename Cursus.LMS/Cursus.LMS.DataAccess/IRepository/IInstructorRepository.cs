using Cursus.LMS.Model.Domain;

namespace Cursus.LMS.DataAccess.IRepository;

public interface IInstructorRepository : IRepository<Instructor>
{
    void Update(Instructor instructor);
    void UpdateRange(IEnumerable<Instructor> instructors);
}