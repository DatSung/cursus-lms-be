using Cursus.LMS.DataAccess.Context;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;

namespace Cursus.LMS.DataAccess.Repository;

public class TermOfUseRepository : Repository<TermOfUse>, ITermOfUseRepository
{
    private readonly ApplicationDbContext _context;

    public TermOfUseRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public void Update(TermOfUse termOfUse)
    {
        _context.TermOfUses.Update(termOfUse);
    }

    public void UpdateRange(IEnumerable<TermOfUse> termOfUses)
    {
        _context.TermOfUses.UpdateRange(termOfUses);
    }
}