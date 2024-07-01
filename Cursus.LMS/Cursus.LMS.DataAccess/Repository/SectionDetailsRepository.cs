using Cursus.LMS.DataAccess.Context;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;

namespace Cursus.LMS.DataAccess.Repository;

public class SectionDetailsRepository : Repository<SectionDetails>, ISectionDetailsRepository
{
    private readonly ApplicationDbContext _context;

    public SectionDetailsRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public void Update(SectionDetails sectionDetails)
    {
        _context.SectionDetails.Update(sectionDetails);
    }

    public void UpdateRange(IEnumerable<SectionDetails> sectionsDetails)
    {
        _context.SectionDetails.UpdateRange(sectionsDetails);
    }
}