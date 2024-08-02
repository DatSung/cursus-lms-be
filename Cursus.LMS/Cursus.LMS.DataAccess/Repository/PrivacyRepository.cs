using Cursus.LMS.DataAccess.Context;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;

namespace Cursus.LMS.DataAccess.Repository;

public class PrivacyRepository : Repository<Privacy>, IPrivacyRepository
{
    private readonly ApplicationDbContext _context;

    public PrivacyRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public void Update(Privacy privacy)
    {
        _context.Privacies.Update(privacy);
    }

    public void UpdateRange(IEnumerable<Privacy> privacies)
    {
        _context.Privacies.UpdateRange(privacies);
    }
}