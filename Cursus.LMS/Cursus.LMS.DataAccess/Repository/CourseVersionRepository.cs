using Cursus.LMS.DataAccess.Context;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace Cursus.LMS.DataAccess.Repository;

public class CourseVersionRepository : Repository<CourseVersion>, ICourseVersionRepository
{
    private readonly ApplicationDbContext _context;

    public CourseVersionRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public void Update(CourseVersion courseVersion)
    {
        _context.CourseVersions.Update(courseVersion);
    }

    public void UpdateRange(IEnumerable<CourseVersion> courseVersions)
    {
        _context.CourseVersions.UpdateRange(courseVersions);
    }

    public async Task<CourseVersion?> GetCourseVersionAsync
    (
        Guid courseVersionId,
        bool? asNoTracking = false
    )
    {
        return asNoTracking is not null
            ? await _context.CourseVersions
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == courseVersionId)
            : await _context.CourseVersions
                .FirstOrDefaultAsync(x => x.Id == courseVersionId);
    }

    public async Task<int> GetTotalCourseVersionsAsync(Guid? courseId)
    {
        return courseId is not null
            ? await _context.CourseVersions.CountAsync(x => x.CourseId == courseId)
            : 0;
    }
}