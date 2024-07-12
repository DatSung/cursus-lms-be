using Cursus.LMS.Model.Domain;

namespace Cursus.LMS.DataAccess.IRepository;

public interface IStudentRepository : IRepository<Student>
{
    void Update(Student student);
    void UpdateRange(IEnumerable<Student> students);
    Task<Student?> GetById(Guid id);
    Task<Student> AddAsync(Student student);
    Task<Student?> GetByUserId(string id);
}