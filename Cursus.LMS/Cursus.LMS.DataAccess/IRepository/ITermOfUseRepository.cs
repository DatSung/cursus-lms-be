using Cursus.LMS.Model.Domain;

namespace Cursus.LMS.DataAccess.IRepository;

public interface ITermOfUseRepository : IRepository<TermOfUse>
{
    void Update(TermOfUse termOfUse);
    void UpdateRange(IEnumerable<TermOfUse> termOfUses);
}