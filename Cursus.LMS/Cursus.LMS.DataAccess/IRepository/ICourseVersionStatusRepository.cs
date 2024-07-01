using Cursus.LMS.Model.Domain;

namespace Cursus.LMS.DataAccess.IRepository;

public interface ICourseVersionStatusRepository : IRepository<CourseVersionStatus>
{
    void Update(CourseVersionStatus courseVersionStatus);
    void UpdateRange(IEnumerable<CourseVersionStatus> courseVersionsStatus);
    Task<CourseVersionStatus?> GetCourseVersionStatusByIdAsync(Guid courseVersionStatusId);
}