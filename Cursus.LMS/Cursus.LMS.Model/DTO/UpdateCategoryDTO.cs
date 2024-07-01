using Cursus.LMS.Model.Domain;

namespace Cursus.LMS.Model.DTO;

public class UpdateCategoryDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? ParentId { get; set; }
    public int Status { get; set; }
}