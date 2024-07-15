using Cursus.LMS.Model.Domain;

namespace Cursus.LMS.DataAccess.IRepository;

public interface IOrderDetailsRepository : IRepository<OrderDetails>
{
    void Update(OrderDetails orderDetails);
    void UpdateRange(IEnumerable<OrderDetails> ordersDetails);
}