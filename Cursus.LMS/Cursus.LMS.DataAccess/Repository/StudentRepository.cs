using Cursus.LMS.DataAccess.Context;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;

namespace Cursus.LMS.DataAccess.Repository;

public class StudentRepository : Repository<Student>, IStudentRepository
{
    private readonly ApplicationDbContext _context;

    public StudentRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public void Update(Student student)
    {
        _context.Students.Update(student);
    }

    public void UpdateRange(IEnumerable<Student> students)
    {
        _context.Students.UpdateRange(students);
    }
    public async Task<Student> AddAsync(Student student)
    {
        var entityEntry = await _context.Students.AddAsync(student);
        return entityEntry.Entity;
    }
}