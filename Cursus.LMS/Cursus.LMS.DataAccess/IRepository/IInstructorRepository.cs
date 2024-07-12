using Cursus.LMS.Model.Domain;
using Microsoft.EntityFrameworkCore.Storage;

namespace Cursus.LMS.DataAccess.IRepository;

public interface IInstructorRepository : IRepository<Instructor>
{
    void Update(Instructor instructor);
    void UpdateRange(IEnumerable<Instructor> instructors);
    Task<Instructor?> GetById(Guid id);
    Task<Instructor?> GetByUserId(string id);
    Task<IDbContextTransaction> BeginTransactionAsync();
}