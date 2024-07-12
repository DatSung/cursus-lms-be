using Cursus.LMS.DataAccess.Context;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;

namespace Cursus.LMS.DataAccess.Repository;

public class CartHeaderRepository: Repository<CartHeader>, ICartHeaderRepository
{
    private readonly ApplicationDbContext _context;
    
    public CartHeaderRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public void Update(CartHeader cartHeader)
    {
        _context.CartHeaders.Update(cartHeader);
    }

    public void UpdateRange(IEnumerable<CartHeader> cartHeaders)
    {
        _context.CartHeaders.UpdateRange(cartHeaders);
    }
}