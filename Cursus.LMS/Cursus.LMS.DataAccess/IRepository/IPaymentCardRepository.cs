using Cursus.LMS.Model.Domain;

namespace Cursus.LMS.DataAccess.IRepository;

public interface IPaymentCardRepository : IRepository<PaymentCard>
{
    void Update(PaymentCard paymentCard);
    void UpdateRange(IEnumerable<PaymentCard> paymentCards);
    void Delete(PaymentCard paymentCard);
    Task<PaymentCard?> CardNumberExistsAsync(string cardNumber);
    Task<PaymentCard?> GetCardByUserId(string id);
    Task<PaymentCard> AddAsync(PaymentCard paymentCard);
}