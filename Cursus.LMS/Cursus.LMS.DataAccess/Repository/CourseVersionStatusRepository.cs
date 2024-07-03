using Cursus.LMS.DataAccess.Context;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace Cursus.LMS.DataAccess.Repository;

public class CourseVersionStatusRepository : Repository<CourseVersionStatus>, ICourseVersionStatusRepository
{
    private readonly ApplicationDbContext _context;

    public CourseVersionStatusRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public void Update(CourseVersionStatus courseVersionStatus)
    {
        _context.CourseVersionStatus.Update(courseVersionStatus);
    }

    public void UpdateRange(IEnumerable<CourseVersionStatus> courseVersionsStatus)
    {
        _context.CourseVersionStatus.UpdateRange(courseVersionsStatus);
    }

    public async Task<CourseVersionStatus?> GetCourseVersionStatusByIdAsync(Guid courseVersionStatusId)
    {
        return await _context.CourseVersionStatus.FirstOrDefaultAsync(x => x.Id == courseVersionStatusId);
    }
}