using Cursus.LMS.DataAccess.Context;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;

namespace Cursus.LMS.DataAccess.Repository;

public class CategoryRepository: Repository<Category>, ICategoryRepository
{

    private readonly ApplicationDbContext _context;
    
    public CategoryRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public void Update(Category category)
    {
        _context.Categories.Update(category);
    }

    public void UpdateRange(IEnumerable<Category> categories)
    {
        _context.Categories.UpdateRange(categories);
    }
}