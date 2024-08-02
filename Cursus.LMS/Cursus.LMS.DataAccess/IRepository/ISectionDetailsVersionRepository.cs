using Cursus.LMS.Model.Domain;

namespace Cursus.LMS.DataAccess.IRepository;

public interface ISectionDetailsVersionRepository : IRepository<SectionDetailsVersion>
{
    void Update(SectionDetailsVersion sectionDetailsVersion);
    void UpdateRange(IEnumerable<SectionDetailsVersion> sectionDetailsVersions);

    Task<List<SectionDetailsVersion>?> GetSectionDetailsVersionsOfCourseSectionVersionAsync
    (
        Guid courseSectionVersionId,
        bool? asNoTracking
    );
    Task<SectionDetailsVersion?> GetSectionDetailsVersionById(Guid detailsId);
}