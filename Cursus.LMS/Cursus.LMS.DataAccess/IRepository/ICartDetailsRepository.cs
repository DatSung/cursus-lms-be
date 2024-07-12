using Cursus.LMS.Model.Domain;

namespace Cursus.LMS.DataAccess.IRepository;

public interface ICartDetailsRepository : IRepository<CartDetails>
{
    void Update(CartDetails cartDetails);
    void UpdateRange(IEnumerable<CartDetails> cartsDetails);
}