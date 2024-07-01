using Cursus.LMS.DataAccess.Context;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;

namespace Cursus.LMS.DataAccess.Repository;

public class CourseSectionRepository : Repository<CourseSection>, ICourseSectionRepository
{
    private readonly ApplicationDbContext _context;

    public CourseSectionRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public void Update(CourseSection courseSection)
    {
        _context.CourseSections.Update(courseSection);
    }

    public void UpdateRange(IEnumerable<CourseSection> courseSections)
    {
        _context.CourseSections.UpdateRange(courseSections);
    }
}