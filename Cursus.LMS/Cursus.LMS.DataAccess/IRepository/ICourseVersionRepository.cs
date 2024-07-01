using Cursus.LMS.Model.Domain;

namespace Cursus.LMS.DataAccess.IRepository;

public interface ICourseVersionRepository : IRepository<CourseVersion>
{
    void Update(CourseVersion courseVersion);
    void UpdateRange(IEnumerable<CourseVersion> courseVersions);
    Task<CourseVersion?> GetCourseVersionAsync(Guid courseVersionId, bool? asNoTracking);
    Task<int> GetTotalCourseVersionsAsync(Guid? courseId);
}