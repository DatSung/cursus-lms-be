using Cursus.LMS.DataAccess.Context;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;
using Microsoft.EntityFrameworkCore;

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
        return asNoTracking is true
            ? await _context.SectionDetailsVersions
                .AsNoTracking()
                .Where(x => x.CourseSectionVersionId == courseSectionVersionId)
                .ToListAsync()
            : await _context.SectionDetailsVersions
                .Where(x => x.CourseSectionVersionId == courseSectionVersionId)
                .ToListAsync();
    }

    public async Task<SectionDetailsVersion?> GetSectionDetailsVersionById(Guid detailsId)
    {
        return await _context.SectionDetailsVersions.FirstOrDefaultAsync(x => x.Id == detailsId);
    }
}