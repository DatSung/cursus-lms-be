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

    public async Task<CourseVersion?> GetCourseVersionsAsNoTracking(Guid courserVersionId)
    {
        return await _context.CourseVersions.AsNoTracking().FirstOrDefaultAsync(x => x.Id == courserVersionId);
    }

    public async Task<CourseVersion?> GetCourseVersionById(Guid courseVersionId)
    {
        return await _context.CourseVersions.FirstOrDefaultAsync(x => x.Id == courseVersionId);
    }
}