using Cursus.LMS.Model.Domain;

namespace Cursus.LMS.DataAccess.IRepository;

public interface ICourseSectionVersionRepository : IRepository<CourseSectionVersion>
{
    void Update(CourseSectionVersion courseSectionVersion);
    void UpdateRange(IEnumerable<CourseSectionVersion> courseSectionVersions);
    Task<List<CourseSectionVersion>?> GetCourseSectionVersionsOfCourseVersionAsync(Guid courseVersionId, bool? asNoTracking);
}