using Cursus.LMS.Model.Domain;

namespace Cursus.LMS.DataAccess.IRepository;

public interface ICartHeaderRepository : IRepository<CartHeader>
{
    void Update(CartHeader cartHeader);
    void UpdateRange(IEnumerable<CartHeader> cartHeaders);
}