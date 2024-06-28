using Cursus.LMS.DataAccess.Context;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;

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
}