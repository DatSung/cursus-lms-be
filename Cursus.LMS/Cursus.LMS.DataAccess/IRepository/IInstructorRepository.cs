using Cursus.LMS.Model.Domain;
using Microsoft.EntityFrameworkCore.Storage;

namespace Cursus.LMS.DataAccess.IRepository;

public interface IInstructorRepository : IRepository<Instructor>
{
    void Update(Instructor instructor);
    void UpdateRange(IEnumerable<Instructor> instructors);
    Task<Instructor> AddAsync(Instructor instructor);
    Task<Instructor> GetAsync(string userId);
    Task<Instructor?> GetById(Guid id);
    Task<IDbContextTransaction> BeginTransactionAsync();
}