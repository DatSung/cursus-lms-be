using Cursus.LMS.Model.Domain;

namespace Cursus.LMS.Model.DTO;

public class UpdateCategoryDTO : BaseEntity <string, string, int>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public Guid? ParentId { get; set; }
}