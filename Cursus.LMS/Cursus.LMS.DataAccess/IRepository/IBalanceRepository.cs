using Cursus.LMS.Model.Domain;

namespace Cursus.LMS.DataAccess.IRepository;

public interface IBalanceRepository : IRepository<Balance>
{
    void Update(Balance balance);
    void UpdateRange(IEnumerable<Balance> balances);
}