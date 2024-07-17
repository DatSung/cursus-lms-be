using Cursus.LMS.DataAccess.Context;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;

namespace Cursus.LMS.DataAccess.Repository;

public class CourseReportRepository : Repository<CourseReport>, ICourseReportRepository
{
    private readonly ApplicationDbContext _context;

    public CourseReportRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public void Update(CourseReport courseReport)
    {
        _context.CourseReports.Update(courseReport);
    }

    public void UpdateRange(IEnumerable<CourseReport> courseReports)
    {
        _context.CourseReports.UpdateRange(courseReports);
    }
    public async Task<CourseReport> GetById(Guid id)
    {
        return await _context.CourseReports.FindAsync(id);
    }
}