using Cursus.LMS.DataAccess.Context;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace Cursus.LMS.DataAccess.Repository;

public class CourseSectionVersionRepository : Repository<CourseSectionVersion>, ICourseSectionVersionRepository
{
    private readonly ApplicationDbContext _context;

    public CourseSectionVersionRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public void Update(CourseSectionVersion courseSectionVersion)
    {
        _context.CourseSectionVersions.Update(courseSectionVersion);
    }

    public void UpdateRange(IEnumerable<CourseSectionVersion> courseSectionVersions)
    {
        _context.CourseSectionVersions.UpdateRange(courseSectionVersions);
    }

    public async Task<List<CourseSectionVersion>?> GetCourseSectionVersionsOfCourseVersionAsync
    (
        Guid courseVersionId,
        bool? asNoTracking = false
    )
    {
        return asNoTracking is true
            ? await _context.CourseSectionVersions
                .AsNoTracking()
                .Where(x => x.CourseVersionId == courseVersionId)
                .ToListAsync()
            : await _context.CourseSectionVersions
                .Where(x => x.CourseVersionId == courseVersionId)
                .ToListAsync();
    }
}