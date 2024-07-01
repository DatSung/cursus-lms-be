using Cursus.LMS.Model.Domain;

namespace Cursus.LMS.DataAccess.IRepository;

public interface ICategoryRepository: IRepository<Category>
{
    void Update(Category category);
    void UpdateRange(IEnumerable<Category> categories);
    Task<Category> GetCategoryByIdAsync(Guid id);
}