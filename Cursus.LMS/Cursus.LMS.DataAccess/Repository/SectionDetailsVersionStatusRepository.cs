using Cursus.LMS.DataAccess.Context;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;

namespace Cursus.LMS.DataAccess.Repository;

public class SectionDetailsVersionStatusRepository : Repository<SectionDetailsVersionStatus>,
    ISectionDetailsVersionStatusRepository
{
    private readonly ApplicationDbContext _context;

    public SectionDetailsVersionStatusRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public void Update(SectionDetailsVersionStatus sectionDetailsVersionStatus)
    {
        _context.SectionDetailsVersionStatus.Update(sectionDetailsVersionStatus);
    }

    public void UpdateRange(IEnumerable<SectionDetailsVersionStatus> sectionDetailsVersionsStatus)
    {
        _context.SectionDetailsVersionStatus.UpdateRange(sectionDetailsVersionsStatus);
    }
}