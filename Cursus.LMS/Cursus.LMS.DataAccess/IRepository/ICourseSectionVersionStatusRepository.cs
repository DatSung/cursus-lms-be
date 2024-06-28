using Cursus.LMS.Model.Domain;

namespace Cursus.LMS.DataAccess.IRepository;

public interface ICourseSectionVersionStatusRepository : IRepository<CourseSectionVersionStatus>
{
    void Update(CourseSectionVersionStatus courseSectionVersionStatus);
    void UpdateRange(IEnumerable<CourseSectionVersionStatus> courseSectionVersionsStatus);
}