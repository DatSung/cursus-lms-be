using Cursus.LMS.Model.Domain;

namespace Cursus.LMS.Model.DTO;

public class CategoryDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public List<CategoryDTO> SubCategories { get; set; }
}