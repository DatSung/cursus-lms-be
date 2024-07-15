using Cursus.LMS.DataAccess.Context;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;
using Microsoft.EntityFrameworkCore;


namespace Cursus.LMS.DataAccess.Repository
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {

        private readonly ApplicationDbContext _context;

        public CourseRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Course course)
        {
            _context.Courses.Update(course);
        }
        public void UpdateRange(IEnumerable<Course> courses)
        {
            _context.Courses.UpdateRange(courses);
        }
        public async Task<Course?> GetById(Guid courseId)
        {
            return await _context.Courses.FirstOrDefaultAsync(x => x.Id == courseId);
        }
    }
}
