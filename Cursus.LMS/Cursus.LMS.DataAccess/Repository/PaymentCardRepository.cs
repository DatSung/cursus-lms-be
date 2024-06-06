using Cursus.LMS.DataAccess.Context;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;

namespace Cursus.LMS.DataAccess.Repository;

public class PaymentCardRepository : Repository<PaymentCard>, IPaymentCardRepository
{
    private readonly ApplicationDbContext _context;

    public PaymentCardRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public void Update(PaymentCard paymentCard)
    {
        _context.PaymentCards.Update(paymentCard);
    }

    public void UpdateRange(IEnumerable<PaymentCard> paymentCards)
    {
        _context.PaymentCards.UpdateRange(paymentCards);
    }
}