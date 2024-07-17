using Cursus.LMS.DataAccess.Context;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;

namespace Cursus.LMS.DataAccess.Repository;

public class BalanceRepository : Repository<Balance>, IBalanceRepository
{
    private readonly ApplicationDbContext _context;

    public BalanceRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public void Update(Balance balance)
    {
        _context.Balances.Update(balance);
    }

    public void UpdateRange(IEnumerable<Balance> balances)
    {
        _context.Balances.UpdateRange(balances);
    }
}