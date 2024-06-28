using Cursus.LMS.Model.Domain;

namespace Cursus.LMS.DataAccess.IRepository;

public interface ISectionDetailsVersionStatusRepository : IRepository<SectionDetailsVersionStatus>
{
    void Update(SectionDetailsVersionStatus sectionDetailsVersionStatus);
    void UpdateRange(IEnumerable<SectionDetailsVersionStatus> sectionDetailsVersionsStatus);
}