using Cursus.LMS.DataAccess.Context;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Cursus.LMS.DataAccess.Repository
{
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

        public async Task<PaymentCard?> CardNumberExistsAsync(string cardNumber)
        {
            return  await _context.PaymentCards.FirstOrDefaultAsync(x => x.CardNumber == cardNumber);
        }

        public async Task<PaymentCard?> GetCardByUserId(string id)
        {
            return await _context.PaymentCards.FirstOrDefaultAsync(x => x.UserId == id);
        }

        public async Task<PaymentCard> AddAsync(PaymentCard paymentCard)
        {
            var entityEntry = await _context.PaymentCards.AddAsync(paymentCard);
            return entityEntry.Entity;
        }
        public void Delete(PaymentCard paymentCard) 
        {
            _context.PaymentCards.Remove(paymentCard);
        }

    }
}