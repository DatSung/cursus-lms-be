using Cursus.LMS.DataAccess.Context;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;

namespace Cursus.LMS.DataAccess.Repository;

public class SectionDetailsVersionRepository : Repository<SectionDetailsVersion>, ISectionDetailsVersionRepository
{
    private readonly ApplicationDbContext _context;

    public SectionDetailsVersionRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public void Update(SectionDetailsVersion sectionDetailsVersion)
    {
        _context.SectionDetailsVersions.Update(sectionDetailsVersion);
    }

    public void UpdateRange(IEnumerable<SectionDetailsVersion> sectionDetailsVersions)
    {
        _context.SectionDetailsVersions.UpdateRange(sectionDetailsVersions);
    }

    public async Task<List<SectionDetailsVersion>?> GetSectionDetailsVersionsOfCourseSectionVersionAsync
    (
        Guid courseSectionVersionId,
        bool? asNoTracking
    )
    {
        throw new NotImplementedException();
    }
}