using Cursus.LMS.Model.Domain;

namespace Cursus.LMS.DataAccess.IRepository;

public interface ITransactionRepository : IRepository<Transaction>
{
    void Update(Transaction transaction);
    void UpdateRange(IEnumerable<Transaction> transactions);
}