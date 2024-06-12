using Cursus.LMS.Model.Domain;

namespace Cursus.LMS.DataAccess.IRepository;

public interface IPaymentCardRepository : IRepository<PaymentCard>
{
    void Update(PaymentCard paymentCard);
    void UpdateRange(IEnumerable<PaymentCard> paymentCards);
    Task<PaymentCard> CardNumberExistsAsync(string cardNumber);
    Task<PaymentCard> AddAsync(PaymentCard paymentCard);
}