using Cursus.LMS.Model.Domain;

namespace Cursus.LMS.DataAccess.IRepository;

public interface IOrderStatusRepository : IRepository<OrderStatus>
{
    void Update(OrderStatus orderStatus);
    void UpdateRange(IEnumerable<OrderStatus> ordersStatus);
}