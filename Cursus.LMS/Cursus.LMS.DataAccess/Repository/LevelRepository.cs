using Cursus.LMS.DataAccess.Context;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace Cursus.LMS.DataAccess.Repository;

public class LevelRepository : Repository<Level>, ILevelRepository
{
    private readonly ApplicationDbContext _context;

    public LevelRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Level> GetLevelById(Guid levelId)
    {
        return await _context.Levels.FirstOrDefaultAsync(x => x.Id == levelId);
    }

    public void Update(Level level)
    {
        _context.Levels.Update(level);
    }

    public void UpdateRange(IEnumerable<Level> levels)
    {
        _context.Levels.UpdateRange(levels);
    }

}