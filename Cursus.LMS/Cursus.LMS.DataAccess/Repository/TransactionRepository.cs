using Cursus.LMS.DataAccess.Context;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;

namespace Cursus.LMS.DataAccess.Repository;

public class TransactionRepository : Repository<Transaction>, ITransactionRepository
{
    private readonly ApplicationDbContext _context;

    public TransactionRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public void Update(Transaction transaction)
    {
        _context.Transactions.Update(transaction);
    }

    public void UpdateRange(IEnumerable<Transaction> transactions)
    {
        _context.Transactions.UpdateRange(transactions);
    }
}