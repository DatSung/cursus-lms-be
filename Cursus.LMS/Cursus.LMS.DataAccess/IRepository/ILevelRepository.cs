using Cursus.LMS.Model.Domain;

namespace Cursus.LMS.DataAccess.IRepository;

public interface ILevelRepository : IRepository<Level>
{
    void Update(Level level);
    void UpdateRange(IEnumerable<Level> levels);
    Task<Level> GetLevelById(Guid levelId);
}
