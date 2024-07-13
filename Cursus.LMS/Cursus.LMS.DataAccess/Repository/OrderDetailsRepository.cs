using Cursus.LMS.DataAccess.Context;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;

namespace Cursus.LMS.DataAccess.Repository;

public class OrderDetailsRepository : Repository<OrderDetails>, IOrderDetailsRepository
{
    private readonly ApplicationDbContext _context;
    
    public OrderDetailsRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public void Update(OrderDetails orderDetails)
    {
        _context.OrderDetails.Update(orderDetails);
    }

    public void UpdateRange(IEnumerable<OrderDetails> ordersDetails)
    {
        _context.OrderDetails.UpdateRange(ordersDetails);
    }
}