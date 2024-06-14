using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cursus.LMS.Model.Domain;

public class Category : BaseEntity<string, string, int>
{
    [Key] public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public Guid? ParentId { get; set; }
    [ForeignKey("ParentId")] public Category ParentCategory { get; set; }
    public int Status { get; set; } = 0; // 0 mean New, 1 mean Active, 2 mean Deactivated.
}