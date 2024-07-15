using Cursus.LMS.Model.Domain;

namespace Cursus.LMS.DataAccess.IRepository;

public interface ICourseReportRepository : IRepository<CourseReport>
{
    void Update(CourseReport courseReport);
    void UpdateRange(IEnumerable<CourseReport> courseReports);
    Task<CourseReport> GetById(Guid id);
}