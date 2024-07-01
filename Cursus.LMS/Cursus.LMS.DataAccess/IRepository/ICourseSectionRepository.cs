using Cursus.LMS.Model.Domain;

namespace Cursus.LMS.DataAccess.IRepository;

public interface ICourseSectionRepository : IRepository<CourseSection>
{
    void Update(CourseSection courseSection);
    void UpdateRange(IEnumerable<CourseSection> courseSections);
}